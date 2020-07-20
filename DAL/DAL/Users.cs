using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public bool IsRegistered { get; set; }
        public string Phone { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
