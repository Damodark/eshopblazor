using eShop.CoreBusiness.Models;

namespace eShop.UseCases.OrderConfirmationScreen.Interface
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}