namespace eShop.UseCases.AdminPortal.OrderDetail.Interfaces
{
    public interface IProcessOrderUseCase
    {
        bool Execute(int orderId, string adminUserName);
    }
}