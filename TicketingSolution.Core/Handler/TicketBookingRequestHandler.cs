using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler()
        {
        }

        public ServiceBookingResult BookServece(TicketBookingRequest bookingRequest)
        {
            var result = new ServiceBookingResult()
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email
            };

            return result;
        }
    }
}