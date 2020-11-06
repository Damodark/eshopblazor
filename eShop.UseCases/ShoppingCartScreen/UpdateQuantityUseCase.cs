using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.ShoppingCartScreen.Interfaces;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class UpdateQuantityUseCase : IUpdateQuantityUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public UpdateQuantityUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStoreState)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartStoreState = shoppingCartStoreState;
        }

        private readonly IShoppingCartStateStore shoppingCartStoreState;

        public async Task<Order> Execute(int productId, int quantity)
        {
            var order = await shoppingCart.UpdateQuantityAsync(productId, quantity);
            shoppingCartStoreState.UpdateProductQuantity();
            return order;
        }
    }
}