using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure
{
    public class CustomerInfo
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Address { get; set; } // Can be also a class with Street,Num,City,state or Country

        public int? Floor { get; set; }

        public int? Apartment { get; set; }

        public int? BuldingEntry { get; set; }


    }
}
