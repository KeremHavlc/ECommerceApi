using Core.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Result Register(RegisterDto registerDto);
        DataResult<Token> Login(LoginDto loginDto);
    }
}
