using Core.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IAddressService
    {
        Result Add(AddressDto addressDto);
        Result Delete(Guid addressId);
        Result Update(Guid adressId, AddressDto addressDto);
        DataResult<List<AddressDto>> GetByUserId(Guid userId);
    }
}
