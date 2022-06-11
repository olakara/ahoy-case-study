using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review : BaseAuditableEntity
    {
        public string ReviewText { get; set; }
        public int Rating { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        
    }
}
