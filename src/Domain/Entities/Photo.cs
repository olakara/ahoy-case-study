using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Photo: BaseAuditableEntity
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public bool IsMain { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}
