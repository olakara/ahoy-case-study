using Application.Common.Interfaces;
using Application.Hotels.Extensions;
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
                return result.AsViewModel();
            }
            else 
            {
                return null;
            }       
        }
    }
}
