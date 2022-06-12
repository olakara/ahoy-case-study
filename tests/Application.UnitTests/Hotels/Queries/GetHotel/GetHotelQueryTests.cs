using Application.Common.Interfaces;
using Application.Hotels.Queries.GetHotel;
using Application.UnitTests.MockData.Hotels.Queries;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Hotels.Queries.GetHotel
{
    public class GetHotelQueryTests
    {

        public GetHotelQueryTests()
        {

        }

        [Fact]
        public async Task GetHotelQueryShouldReturnHotelInformation()
        {
            // Arrange
            var mockContext = new Mock<IApplicationDbContext>();
            var handler = new GetHotelQueryHandler(mockContext.Object);

            // Act            
            var result = await handler.Handle(new GetHotelQuery { Id = 1 }, CancellationToken.None);

            // Assert        
            result.Should().NotBeNull();
            result.Should().BeOfType<HotelViewModel>();
            result.Should().BeEquivalentTo(HotelMockData.GetHotel());

        }
    }
}
