using AutoMapper;
using Business.Abstract;
using Core.Constans;
using Core.Dtos;
using Core.Utilities.HashingHelper;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;


        public AuthManager(IUserService userService , ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }
        public DataResult<Token> Login(LoginDto loginDto)
        {
            var user = _userService.GetByEmail(loginDto.Email);
            if (user == null || !user.Success || user.Data == null)
            {
                return new ErrorDataResult<Token>("User Not Found!");
            }
            var result = HashingHelper.VerifyPassowrd(loginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt);
            if (!result)
            {
                return new ErrorDataResult<Token>("Incorrect Password!");
            }
            var token = _tokenHandler.CreateToken(user.Data.Id, user.Data.Email, user.Data.RoleId.ToString());
            return new SuccessDataResult<Token>(token,"Login Successfully!");
        }
        public Result Register(RegisterDto registerDto)
        {
            Guid defaultRoleId = RoleGuid.User;
            Guid assignedRoleId = registerDto.RoleId ?? defaultRoleId;
            
            var userDto = new UserDto
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                Password = registerDto.Password,
                RoleId = assignedRoleId,
            };

            try
            {
                var result = _userService.Add(userDto);
                return new SuccessResult("User registered successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("User registration failed!");
            }

        }
    }
}
