using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AdminPortal.OrderDetail.Interfaces
{
    public interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}