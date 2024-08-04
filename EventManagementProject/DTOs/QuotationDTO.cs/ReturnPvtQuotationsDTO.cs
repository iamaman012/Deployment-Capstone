namespace EventManagementProject.DTOs.QuotationDTO.cs
{
    public class ReturnPvtQuotationsDTO :AddPvtQuotationRequestDTO
    {
        public int PrivateQuotationRequestId { get; set; }
        public string QuotationStatus { get; set; }

        public string EventName { get; set; }


        public DateTime RequestedDate { get; set; }
    }
}
