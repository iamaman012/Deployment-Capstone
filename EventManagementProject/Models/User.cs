using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace EventManagementProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public UserCredential UserCredential { get; set; }
        public ICollection<PrivateQuotationRequest> PrivateQuotationRequests { get; set; }
        public ICollection<ScheduledPrivateEvent> ScheduledPrivateEvents { get; set; }
        public ICollection<PublicQuotationRequest> PublicQuotationRequests { get; set; }
        public ICollection<ScheduledPublicEvent> ScheduledPublicEvents { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
