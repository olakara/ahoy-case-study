using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Queries.GetHotelsWithPagination
{
    public class GetHotelsWithPaginationQuery : IRequest<PaginatedList<HotelListingViewModel>>
    {
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetHotelsWithPaginationQueryHandler : IRequestHandler<GetHotelsWithPaginationQuery, PaginatedList<HotelListingViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelsWithPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<HotelListingViewModel>> Handle(GetHotelsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Hotels.Include(x => x.Photos)
                                        .AsNoTracking().Where(x => x.Name.Contains(request.SearchTerm) ||
                                                            x.Description.Contains(request.SearchTerm)).ToListAsync();
            return null;
        }
    }
}
