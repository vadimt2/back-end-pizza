﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface ICustomer
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


    }
}
