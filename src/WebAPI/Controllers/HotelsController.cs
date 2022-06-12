using Application.Common.Models;
using Application.Hotels.Queries.GetHotelsWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HotelsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<PaginatedList<HotelListingViewModel>>> Search(GetHotelsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
