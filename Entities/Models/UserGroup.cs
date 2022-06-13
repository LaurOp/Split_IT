using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public UserGroup(int userId, User user, int groupId, Group group)
        {
            UserId = userId;
            User = user;
            GroupId = groupId;
            Group = group;
        }

        public UserGroup() { }
    }
}
