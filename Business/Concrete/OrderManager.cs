using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.Identity.Client;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly ICartItemDal _cartItemDal;
        private readonly IProductDal _productDal;
        private readonly IAddressDal _addressDal;
        public OrderManager(IOrderDal orderDal, ICartItemDal cartItemDal,IProductDal productDal , IAddressDal addressDal)
        {
            _orderDal = orderDal;
            _cartItemDal = cartItemDal;
            _productDal = productDal;
            _addressDal = addressDal;
        }

        public Result Add(OrderDto orderDto)
        {
            try
            {               
                var usersCartItems = _cartItemDal.GetAll(u => u.UserId == orderDto.UserId);
                if(usersCartItems == null)
                {
                    return new ErrorResult("Cart not found!");
                }
                double TotalPrice = 0;
                foreach(var cartItems in usersCartItems)
                {
                    var product = _productDal.Get(p => p.Id == cartItems.ProductId);
                    if (product == null)
                    {
                        return new ErrorResult("Product not found!");
                    }
                    TotalPrice += product.Price * cartItems.Quantity;
                }
                var newOrder = new Order
                {
                    UserId = orderDto.UserId,
                    TotalPrice = TotalPrice,
                    Status = "pending",
                    AddressId = orderDto.AddressId,
                };
                _orderDal.Add(newOrder);              
                return new SuccessResult("Order added successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public Result Delete(Guid orderId)
        {
            try
            {
                var order = _orderDal.Get(o => o.Id == orderId);
                if(order == null)
                {
                    return new ErrorResult("Order not found!");
                }
                _orderDal.Delete(order);
                return new SuccessResult("Order deleted successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public DataResult<List<Order>> GetAllOrderByUser(Guid userId)
        {
            try
            {
                var orders = _orderDal.GetAll(o => o.UserId == userId);
                if (orders == null || !orders.Any())
                {
                    return new SuccessDataResult<List<Order>>(new List<Order>(), "Sipariş bulunamadı.");
                }

                return new SuccessDataResult<List<Order>>(orders, "Orders retrieved successfully!");
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Order>>("Something went wrong!");
            }
        }

        public Result UpdateAdress(Guid orderId, Guid addressId)
        {
            try
            {
                var order = _orderDal.Get(o => o.Id == orderId);
                if(order == null)
                {
                    return new ErrorResult("Order not found!");
                }
                var address = _addressDal.Get(a => a.Id == addressId);
                if(address == null)
                {
                    return new ErrorResult("Address not found!");
                }
                order.AddressId = addressId;
                _orderDal.Update(order);
                return new SuccessResult("Order address updated successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public Result UpdateStatus(Guid orderId)
        {
            try
            {
                var order = _orderDal.Get(o => o.Id == orderId);
                if(order == null)
                {
                    return new ErrorResult("Order not found!");
                }
                if (order.Status == "pending")
                {
                    order.Status = "completed";
                }
                else if (order.Status == "completed")
                {
                    order.Status = "pending";
                }
                else
                {
                    return new ErrorResult("Invalid order status!");
                }
                _orderDal.Update(order);
                return new SuccessResult("Order status updated successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }
    }
}
