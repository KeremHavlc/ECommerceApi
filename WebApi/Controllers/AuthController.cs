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

            Response.Cookies.Append("authToken", result.Data.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });
            return Ok(result);
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var result = _authService.Register(registerDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
