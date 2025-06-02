using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        [HttpPost("add")]
        public IActionResult AddOrderItem(Guid orderId)
        {
            var result = _orderItemService.Add(orderId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getAllOrderItemsByUser/{userId}/{orderId}")]
        public IActionResult GetAllOrderItem(Guid userId,Guid orderId)
        {
            var result = _orderItemService.GetAllOrderItem(userId,orderId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
