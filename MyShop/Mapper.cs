using AutoMapper;
using Entities;
using DTO;
namespace MyShop
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Category, getCategoryDto>();
            CreateMap<Order, OrderDTO>();
            CreateMap< OrderDTO,Order > ();
            CreateMap<Product, ProductDto>();
            CreateMap< UserDTO,User > ();
            CreateMap<OrderPostDTO, Order>();
            CreateMap<User, ReturnPostUserDTO>();
            CreateMap<OrderItemDto, OrderItem>();
            //CreateMap<User, LoginUserDTO>();
            CreateMap<User, ReturnLoginUserDTO>();
        }
    }
}

