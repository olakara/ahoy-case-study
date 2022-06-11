using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public decimal Logitude { get; set; }
        public decimal Latitude { get; set; }

        public decimal PricePerNight { get; set; }

        public IList<Photo> Photos { get; set; }

        public IList<Review> Reviews { get; set; }

        public IList<Facility> Facities { get; set; }
    }
}
