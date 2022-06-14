using Split_IT.Data;
using Split_IT.Entities;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.UserGroupRepository
{
    public class UserGroupRepository :  GenericRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(ProjectContext context) : base(context) { }
    }
}
