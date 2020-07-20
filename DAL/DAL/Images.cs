using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class Images
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public byte[] UploadedImage { get; set; }
        public int ItemId { get; set; }

        public virtual Items Item { get; set; }
    }
}
