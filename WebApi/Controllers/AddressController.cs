using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost("add")]
        public IActionResult AddAddress(AddressDto addressDto)
        {
            var result = _addressService.Add(addressDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("delete/{addressId}")]
        public IActionResult DeleteAddress(Guid addressId)
        {
            var result = _addressService.Delete(addressId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("update/{adressId}")]
        public IActionResult UpdateAddress(Guid adressId, AddressDto addressDto)
        {
            var result = _addressService.Update(adressId, addressDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get/{userId}")]
        public IActionResult GetByUserId(Guid userId)
        {
            var result = _addressService.GetByUserId(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
