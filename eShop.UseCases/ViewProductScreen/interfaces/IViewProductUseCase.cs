using eShop.CoreBusiness.Models;

namespace eShop.UseCases.ViewProductScreen.interfaces
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}