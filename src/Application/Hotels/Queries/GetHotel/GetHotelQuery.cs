using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Queries.GetHotel
{
    public class GetHotelQuery : IRequest<HotelViewModel>
    {
        public int Id { get; set; }
    }

    public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, HotelViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HotelViewModel?> Handle(GetHotelQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Hotels.Include(x=> x.Photos)
                                        .Include(x=> x.Reviews)
                                        .Include(x=> x.Facilities)
                                        .AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            if (result != null)
            {
                return new HotelViewModel
                {
                    Address = result.Address,
                    Description = result.Description,
                    Facilities = result.Facilities.Any() ? result.Facilities.Select(x => new FacilitiesViewModel
                    {
                        IconUrl = x.IconUrl,
                        Title = x.Title
                    }).ToList() : new List<FacilitiesViewModel>(),
                    Id = result.Id,
                    Latitude = result.Latitude,
                    Logitude = result.Logitude,
                    Name = result.Name,
                    Photos = result.Photos.Any() ? result.Photos.Select(x => new PhotoViewModel
                    {
                        Url = x.Url,
                        Title = x.Title
                    }).ToList() : new List<PhotoViewModel>(),
                    PricePerNight = result.PricePerNight,
                    Rating = result.Rating,
                    ReviewCount = result.ReviewCount
                };
            }
            else 
            {
                return null;
            }       
        }
    }
}
