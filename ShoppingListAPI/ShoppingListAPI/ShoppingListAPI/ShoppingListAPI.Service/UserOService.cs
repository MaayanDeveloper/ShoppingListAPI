using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Repositories;
using ShoppingListAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Service
{
    public class UserOService : IUserOService
    {
        private readonly IUserORepository _userORepository;
        public UserOService(IUserORepository userORepository)
        {
            _userORepository = userORepository;
        }
        public async Task<UserO> GetUserByIdAsync(int id)
        {
            return await _userORepository.GetUserByIdAsync(id);
        }
        public async Task<UserO> RegisterUserAsync(UserO user)
        {
            return await _userORepository.RegisterUserAsync(user);
        }
        public async Task<UserO> LoginAsync(string username, string password)
        {
            return await _userORepository.LoginAsync(username, password);
        }
    }
}
