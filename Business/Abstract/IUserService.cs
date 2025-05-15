using Core.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        Result Add(UserDto userDto);
        Result Delete(Guid userId);
        Result Update(UserDto userDto , Guid userId);
        DataResult<UserDto> GetById(Guid userId);
        DataResult<List<UserDto>> GetAll();
        DataResult<UserDto> GetByEmail(string email);
    }
}
