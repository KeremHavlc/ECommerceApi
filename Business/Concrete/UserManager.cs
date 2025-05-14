using AutoMapper;
using Business.Abstract;
using Core.Constans;
using Core.Dtos;
using Core.Utilities.HashingHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public Result Add(UserDto userDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(userDto.Password, out passwordHash, out passwordSalt);

            Guid defaultRoleId = RoleGuid.User;
            Guid assignedRoleId = userDto.RoleId ?? defaultRoleId;

            var newUser = _mapper.Map<User>(userDto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            _userDal.Add(newUser);
            return new SuccessResult("User added successfully");
        }
    }
}
