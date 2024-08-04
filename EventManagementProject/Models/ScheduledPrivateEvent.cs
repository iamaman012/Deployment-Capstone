using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class ScheduledPrivateEvent
    {
        [Key]
        public int ScheduledPrivateEventId { get; set; }
        public int EventId { get; set; }
        public int PrivateQuotationRequestId { get; set; }
        public int UserId { get; set; }

        public Event Event { get; set; }
        public PrivateQuotationRequest PrivateQuotationRequest { get; set; }
        public User User { get; set; }
    }
}
