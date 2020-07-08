using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common
{
    public class BellingAndShippInfo
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int? Zip { get; set; }

        public BellingOrShipping BellingOrShipping { get; set; }

        public bool IsTheSame { get; set; }

        // for registered users only!
        public bool IsSaved { get; set; }

        //public int? Floor { get; set; }

        //public int? Apartment { get; set; }

        //public string BuldingEntry { get; set; 

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }


    public enum BellingOrShipping
    {
        Belling,
        Shipping
    }
}

