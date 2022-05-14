using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Split_IT.Data;
using Split_IT.Entities;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.ExpenseRepository
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ProjectContext context) : base(context) { }

        public async Task<Expense> GetByGroupId(int id)
        {
            return await _context.Expenses.Where(e => e.GroupId == id).FirstOrDefaultAsync();
        }
    }
}
