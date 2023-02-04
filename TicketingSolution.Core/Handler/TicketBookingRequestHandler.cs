using TicketingSolution.Core.DataService;
using TicketingSolution.Core.Enums;
using TicketingSolution.Core.Model;
using TicketingSolution.Domain;

namespace TicketingSolution.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingService;

        public TicketBookingRequestHandler(ITicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }

        public ServiceBookingResult BookServece(TicketBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }
            var availableTickets = _ticketBookingService.GetAvailableTickets(bookingRequest.Date);
            var result = CreateTicketBookingObject<ServiceBookingResult>(bookingRequest);
            if (availableTickets.Any())
            {
                var Ticket = CreateTicketBookingObject<TicketBooking>(bookingRequest);
                Ticket.TicketID = availableTickets.First().Id;
                _ticketBookingService.Save(Ticket);
                result.Flag = BookingResultFlag.Success;
                result.TicketBookingId = availableTickets.First().Id;
            }
            else
            {
                result.Flag = BookingResultFlag.Failure;
            }
            return result;
        }

        private static TTicketBooking CreateTicketBookingObject<TTicketBooking>(TicketBookingRequest bookingRequest) where TTicketBooking
            : ServiceBookingBase, new()
        {
            return new TTicketBooking
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email
            };
        }
    }
}