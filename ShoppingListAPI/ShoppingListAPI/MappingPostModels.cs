using AutoMapper;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Models;

namespace ShoppingListAPI
{
    public class MappingPostModels:Profile
    {
        public MappingPostModels()
        {
            CreateMap<ProductPostModels, Product>();
        }
    }
}
