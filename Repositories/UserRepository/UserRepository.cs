using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Split_IT.Data;
using Split_IT.Entities;
using Split_IT.Repositories.ExpenseRepository;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context) { }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync(); 
        }

        public async Task<User> GetByIdWithAll(int id)
        {
            return await _context.Users.Include(u => u.AmountsOwed).Include(u => u.Groups).Include(u => u.FriendWith).Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdWithFriends(int id)
        {
            return await _context.Users.Include(u => u.FriendWith).Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdWithGroups(int id)
        {
            return await _context.Users.Include(u => u.Groups).Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdWithOwed(int id)
        {
            return await _context.Users.Include(u => u.AmountsOwed).Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByName(string name)
        {
            return await _context.Users.Where(u => u.Username.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
