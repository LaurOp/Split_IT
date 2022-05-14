using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public List<UserGroup> Users { get; set; }
        public List<Expense> Expenses { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }

        public GroupDTO(Group group)
        {
            this.Id = group.Id;
            this.Users = new List<UserGroup>();
            this.Expenses = new List<Expense>();
            this.Name = group.Name;
            this.PhotoUrl = group.Name;
        }
    }
}
