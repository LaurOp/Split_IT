namespace Split_IT.Entities.Models
{
    public class Friendship
    {
        public int FromId { get; set; }
        public int ToId { get; set; }


        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }


        public Friendship(int fromId, int toId, User userFrom, User userTo)
        {
            FromId = fromId;
            ToId = toId;
            UserFrom = userFrom;
            UserTo = userTo;
        }

        public Friendship()
        {

        }
    }
}
