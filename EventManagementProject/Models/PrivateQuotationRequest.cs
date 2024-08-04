using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class PrivateQuotationRequest
    {
        [Key]
        public int PrivateQuotationRequestId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int ExpectedPeopleCount { get; set; }
        public string VenueType { get; set; }
        public string LocationDetails { get; set; }
        public string FoodPreference { get; set; }
        public string CateringInstructions { get; set; }
        public string SpecialInstructions { get; set; }
        public string QuotationStatus { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventTiming { get; set; }
        public DateTime RequestedDate { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
        public PrivateQuotationResponse PrivateQuotationResponse { get; set; }
        public ScheduledPrivateEvent ScheduledPrivateEvent { get; set; }
    }
}
