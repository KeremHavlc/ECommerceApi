using Core.Dtos;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IOrderItemService
    {
        Result Add(Guid orderId);
        DataResult<List<OrderItemDto>> GetAllOrderItem(Guid userId);
    }
}
