using AutoMapper;
using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;
        private readonly IMapper _mapper;
        public CartItemManager(ICartItemDal cartItemDal,IMapper mapper)
        {
            _cartItemDal = cartItemDal;
            _mapper = mapper;
        }
        public Result Add(CartItemDto cartItemDto)
        {
            try
            {
                var existingCartItem = _cartItemDal.Get(
                    x => x.UserId == cartItemDto.UserId
                    && x.ProductId == cartItemDto.ProductId
                    );
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += cartItemDto.Quantity;
                    _cartItemDal.Update(existingCartItem);
                    return new SuccessResult("CartItem updated successfully!");
                }
                else
                {
                    var newCartItem = _mapper.Map<CartItem>(cartItemDto);
                    _cartItemDal.Add(newCartItem);
                    return new SuccessResult("CartItem added successfully!");
                }
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public Result ClearCart(Guid userId)
        {
            try
            {
                var cartItems = _cartItemDal.GetAll(x => x.UserId == userId);
                if (cartItems.Count == 0)
                {
                    return new ErrorResult("No products found in your cart!");
                }
                foreach(var item in cartItems)
                {
                    _cartItemDal.Delete(item);
                }
                return new SuccessResult("Cart cleared successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }            
        }
        public Result Delete(Guid cartItemId)
        {
            try
            {
                var cartItem = _cartItemDal.Get(x => x.Id == cartItemId);
                if(cartItem == null)
                {
                    return new ErrorResult("CartItem not found!");
                }
                _cartItemDal.Delete(cartItem);
                return new SuccessResult("CartItem deleted successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public DataResult<List<CartItemDto>> GetListByUserId(Guid userId)
        {
            try
            {
                var cartItems = _cartItemDal.GetAll(x => x.UserId == userId);
                if (!cartItems.Any())
                {
                    return new ErrorDataResult<List<CartItemDto>>("cartItems not found!");
                }
                var cartItemDtos = _mapper.Map<List<CartItemDto>>(cartItems);
                return new SuccessDataResult<List<CartItemDto>>(cartItemDtos, "CartItems listed successfully!");
            }
            catch (Exception ex)
            {
                //return new ErrorDataResult<List<CartItemDto>>("Something went wrong!");
                throw new Exception("Something went wrong!", ex);    
            }
        }
    }
}
