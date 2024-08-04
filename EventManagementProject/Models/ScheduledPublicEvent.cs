using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class ScheduledPublicEvent
    {
        [Key]
        public int ScheduledPublicEventId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int PublicQuotationRequestId { get; set; }
        public string UserEventName { get; set; }
       
        
        
        public int RemainingSeats { get; set; }
      
       
        public bool IsActive { get; set; }
        

        public User User { get; set; }
        public Event Event { get; set; }
        public PublicQuotationRequest PublicQuotationRequest { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}
