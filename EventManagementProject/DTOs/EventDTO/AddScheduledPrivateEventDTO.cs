namespace EventManagementProject.DTOs.EventDTO
{
    public class AddScheduledPrivateEventDTO
    {
        public string EventName { get; set; }

        public int PrivateQuotationResponseId { get; set; }
        public int PrivateQuotationRequestId { get; set; }
        public int UserId { get; set; }
    }
}
