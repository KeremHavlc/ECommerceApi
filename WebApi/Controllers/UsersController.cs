using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    { private readonly IUserService _userService;   
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("add")]
        public IActionResult AddUser([FromBody] UserDto userDto)
        {
            var result = _userService.Add(userDto);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpDelete("delete/{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            var result = _userService.Delete(userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpPut("update/{userId}")]
        public IActionResult UpdateUser([FromBody] UserDto userDto , Guid userId)
        {
            var result = _userService.Update(userDto, userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("getbyid/{userId}")]
        public IActionResult GetById(Guid userId)
        {
            var result = _userService.GetById(userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("getbyemail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
