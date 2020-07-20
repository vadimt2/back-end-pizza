using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class Orders
    {
        public Orders()
        {
            BellingAndShippInfo = new HashSet<BellingAndShippInfo>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShippingId { get; set; }
        public int UserId { get; set; }
        public Guid ConfirmationNumber { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
        public float Tax { get; set; }

        public virtual Shipping Shipping { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<BellingAndShippInfo> BellingAndShippInfo { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
