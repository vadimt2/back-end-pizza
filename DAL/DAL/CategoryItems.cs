using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class CategoryItems
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ItemId { get; set; }

        public virtual Catrgories Category { get; set; }
        public virtual Items Item { get; set; }
    }
}
