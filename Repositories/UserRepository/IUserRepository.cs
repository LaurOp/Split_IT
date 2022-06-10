using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Split_IT.Entities;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByName(string name);
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> GetByIdWithAll(int id);
        Task<User> GetByIdWithOwed(int id);
        Task<User> GetByIdWithFriends(int id);
        Task<User> GetByIdWithGroups(int id);
    }
}
