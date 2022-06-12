using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(p => p.Latitude).HasPrecision(18, 9);
            builder.Property(p => p.Logitude).HasPrecision(18, 9);
            builder.Property(p => p.PricePerNight).HasColumnType("money");

            builder.Ignore(p => p.Rating);
            builder.Ignore(p => p.ReviewCount);
        }
    }
}
