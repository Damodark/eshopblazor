using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.ShoppingCartScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCartStoreState;

        public DeleteProductUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStoreState)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartStoreState = shoppingCartStoreState;
        }

        public async Task<Order> Execute(int productId)
        {
            var order = await this.shoppingCart.DelteProductAsync(productId);
            this.shoppingCartStoreState.UpdateLineItemsCount();
            return order;
        }
    }
}