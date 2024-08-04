using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class PublicQuotationResponse
    {
        [Key]
        public int PublicQuotationResponseId { get; set; }
        public int PublicQuotationRequestId { get; set; }
        public string RequestStatus { get; set; }
        public double QuotedAmount { get; set; }
        public string ResponseMessage { get; set; }
        public DateTime ResponseDate { get; set; }
        public bool IsAccepted { get; set; }

        public PublicQuotationRequest PublicQuotationRequest { get; set; }
    }
}
