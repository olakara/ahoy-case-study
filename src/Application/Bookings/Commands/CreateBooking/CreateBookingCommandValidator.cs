using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.CreateBooking
{
    public sealed class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()
        {
            RuleFor( p => p.PaxCount).GreaterThanOrEqualTo(1).WithMessage("Person count for the stay is required");            
        }
    }
}
