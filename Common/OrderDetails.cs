using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        // Item will have a price at the item and a sell price here
        [Column(TypeName = "decimal(18,4)")]
        public decimal SellPrice { get; set; }

        // Quantity that will be sold
        public int Quantity { get; set; }

    }
}
