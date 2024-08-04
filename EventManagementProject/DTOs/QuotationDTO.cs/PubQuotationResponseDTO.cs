namespace EventManagementProject.DTOs.QuotationDTO.cs
{
    public class PubQuotationResponseDTO
    {
        public int PublicQuotationRequestId { get; set; }

        public double QuotedAmount { get; set; }
        public string ResponseMessage { get; set; }
    }
}
