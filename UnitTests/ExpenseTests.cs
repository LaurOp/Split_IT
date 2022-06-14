using Microsoft.EntityFrameworkCore;

using Split_IT.Data;
using Split_IT.Entities;
using Split_IT.Repositories.ExpenseRepository;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class ExpenseTests
    {
       
        [Fact]
        public void ExpenseIsInitializedAs0()
        {
            Expense expense = new Expense();
            Console.WriteLine(expense.ToString());
            Assert.Equal(0, expense.totalAmount);
        }

        [Fact]
        public void ExpenseInitiallyHasNoUsers()
        {
            Expense expense = new Expense();
            Console.WriteLine(expense.ToString());
            Assert.Equal(0, expense.AmountsOwed.Count);
        }

        [Fact]
        public async Task GetAllExpensesWorkAsync()
        {
            IExpenseRepository sut = GetInMemoryExpenseRepository();

            var savedExpenses = await sut.GetAllExpenses();

        }

        private IExpenseRepository GetInMemoryExpenseRepository()
        {
            DbContextOptions<ProjectContext> options;
            var builder = new DbContextOptionsBuilder<ProjectContext>();

            builder.UseInMemoryDatabase(databaseName: "database_name");
            options = builder.Options;

            ProjectContext DataContext = new ProjectContext(options);
            DataContext.Database.EnsureDeleted();
            DataContext.Database.EnsureCreated();
            return new ExpenseRepository(DataContext);
        }

    }
}
