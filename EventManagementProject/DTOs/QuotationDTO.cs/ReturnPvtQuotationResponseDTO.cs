namespace EventManagementProject.DTOs.QuotationDTO.cs
{
    public class ReturnPvtQuotationResponseDTO : PvtQuotationResponseDTO
    {
        public int PrivateQuotationResponseId { get; set; }  
        public string EventName { get;set; }
        public bool AcceptedByYou { get; set; }
    }
}
