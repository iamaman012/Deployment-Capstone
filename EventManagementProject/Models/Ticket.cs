using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int ScheduledPublicEventId { get; set; }
        public int UserId { get; set; }
        public int NumberOfSeats { get; set; }
        public double Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; }

        public ScheduledPublicEvent ScheduledPublicEvent { get; set; }
        public User User { get; set; }
    }
}
