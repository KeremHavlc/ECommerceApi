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
            CreateMap<RegisterDto,User>();
            CreateMap<LoginDto, User>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<CartItemDto, CartItem>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
