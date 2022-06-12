using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Seed, if necessary
            if (!_context.Facilities.Any())
            {
                _context.Facilities.Add(new Domain.Entities.Facility
                {  
                    Title = "Breakfast",
                    IconUrl = "assets/icons/breakfast.png"
                });

                _context.Facilities.Add(new Domain.Entities.Facility
                {
                    Title = "Wifi",
                    IconUrl = "assets/icons/wifi.png"
                });

                _context.Facilities.Add(new Domain.Entities.Facility
                {
                    Title = "Parking",
                    IconUrl = "assets/icons/parking.png"
                });

                _context.Facilities.Add(new Domain.Entities.Facility
                {
                    Title = "Spa",
                    IconUrl = "assets/icons/spa.png"
                });
            }

            await _context.SaveChangesAsync();

            var spa = _context.Facilities.Single(x => x.Title == "Spa");


            //_context.Hotels.Add(new Domain.Entities.Hotel
            //{
            //    Address = "666 Archwood Avenue, Pinedale",
            //    Created = DateTime.Now,
            //    CreatedBy = "System",
            //    Description = "A sample description",                   
            //    Latitude = 42.859531m,
            //    Logitude = -72.607193m,
            //    Name = "Gene Walters Home",
            //    PricePerNight = 27,    
            //    Facilities = {
            //        new Domain.Entities.Facility { Title="Sample", IconUrl = "test.jpg" },
            //        spa
            //    }
            //});

            //_context.Photos.Add(new Domain.Entities.Photo
            //{
            //    Created = DateTime.Now,
            //    CreatedBy = "System",
            //    HotelId = 2,                   
            //    Title = "Main Photo",
            //    Url = "assets/photos/sample1.jpg"
            //});

            //_context.Photos.Add(new Domain.Entities.Photo
            //{
            //    Created = DateTime.Now,
            //    CreatedBy = "System",
            //    HotelId = 2,                   
            //    Title = "Spa Area",
            //    Url = "assets/photos/sample.jpg"
            //});                
           

            //await _context.SaveChangesAsync();


            
          
            //_context.Reviews.Add(new Domain.Entities.Review
            //{
            //    CustomerId = 1,
            //    HotelId = 2,                    
            //    Rating = 5,
            //    ReviewText = "Best Hotel ever"
            //});
            

            await _context.SaveChangesAsync();            
        }

    }
}
