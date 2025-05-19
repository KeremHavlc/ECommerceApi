using Core.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Result Add(OrderDto orderDto);
    }
}
