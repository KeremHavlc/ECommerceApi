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
            var existingUser = _userDal.Get(u => u.Email == userDto.Email);
            if (existingUser != null)
            {
                return new ErrorResult("User already exists!");
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(userDto.Password, out passwordHash, out passwordSalt);

            Guid defaultRoleId = RoleGuid.User;
            Guid assignedRoleId = userDto.RoleId ?? defaultRoleId;

            var newUser = _mapper.Map<User>(userDto);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            _userDal.Add(newUser);
            return new SuccessResult("User added successfully!");
        }

        public Result Delete(Guid userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            if (user == null)
            {
                return new ErrorResult("User not Found!");
            }
            _userDal.Delete(user);
            return new SuccessResult("User deleted successfully!");

        }

        public DataResult<List<UserDto>> GetAll()
        {
            var listUser = _userDal.GetAll();
            if (listUser == null)
            {
                return new ErrorDataResult<List<UserDto>>("Users not found!");
            }
            return new SuccessDataResult<List<UserDto>>(_mapper.Map<List<UserDto>>(listUser), "Users listed successfully!");
        }

        public DataResult<User> GetByEmail(string email)
        {
            var user = _userDal.Get(x => x.Email == email);
            if (user == null)
            {
                return new ErrorDataResult<User>("User not Found!");
            }
            return new SuccessDataResult<User>(user, "User found successfully!");
        }

        public DataResult<UserDto> GetById(Guid userId)
        {
            var user = _userDal.Get(x => x.Id == userId);
            if(user == null)
            {
                return new ErrorDataResult<UserDto>("User not Found!");
            }
            var userDto = _mapper.Map<UserDto>(user);
            return new SuccessDataResult<UserDto>(userDto, "User found successfully!");
        }

        public Result Update(UserDto userDto, Guid userId)
        {
            var existingUser = _userDal.Get(x => x.Id == userId);
            if (existingUser == null)
            {
                return new ErrorResult("User not found!");
            }
            existingUser.Name = userDto.Name;
            existingUser.Surname = userDto.Surname;
            existingUser.Email = userDto.Email;

            if (!string.IsNullOrWhiteSpace(userDto.Password))
            {
                HashingHelper.CreatePassword(userDto.Password, out var passwordHash, out var passwordSalt);
                existingUser.PasswordHash = passwordHash;
                existingUser.PasswordSalt = passwordSalt;
            }

            existingUser.RoleId = userDto.RoleId ?? RoleGuid.User;

            _userDal.Update(existingUser);

            return new SuccessResult("User updated successfully!");
        }

    }
}
