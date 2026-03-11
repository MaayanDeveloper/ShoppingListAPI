using ShoppingListAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Core.Services
{
    public interface IUserOService
    {
        public Task<UserO> GetUserByIdAsync(int id);
        //Register
        public Task<UserO> RegisterUserAsync(UserO user);
        //login 
        public Task<UserO> LoginAsync(string username, string password);
    }
}
