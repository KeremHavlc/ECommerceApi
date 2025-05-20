using Core.Dtos;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IOrderItemService
    {
        Result Add(OrderItemDto orderItemDto);       

    }
}
