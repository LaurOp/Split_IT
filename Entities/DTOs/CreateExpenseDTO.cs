namespace Split_IT.Entities.DTOs
{
    public class CreateExpenseDTO
    {
        public float totalAmount { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
