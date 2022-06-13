using Microsoft.AspNetCore.Identity;
using Proiect_final_DAW.Entities;
using Split_IT.Entities.Models;
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

        public virtual ICollection<Friendship> FriendWith{get; set; }
        public virtual ICollection<Friendship> FriendOf { get; set; }
        public ICollection<UserGroup> Groups { get; set; }
        public ICollection<AmountOwed> AmountsOwed { get; set; }

        public User()
        {
            FriendOf = new List<Friendship>();
            FriendWith = new List<Friendship>();
            Groups = new List<UserGroup>();
            AmountsOwed = new List<AmountOwed>();
        }


    }
}