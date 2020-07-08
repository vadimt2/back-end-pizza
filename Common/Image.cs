using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public byte[] UploadedImage { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }
    }
}
