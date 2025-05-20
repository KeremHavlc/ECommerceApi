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
        public IActionResult AddOrderItem(OrderItemDto orderItemDto)
        {
            var result = _orderItemService.Add(orderItemDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }   
    }
}
