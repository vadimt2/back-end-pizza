using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common
{
    public partial class Item
    {
        public Item()
        {
            Images = new HashSet<Image>();

            CategoryItems = new HashSet<CategoryItems>();

            SubItem = new HashSet<Item>();
        }
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        // It's a pizza and it can be in stock! but can be out of topping or soda (Drink)
        public int? QuantityInStock { get; set; }

        public bool Available { get; set; }

        public int? Discount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Total { get; set; }


        [ForeignKey("ParentItem")]
        public int? ParentItemId { get; set; }

        public virtual Item ParentItem { get; set; }

        [InverseProperty(nameof(Common.Item.ParentItem))]
        public virtual ICollection<Item> SubItem { get; set; }

        [InverseProperty(nameof(Common.Image.Item))]
        public virtual ICollection<Image> Images { get; set; }

      
        [InverseProperty(nameof(Common.CategoryItems
            .Item))]
        public virtual ICollection<CategoryItems> CategoryItems { get; set; }

        // Thumbnail image will be add

    }
}
