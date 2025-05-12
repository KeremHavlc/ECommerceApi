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
        [HttpPost]
        public IActionResult Post(UserDto userDto)
        {
            var result = _userService.Add(userDto);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
