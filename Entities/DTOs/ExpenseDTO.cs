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
        public List<MyFloat> ratios { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public ExpenseDTO(Expense expense)
        {
            this.Id = expense.Id;
            this.totalAmount = expense.totalAmount;
            this.ratios = new List<MyFloat>();
            this.GroupId = expense.GroupId;
            this.Group = new Group();


        }
    }
}
