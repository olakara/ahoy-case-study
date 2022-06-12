using Application.Bookings.Commands.CreateBooking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    public class BookingController : ApiControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookingCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
