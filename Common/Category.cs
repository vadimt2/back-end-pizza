using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Common
{
    public partial class Category
    {
        public Category()
        {
            //SubCategory = new HashSet<Category>();

        }
        
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        // Thumbnail image will be add


        //[ForeignKey("ParentCategory")]
        //public int? ParentCategoryId { get; set; }

        //public virtual ICollection<Category> SubCategory { get; set; }

        //public virtual Category ParentCategory { get; set; }
    }
}
