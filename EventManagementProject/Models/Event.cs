using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageURL { get; set; }
        public string EventType { get; set; }
        public string Theme { get; set; }

        public ICollection<PrivateQuotationRequest> PrivateQuotationRequests { get; set; }
        public ICollection<PublicQuotationRequest> PublicQuotationRequests { get; set; }
    }
}
