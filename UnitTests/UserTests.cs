using Microsoft.EntityFrameworkCore;
using Split_IT.Data;
using Split_IT.Entities;
using Split_IT.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UserTests
    {
        [Fact]
        public void NewUserHasNoFriends()
        {
            User user = new User();
            Console.WriteLine(user.ToString());
            Assert.Equal(0, user.FriendWith.Count);

        }

        [Fact]
        public void NewUserIsNoOnesFriend()
        {

            User user = new User();
            Console.WriteLine(user.ToString());
            Assert.Equal(0, user.FriendOf.Count);

        }

        [Fact]
        public void NewUserHasNoGroups()
        {

            User user = new User();
            Console.WriteLine(user.ToString());
            Assert.Equal(0, user.Groups.Count);
        }

        [Fact]
        public void NewUserHasNoExpenses()
        {

            User user = new User();
            Console.WriteLine(user.ToString());
            Assert.Equal(0, user.AmountsOwed.Count);
        }


        [Fact]
        public async Task GetAllUsersWorkAsync()
        {
            IUserRepository sut = GetInMemoryUserRepository();

            var savedExpenses = await sut.GetAllUsers();

        }

        private IUserRepository GetInMemoryUserRepository()
        {
            DbContextOptions<ProjectContext> options;
            var builder = new DbContextOptionsBuilder<ProjectContext>();

            builder.UseInMemoryDatabase(databaseName: "database_name");
            options = builder.Options;

            ProjectContext DataContext = new ProjectContext(options);
            DataContext.Database.EnsureDeleted();
            DataContext.Database.EnsureCreated();
            return new UserRepository(DataContext);
        }
    }
}
