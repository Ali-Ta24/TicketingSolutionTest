using Moq;
using Shouldly;
using TicketingSolution.Core.DataService;
using TicketingSolution.Core.Domain;
using TicketingSolution.Core.Enums;
using TicketingSolution.Core.Handler;
using TicketingSolution.Core.Model;
using Xunit;

namespace TicketingSolution.Core
{
    public class Ticket_Booking_Requet_Handler_Test
    {
        private readonly TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;
        private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;
        private List<Ticket> _availableTickets;

        public Ticket_Booking_Requet_Handler_Test()
        {
            //Arrange
            _request = new TicketBookingRequest
            {
                Name = "Test Name",
                Family = "Test Family",
                Email = "TestEmail",
                Date = DateTime.Now,
            };

            _availableTickets = new List<Ticket>() { new Ticket() { Id = 1 } };
            _ticketBookingServiceMock = new Mock<ITicketBookingService>();
            _ticketBookingServiceMock.Setup(q => q.GetAvailableTickets(_request.Date))
                .Returns(_availableTickets);

            _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);


        }

        [Fact]
        public void Should_Return_Ticket_Booking_Response_With_Request_Values()
        {
            //Act
            ServiceBookingResult Result = _handler.BookServece(_request);

            //Assert
            Assert.NotNull(Result);
            Assert.Equal(_request.Name, Result.Name);
            Assert.Equal(_request.Family, Result.Family);
            Assert.Equal(_request.Email, Result.Email);

            //Assert by shouldy
            Result.ShouldNotBeNull();
            _request.Name.ShouldBe(Result.Name);
            _request.Family.ShouldBe(Result.Family);
            _request.Email.ShouldBe(Result.Email);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _handler.BookServece(null));

            Assert.Equal("bookingRequest", exception.ParamName);
        }

        [Fact]
        public void Should_Save_Ticket_Booking_Request()
        {
            TicketBooking SavedBooking = null;
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>(booking =>
                {
                    SavedBooking = booking;
                });
            _handler.BookServece(_request);

            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);

            Assert.NotNull(SavedBooking);
            Assert.Equal(_request.Name, SavedBooking.Name);
            Assert.Equal(_request.Family, SavedBooking.Family);
            Assert.Equal(_request.Email, SavedBooking.Email);
            Assert.Equal(_availableTickets.First().Id, SavedBooking.TicketID);
        }

        [Fact]
        public void Should_Not_Save_Ticket_Booking_Request_If_None_Available()
        {
            _availableTickets.Clear();
            _handler.BookServece(_request);

            _ticketBookingServiceMock.Verify(s => s.Save(It.IsAny<TicketBooking>()), Times.Never);
        }

        [Theory]
        [InlineData(BookingResultFlag.Failure, false)]
        [InlineData(BookingResultFlag.Success, true)]
        public void Should_Return_SuccessOrFailure_Flag_In_Result(BookingResultFlag bookingSuccessFlag, bool isAvailable)
        {
            if(!isAvailable)
            {
                _availableTickets.Clear();
            }

            var result = _handler.BookServece(_request);
            Assert.Equal(bookingSuccessFlag, result.Flag);
        }
    }
}
