namespace EventManagementProject.DTOs.QuotationDTO.cs
{
    public class ReturnPubQuotationResponseDTO : PubQuotationResponseDTO
    {
        public int PublicQuotationResponseId { get; set; }
        public string EventName { get; set; }
        public bool AcceptedByYou { get; set; }

       

    }
}
