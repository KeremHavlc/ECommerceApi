using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("add")]
        public IActionResult AddOrder(OrderDto orderDto)
        {
            var result = _orderService.Add(orderDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("delete/{orderId}")]
        public IActionResult DeleteOrder(Guid orderId)
        {
            var result = _orderService.Delete(orderId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getAllOrdersByUser/{userId}")]
        public IActionResult GetAllOrdersByUser(Guid userId)
        {
            var result = _orderService.GetAllOrderByUser(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("updateAddress/{orderId}/{addressId}")]
        public IActionResult UpdateAddress(Guid orderId, Guid addressId)
        {
            var result = _orderService.UpdateAdress(orderId, addressId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("updateStatus/{orderId}")]
        public IActionResult UpdateStatus(Guid orderId)
        {
            var result = _orderService.UpdateStatus(orderId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
