using Application.Hotels.Queries.GetHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.MockData.Hotels.Queries
{
    public static class HotelMockData
    {
        public static HotelViewModel GetHotel() {
            return new HotelViewModel
            {
                Address = "1651 Selah Way, Brattleboro, Vermont",               
                Description = "A sample description",
                Latitude = 42.859531m,
                Logitude = -72.607193m,
                Name = "Richman Brothers",
                PricePerNight = 27                
            };
        }
    }
}
