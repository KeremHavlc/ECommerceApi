using AutoMapper;
using Core.Dtos;
using Entity.Concrete;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User , UserDto>().ReverseMap();
        }
    }
}
