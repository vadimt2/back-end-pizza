using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
