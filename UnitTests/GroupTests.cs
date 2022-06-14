using Microsoft.EntityFrameworkCore;
using Split_IT.Data;
using Split_IT.Entities;
using Split_IT.Repositories.GroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class GroupTests
    {
        [Fact]
        public void GroupInitiallyHasNoUsers()
        {
            Group group = new Group();
            Console.WriteLine(group.ToString());
            Assert.Equal(0, group.Users.Count);

        }

        [Fact]
        public void GroupInitiallHasNoExpenses()
        {
            Group group = new Group();
            Console.WriteLine(group.ToString());
            Assert.Equal(0, group.Expenses.Count);

        }

        [Fact]
        public async Task GetAllGroupsWorkAsync()
        {
            IGroupRepository sut = GetInMemoryGroupRepository();

            var savedExpenses = await sut.GetAllGroups();

        }

        private IGroupRepository GetInMemoryGroupRepository()
        {
            DbContextOptions<ProjectContext> options;
            var builder = new DbContextOptionsBuilder<ProjectContext>();

            builder.UseInMemoryDatabase(databaseName: "database_name");
            options = builder.Options;

            ProjectContext DataContext = new ProjectContext(options);
            DataContext.Database.EnsureDeleted();
            DataContext.Database.EnsureCreated();
            return new GroupRepository(DataContext);
        }



    }

}
