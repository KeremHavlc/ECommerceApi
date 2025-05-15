using Core.Dtos;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        Result Add(UserDto userDto);
        Result Delete(Guid userId);
        Result Update(UserDto userDto , Guid userId);
        DataResult<UserDto> GetById(Guid userId);
        DataResult<List<UserDto>> GetAll();
        DataResult<User> GetByEmail(string email);
    }
}
