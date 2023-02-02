using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSolution.Core.Handler;
using TicketingSolution.Core.Model;
using Xunit;

namespace TicketingSolution.Core
{
    public class Ticket_Booking_Requet_Handler_Test
    {
        private readonly TicketBookingRequestHandler _handler;
        public Ticket_Booking_Requet_Handler_Test()
        {
            _handler = new TicketBookingRequestHandler();
        }

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

            //Act
            ServiceBookingResult Result = _handler.BookServece(BookingRequest);

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

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _handler.BookServece(null));

            Assert.Equal("bookingRequest", exception.ParamName);
        }
    }
}
