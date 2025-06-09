using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = _authService.Login(loginDto);
            if (result == null || !result.Success || result.Data == null)
            {
                return BadRequest(result);
            }

            return Ok(new
            {
                Success = result.Success,
                Message = result.Message,
                AccessToken = result.Data.AccessToken
            });
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var result = _authService.Register(registerDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            return Ok(new { Message = "Logged out successfully." });
        }
    }
}
