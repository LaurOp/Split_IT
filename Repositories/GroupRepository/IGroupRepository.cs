using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Split_IT.Entities;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.GroupRepository
{
    interface IGroupRepository : IGenericRepository<Group>
    {


        Task<Group> GetByName(string name);
        Task<List<Group>> GetAllGroups();
        Task<Group> GetById(int id);
        Task<Group> GetByIdWithAll(int id);
        Task<Group> GetByIdWithExpenses(int id);
        Task<Group> GetByIdWithUsers(int id);
       

    }
}
