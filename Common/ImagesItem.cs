using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common
{
    public class ImagesItem
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Image")]
        //public int ImageId { get; set; }

        //[ForeignKey("Item")]
        //public int ItemId { get; set; }

        //public virtual Image Image { get; set; }

        //public virtual Item Item { get; set; }
    }
}
