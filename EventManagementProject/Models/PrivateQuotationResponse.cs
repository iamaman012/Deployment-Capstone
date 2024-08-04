using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class PrivateQuotationResponse
    {
        [Key]
        public int PrivateQuotationResponseId { get; set; }
        public int PrivateQuotationRequestId { get; set; }
        public string RequestStatus { get; set; }
        public double QuotedAmount { get; set; }
        public string ResponseMessage { get; set; }
        public DateTime ResponseDate { get; set; }
        public bool IsAccepted { get; set; }

        public PrivateQuotationRequest PrivateQuotationRequest { get; set; }
    }
}
