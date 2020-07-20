﻿using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class Catrgories
    {
        public Catrgories()
        {
            CategoryItems = new HashSet<CategoryItems>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CategoryItems> CategoryItems { get; set; }
    }
}
