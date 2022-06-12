using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Queries.GetHotel
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public decimal Logitude { get; set; }
        public decimal Latitude { get; set; }

        public decimal PricePerNight { get; set; }
        public float Rating { get; set; }
        public int ReviewCount { get; set; }

        public List<PhotoViewModel> Photos { get; set; }
        public List<FacilitiesViewModel> Facilities { get; set; }

        public HotelViewModel()
        {
            Photos = new List<PhotoViewModel>();
            Facilities = new List<FacilitiesViewModel>();
        }

    }
}
