using AutoMapper;
using ShoppingListAPI.Core.DTO;
using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, productDTO>().ReverseMap();

        }
    }
}
