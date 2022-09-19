using DriveMoto.Models;
using System.Security.Claims;
using AutoMapper;
using DriveMoto.Models.DTOs;

namespace DriveMoto.Mapper
{
    public class MaperProfile : Profile
    {
        public MaperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            //CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(t => t.Product, t => t.MapFrom(x => x.Product))
                .ForMember(t => t.User, t => t.MapFrom(x => x.User))
                .ReverseMap();
        }
    }
}
