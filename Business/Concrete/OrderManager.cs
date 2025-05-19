using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public Result Add(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
