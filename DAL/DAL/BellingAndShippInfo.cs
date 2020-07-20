using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class BellingAndShippInfo
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
        public int BellingOrShipping { get; set; }
        public bool IsTheSame { get; set; }
        public bool IsSaved { get; set; }
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
    }
}
