using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; }
        DbSet<Customer> Customers { get; }
        DbSet<Facility> Facilities { get; }
        DbSet<Hotel> Hotels { get; }
        DbSet<Photo> Photos { get; }
        DbSet<Review> Reviews { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
