using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Hotels.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Queries.GetHotelsWithPagination
{
    public class GetHotelsWithPaginationQuery : IRequest<PaginatedResult<HotelListingViewModel>>
    {
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetHotelsWithPaginationQueryHandler : IRequestHandler<GetHotelsWithPaginationQuery, PaginatedResult<HotelListingViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelsWithPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<HotelListingViewModel>> Handle(GetHotelsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Hotels.Include(x => x.Photos)
                                        .AsNoTracking().Where(x => x.Name.Contains(request.SearchTerm) ||
                                                            x.Description.Contains(request.SearchTerm));

            var paginatedResult = await PaginatedList<Hotel>.CreateAsync(query, request.PageNumber, request.PageSize);

            return new PaginatedResult<HotelListingViewModel>(paginatedResult.Items.Select(x => x.AsListingViewModel()).ToList(),
                                                                paginatedResult.PageNumber,
                                                                paginatedResult.TotalPages, 
                                                                paginatedResult.TotalCount);
            
        }
    }
}
