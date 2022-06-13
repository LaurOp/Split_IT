using Split_IT.Data;
using Split_IT.Entities.Models;
using Split_IT.Repositories.GenericRepository;

namespace Split_IT.Repositories.FriendshipManager
{
    public class FriendshipRepository : GenericRepository<Friendship>, IFriendshipRepository
    {
        public FriendshipRepository(ProjectContext context) : base(context) { }
    }
}
