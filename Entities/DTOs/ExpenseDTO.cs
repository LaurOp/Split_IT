using Split_IT.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public float totalAmount { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<AmountOwed> AmountsOwed { get; set; }

        public ExpenseDTO(Expense expense)
        {
            this.Id = expense.Id;
            this.totalAmount = expense.totalAmount;
            this.GroupId = expense.GroupId;
            this.Group = new Group();
            this.AmountsOwed = new List<AmountOwed>();

        }
    }
}
