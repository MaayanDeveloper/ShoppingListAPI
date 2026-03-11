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
            CreateMap<Product, productDTO>();

            CreateMap<ShopListPostModel, ShopList>();
            CreateMap<ShopList, shopListDTO>();

            CreateMap<UserPostModel, UserO>();
            CreateMap<UserO, UserDTO>();
            CreateMap<LoginPostModel, UserO>();
        }
    }
}
