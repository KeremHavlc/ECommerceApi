using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Result Add(UserDto userDto)
        {
            User user = new()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email
            };
            _userDal.Add(user);
            return new SuccessResult("User added successfully");
        }
    }
}
