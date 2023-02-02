namespace TicketingSolution.Core
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