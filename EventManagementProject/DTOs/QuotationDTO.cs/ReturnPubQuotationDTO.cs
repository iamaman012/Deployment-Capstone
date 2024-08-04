namespace EventManagementProject.DTOs.QuotationDTO.cs
{
    public class ReturnPubQuotationDTO : AddPubQuotationRequestDTO
    {
        public int PublicQuotationRequestId { get; set; }
        public string QuotationStatus { get; set; }

        public DateTime RequestedDate { get; set; }
    }
}
