using AutoMapper;
using ShoppingListAPI.Core.DTO;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Models;

namespace ShoppingListAPI
{
    public class MappingPostModels:Profile
    {
        public MappingPostModels()
        {
            CreateMap<ProductPostModels, Product>();
            CreateMap<Product, productDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ProductInLIst, ProductInListDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<ShopListPostModel, ShopList>();
            CreateMap<ShopList, shopListDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key));

            CreateMap<UserPostModel, UserO>();
            CreateMap<UserO, UserDTO>();
            CreateMap<LoginPostModel, UserO>();

            CreateMap<ShopList, shopListNamesDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key));

            CreateMap<ProductInListPostModel, ProductInLIst>();
            CreateMap<ProductInLIst, ProductInListDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
