using AutoMapper;
using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        public AddressManager(IAddressDal addressDal,IMapper mapper , IUserDal userDal)
        {
            _addressDal = addressDal;
            _mapper = mapper;
            _userDal = userDal;
        }
        public Result Add(AddressDto addressDto)
        {
            try
            {
                var existingAddress = _addressDal.Get(a => a.Title == addressDto.Title && a.UserId == addressDto.UserId);
                if(existingAddress != null)
                {
                    return new ErrorResult("Address Title already used!");
                }
                var newAddress = _mapper.Map<Address>(addressDto);
                _addressDal.Add(newAddress);
                return new SuccessResult("Address added successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }
        public Result Delete(Guid addressId)
        {
            try
            {
                var existingAddress = _addressDal.Get(a => a.Id == addressId);
                if(existingAddress == null)
                {
                    return new ErrorResult("Address not found!");
                }
                _addressDal.Delete(existingAddress);
                return new SuccessResult("Address deleted successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }

        public DataResult<List<AddressDto>> GetByUserId(Guid userId)
        {
            try
            {
                var existingUser = _userDal.Get(u => u.Id == userId);
                if(existingUser == null)
                {
                    return new ErrorDataResult<List<AddressDto>>("User not found!");
                }
                var addresses = _addressDal.GetAll(a => a.UserId == userId);
                if (addresses == null || addresses.Count == 0)
                {
                    return new ErrorDataResult<List<AddressDto>>("No addresses found for this user!");
                }
                var addressDtos = _mapper.Map<List<AddressDto>>(addresses);
                return new SuccessDataResult<List<AddressDto>>(addressDtos, "Addresses retrieved successfully!");
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<AddressDto>>("Something went wrong!");
            }
        }

        public Result Update(Guid adressId, AddressDto addressDto)
        {
            try
            {
                var existingAddress = _addressDal.Get(a => a.Id == adressId);
                if(existingAddress == null)
                {
                    return new ErrorResult("Address not found!");
                }
                var existingAddressWithSameTitle = _addressDal.Get(a => a.Title == addressDto.Title && a.Id != adressId);
                if (existingAddressWithSameTitle != null)
                {
                    return new ErrorResult("Address Title already used!");
                }
                var updatedAddress = _mapper.Map<Address>(addressDto);
                _addressDal.Update(updatedAddress);
                return new SuccessResult("Address updated successfully!");
            }
            catch (Exception)
            {
                return new ErrorResult("Something went wrong!");
            }
        }
    }
}
