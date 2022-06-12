using Application.Hotels.Queries.GetHotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    public class HotelController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelViewModel>> Get(int id)
        {
            return await Mediator.Send(new GetHotelQuery { Id = id });            
        }
    }
}
