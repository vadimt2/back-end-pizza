using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class Items
    {
        public Items()
        {
            CategoryItems = new HashSet<CategoryItems>();
            Images = new HashSet<Images>();
            InverseParentItem = new HashSet<Items>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? QuantityInStock { get; set; }
        public bool Available { get; set; }
        public int? Discount { get; set; }
        public decimal? Total { get; set; }
        public int? ParentItemId { get; set; }

        public virtual Items ParentItem { get; set; }
        public virtual ICollection<CategoryItems> CategoryItems { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<Items> InverseParentItem { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
