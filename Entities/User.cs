using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int PermissionLevel { get; set; }
        
        public string Username { get; set; }
        public string Password { get; set; }
        public float WalletFunds { get; set; }
        public float Owes { get; set; }
        public float Owed { get; set; }

        public ICollection<User> FriendList { get; set; }

        public ICollection<UserGroup> Groups { get; set; }


    }
}

public class MyInt
{
    public int Id { get; set; }
    public int Number { get; set; }
}