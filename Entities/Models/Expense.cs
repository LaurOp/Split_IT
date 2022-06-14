using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Split_IT.Entities;
using Split_IT.Entities.Models;

namespace Split_IT.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public float totalAmount { get; set; }
        public ICollection<AmountOwed> AmountsOwed { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

       public Expense(int id, float totalAmount, ICollection<AmountOwed> amountsOwed, int groupId, Group group)
        {
            Id = id;
            this.totalAmount = totalAmount;
            AmountsOwed = amountsOwed;
            GroupId = groupId;
            Group = group;
        }

        public Expense()
        {
            this.totalAmount = 0;
            this.AmountsOwed = new List<AmountOwed>();
        }
    }
}
