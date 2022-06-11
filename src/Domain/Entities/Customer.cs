﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Review> Reviews { get; private set; }

        public Customer()
        {
            Reviews = new List<Review>();
        }
    }
}
