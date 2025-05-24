using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;
        private readonly IOrderDal _orderDal;
        private readonly ICartItemDal _cartItemDal;
        private readonly IProductDal _productDal;
        public OrderItemManager(IOrderItemDal orderItemDal , IOrderDal orderDal, ICartItemDal cartItemDal , IProductDal productDal)
        {
            _orderItemDal = orderItemDal;
            _orderDal = orderDal;
            _cartItemDal = cartItemDal;
            _productDal = productDal;
        }
        public Result Add(Guid orderId)
        {
            try
            {
                var order = _orderDal.Get(o => o.Id == orderId);
                if(order == null)
                {
                    return new ErrorResult("Order not found!");
                }
                var userCartItems = _cartItemDal.GetAll(c => c.UserId == order.UserId);
                foreach(var cartItems in userCartItems)
                {
                    var product = _productDal.Get(p => p.Id == cartItems.ProductId);
                    if(product == null)
                    {
                        return new ErrorResult("Product not found!");
                    }
                    var newOrderItem = new OrderItem
                    {
                        OrderId = orderId,
                        ProductId = product.Id,
                        Quantity = cartItems.Quantity,
                        UnitPrice = product.Price
                    };                  
                    _orderItemDal.Add(newOrderItem);
                }
                foreach (var cartItem in userCartItems)
                {
                    _cartItemDal.Delete(cartItem);
                }
                return new SuccessResult("OrderItem added successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public DataResult<List<OrderItemDto>> GetAllOrderItem(Guid userId,Guid orderId)
        {
            try
            {
                var order = _orderDal.Get(o => o.UserId == userId && o.Id ==orderId);
                if (order == null)
                {
                    return new ErrorDataResult<List<OrderItemDto>>("Order not found!");
                }

                var orderItems = _orderItemDal.GetAll(p => p.OrderId == order.Id);
                if (orderItems == null || !orderItems.Any())
                {
                    return new ErrorDataResult<List<OrderItemDto>>("Order Item not found!");
                }

                var orderItemDtos = orderItems.Select(item => new OrderItemDto
                {
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList();

                return new SuccessDataResult<List<OrderItemDto>>(orderItemDtos, "OrderItem listed successfully!");
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<OrderItemDto>>("Something went wrong!");
            }
        }
    }
}
