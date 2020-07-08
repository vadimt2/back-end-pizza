using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Common
{
    public class Order
    {
        public Order()
        {
            BellingAndShippInfo = new HashSet<BellingAndShippInfo>();

            OrderDetails = new HashSet<OrderDetails>();

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public int ShippingId { get; set; }

        [ForeignKey("ShippingId")]
        public Shipping Shipping { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Guid ConfirmationNumber { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }

        public string Note { get; set; }

        public float Tax { get; set; }

        [InverseProperty(nameof(Common.OrderDetails.Order))]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        [InverseProperty(nameof(Common.BellingAndShippInfo.Order))]
        public virtual ICollection<BellingAndShippInfo> BellingAndShippInfo { get; set; }

    }
}
