using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Facility : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public IList<Hotel> Hotels { get; set; }
    }
}
