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

<<<<<<< Updated upstream
        public async Task<Expense> GetByGroupId(int groupId)
=======
        public async Task<List<Expense>> GetAllExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<List<Expense>> GetByGroupId(int groupId)
>>>>>>> Stashed changes
        {
            return await _context.Expenses.Where(e => e.GroupId == groupId).ToListAsync();
        }

        public async Task<Expense> GetByGroupIdAndByAmount(int groupId, float amount)
        {
            return await _context.Expenses.Where(e => e.GroupId == groupId && e.totalAmount == amount).FirstOrDefaultAsync();
        }

        public async Task<Expense> GetById(int id)
        {
            return await _context.Expenses.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Expense> GetByIdWithAmounts(int id)
        {
            return await _context.Expenses.Include(e => e.AmountsOwed).Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    }
}
