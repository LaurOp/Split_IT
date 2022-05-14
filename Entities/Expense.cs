using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Split_IT.Entities;

namespace Split_IT.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public float totalAmount { get; set; }
        public ICollection<MyFloat> ratios { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        
    }
}
public class MyFloat
{
    public int Id { get; set; }
    public float Number { get; set; }
    public User User { get; set; }
}