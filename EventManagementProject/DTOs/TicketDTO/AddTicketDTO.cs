namespace EventManagementProject.DTOs.TicketDTO
{
    public class AddTicketDTO
    {
        public int ScheduledPublicEventId { get; set; }
        public int UserId { get; set; }
        public int NumberOfSeats { get; set; }
        public double Amount { get; set; }
       
       
    }
}
