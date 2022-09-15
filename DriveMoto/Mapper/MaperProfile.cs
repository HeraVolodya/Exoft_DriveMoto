using DriveMoto.Models;
using System.Security.Claims;
using AutoMapper;

namespace DriveMoto.Mapper
{
    public class MaperProfile : Profile
    {
        public MaperProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(t => t.Product, t => t.MapFrom(x => x.Product))
                .ForMember(t => t.Client, t => t.MapFrom(x => x.Client))
                .ReverseMap();
        }
    }
}
