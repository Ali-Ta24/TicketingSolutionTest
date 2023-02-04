using TicketingSolution.Core.Enums;
using TicketingSolution.Domain;

namespace TicketingSolution.Core.Model
{
    public class ServiceBookingResult : ServiceBookingBase
    {
        public BookingResultFlag Flag { get; set; }
        public int TicketBookingId { get; set; }
    }
}