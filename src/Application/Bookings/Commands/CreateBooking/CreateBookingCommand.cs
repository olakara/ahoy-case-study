using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<int>
    {
        public int HotelId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CustomerId { get; set; }
        public int PaxCount { get; set; }
    }

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Booking
            {
                CustomerId = request.CustomerId,
                HotelId = request.HotelId,
                CheckIn = request.CheckIn,
                CheckOut = request.CheckOut,
                PaxCount = request.PaxCount
            };

            _context.Bookings.Add(entity);

            var hotel = _context.Hotels.Single(x => x.Id == request.HotelId);
            hotel.RoomCount = hotel.RoomCount - 1;
            hotel.LastModified = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
