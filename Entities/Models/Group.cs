using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public ICollection<UserGroup> Users { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }

        public Group()
        {
            Users = new List<UserGroup>();
            Expenses = new List<Expense>();
        }
    }
}
