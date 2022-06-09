using Split_IT.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int PermissionLevel { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public float WalletFunds { get; set; }
        public float Owes { get; set; }
        public float Owed { get; set; }


        public List<Friendship> FriendWith { get; set; }
        public List<Friendship> FriendOf { get; set; }
        public List<UserGroup> Groups { get; set; }
        public List<AmountOwed> AmountsOwed { get; set; }


        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.PermissionLevel = user.PermissionLevel;
            this.Username = user.Username;
            this.Password = user.Password;
            this.WalletFunds = user.WalletFunds;
            this.Owes = user.Owes;
            this.Owed = user.Owed;
            this.FriendWith = new List<Friendship>();
            this.FriendOf = new List<Friendship>();
            this.Groups = new List<UserGroup>();
            this.AmountsOwed = new List<AmountOwed>();
        }
    }
}
