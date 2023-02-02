using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSolution.Core.Model;
using Xunit;

namespace TicketingSolution.Core
{
    public class Ticket_Booking_Requet_Handler_Test
    {
        [Fact]
        public void Should_Return_Ticket_Booking_Response_With_Request_Values()
        {
            //Arrange
            var BookingRequest = new TicketBookingRequest
            {
                Name = "Test Name",
                Family = "Test Family",
                Email = "TestEmail"
            };

            var Handler = new TicketBookingRequestHandler();

            //Act
            ServiceBookingResult Result = Handler.BookServece(BookingRequest);

            //Assert
            Assert.NotNull(Result);
            Assert.Equal(BookingRequest.Name, Result.Name);
            Assert.Equal(BookingRequest.Family, Result.Family);
            Assert.Equal(BookingRequest.Email, Result.Email);

            //Assert by shouldy
            Result.ShouldNotBeNull();
            BookingRequest.Name.ShouldBe(Result.Name);
            BookingRequest.Family.ShouldBe(Result.Family);
            BookingRequest.Email.ShouldBe(Result.Email);
        }
    }
}
