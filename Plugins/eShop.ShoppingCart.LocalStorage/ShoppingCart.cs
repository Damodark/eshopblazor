using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IJSRuntime jSRuntime;
        private readonly IProductRepository productRepository;
        private const string cstringShoppingCart = "eShop.ShoppingCart";

        public ShoppingCart(IJSRuntime jSRuntime, IProductRepository productRepository)
        {
            this.jSRuntime = jSRuntime;
            this.productRepository = productRepository;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price);
            await SetOrder(order);
            return order;
        }

        public async Task<Order> DelteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);
            return order;
        }

        public Task EmptyAsync()
        {
            return this.SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await SetOrder(order);
            return order;
        }

        public Task<Order> PlaceOrdertAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var order = await GetOrder();
            if (quantity < 0)
            {
                return order;
            }
            else if (quantity == 0)
            {
                return await DelteProductAsync(productId);
            }

            var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == productId);
            if (lineItem != null) lineItem.Quantity = quantity;
            await SetOrder(order);
            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order order = null;
            var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstringShoppingCart);
            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null")
            {
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            }
            else
            {
                order = new Order();
                await SetOrder(order);
            }
            foreach (var item in order.LineItems)
            {
                item.Product = productRepository.GetProduct(item.ProductId);
            }
            return order;
        }

        private async Task SetOrder(Order order)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", cstringShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}