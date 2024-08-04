namespace EventManagementProject.DTOs.EventDTO
{
    public class AddScheduledPublicEventDTO
    {
        public string EventName { get; set; }

        public int PublicQuotationResponseId { get; set; }
        public int PublicQuotationRequestId { get; set; }
        public int UserId { get; set; }

        public string UserEventName { get; set; }

    }
}
