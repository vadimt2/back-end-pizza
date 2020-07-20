﻿using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
