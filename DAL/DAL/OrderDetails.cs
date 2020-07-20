using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Items Item { get; set; }
        public virtual Orders Order { get; set; }
    }
}
