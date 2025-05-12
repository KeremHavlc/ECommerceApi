using Core.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        Result Add(UserDto userDto);
    }
}
