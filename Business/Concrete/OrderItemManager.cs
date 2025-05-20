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
        public Result Add(OrderItemDto orderItemDto)
        {
            try
            {
                var order = _orderDal.Get(o => o.Id == orderItemDto.OrderId);
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
                        OrderId = orderItemDto.OrderId,
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
    }
}
