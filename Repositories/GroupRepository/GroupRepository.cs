using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Split_IT.Data;
using Split_IT.Entities;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.GroupRepository
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ProjectContext context) : base(context) { }

        public async Task<List<Group>> GetAllGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetById(int id)
        {
            return await _context.Groups.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Group> GetByIdWithAll(int id)
        {
            return await _context.Groups.Include(g => g.Users).Include(g => g.Expenses).Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Group> GetByIdWithExpenses(int id)
        {
            return await _context.Groups.Include(g => g.Expenses).Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Group> GetByIdWithUsers(int id)
        {
            return await _context.Groups.Include(g => g.Users).Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Group> GetByName(string name)
        {
            return await _context.Groups.Where(g => g.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
