using Core.Dtos;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Result Add(OrderDto orderDto);
        Result Delete(Guid orderId);
        DataResult<List<Order>> GetAllOrderByUser(Guid userId);
        Result UpdateAdress(Guid orderId, Guid addressId);
        Result UpdateStatus(Guid orderId);
    }
}
