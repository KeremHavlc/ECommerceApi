using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        [HttpPost("add")]
        public IActionResult AddCartItem(CartItemDto cartItemDto)
        {
            var result = _cartItemService.Add(cartItemDto);
            return result.Success
                ? Ok(result) 
                : BadRequest(result);
        }
        [HttpDelete("delete/{cartItemId}")]
        public IActionResult Delete(Guid cartItemId)
        {
            var result = _cartItemService.Delete(cartItemId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpDelete("clearCart/{userId}")]
        public IActionResult ClearCart(Guid userId)
        {
            var result = _cartItemService.ClearCart(userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("getbyUserId/{userId}")]
        public IActionResult GetByUserId(Guid userId)
        {
            var result = _cartItemService.GetListByUserId(userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
