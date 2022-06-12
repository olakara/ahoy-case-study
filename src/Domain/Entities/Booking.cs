using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking : BaseAuditableEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int PaxCount { get; set; }
    }
}
