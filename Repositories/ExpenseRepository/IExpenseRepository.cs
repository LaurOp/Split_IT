using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Split_IT.Entities;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.ExpenseRepository
{


    public interface IExpenseRepository : IGenericRepository<Expense>
    {

        Task<List<Expense>> GetAllExpenses();
        Task<List<Expense>> GetByGroupId(int groupId);

        Task<Expense> GetById(int id);
        Task<Expense> GetByIdWithAmounts(int id);
        Task<Expense> GetByGroupIdAndByAmount(int groupId, float amount);

    }
}
