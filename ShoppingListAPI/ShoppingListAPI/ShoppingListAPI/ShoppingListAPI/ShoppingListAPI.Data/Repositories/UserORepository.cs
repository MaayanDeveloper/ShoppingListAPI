using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListAPI.Data.Repositories
{
    public class UserORepository : IUserORepository
    {
        private readonly DataContext _context;
        public UserORepository(DataContext context)
        {
            _context = context;
        }
        public async Task<UserO> GetUserByIdAsync(int id)
        {
            return await _context.UserOs.FirstOrDefaultAsync(p => p.Identity == id);
        }
        public async Task<UserO> RegisterUserAsync(UserO user)
        {
            _context.UserOs.Add(user);
            await SaveAsync();
            return user;
        }
        public async Task<UserO> LoginAsync(string Email, string password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
                return null;
            var user = await _context.UserOs.FirstOrDefaultAsync(s => s.Email == Email && s.Password == password);
            return user;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
