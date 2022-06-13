using Application.Hotels.Queries.GetHotel;
using Application.Hotels.Queries.GetHotelsWithPagination;
using Domain.Entities;

namespace Application.Hotels.Extensions
{
    public static class Extensions
    {
        public static HotelListingViewModel AsListingViewModel(this Hotel hotel)
        {
            return new HotelListingViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                Rating = hotel.Rating,
                ReviewCount = hotel.Reviews.Count,
                PricePerNight = hotel.PricePerNight,
                PhotoUrl = hotel.Photos.FirstOrDefault(x => x.IsMain)?.Url
            };
        }

        public static HotelViewModel AsViewModel(this Hotel hotel)        
        {
            return new HotelViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                Address = hotel.Address,
                Logitude = hotel.Logitude,
                Latitude = hotel.Latitude,
                PricePerNight = hotel.PricePerNight,
                Rating = hotel.Rating,
                ReviewCount = hotel.Reviews.Count,
                Photos = hotel.Photos.Select(x => new PhotoViewModel
                    {
                        Url = x.Url,
                        Title = x.Title,
                        IsMain = x.IsMain,
                    }).ToList(),
                Facilities = hotel.Facilities.Select(x => new FacilitiesViewModel
                    {
                        IconUrl = x.IconUrl,
                        Title = x.Title
                    }).ToList()
            };
        }
    }
}