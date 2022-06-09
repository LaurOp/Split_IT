namespace Split_IT.Entities.Models
{
    public class Friendship
    {
        public int FromId { get; set; }
        public int ToId { get; set; }


        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
    }
}
