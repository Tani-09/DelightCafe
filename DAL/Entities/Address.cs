﻿using System;
using System.Collections.Generic;

namespace Cafe_Delight.DAL.Entities
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Pincode { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Landmark { get; set; } = null!;
        public int UserId { get; set; }

        public virtual Customer User { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
