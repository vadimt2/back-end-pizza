using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Common
{
    public class Image
    {
 
        [Key]
        public virtual int Id { get; set; }

        public string ImageData { get; set; }

        public bool IsUrl { get; set; }

        [Required]
        [ForeignKey("Item")]
        public virtual int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }


    }
}

