namespace TicketingSolution.Domain
{
    public class TicketBooking : ServiceBookingBase
    {
        public static int Id { get; set; }
        public int TicketID { get; set; }

        public Ticket Ticket { get; set; }
    }
}