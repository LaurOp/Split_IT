namespace Split_IT.Entities.Models
{
    public class AmountOwed
    {
        public int Id { get; set; }
        public int Amount{get;set;}

        public int ExpenseId { get;set;}
        public Expense Expense {get;set;}
        
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
