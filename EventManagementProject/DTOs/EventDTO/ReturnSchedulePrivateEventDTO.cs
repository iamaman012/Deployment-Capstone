namespace EventManagementProject.DTOs.EventDTO
{
    public class ReturnSchedulePrivateEventDTO
    {
        public int ScheduledPrivateEventId { get; set; }
        public string EventName { get; set; }
        public double QuotatedAmount { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventTiming { get; set; }

        public string ResponseMessage { get; set; } 

        public string UserName { get; set; }

        public string UserEmail { get; set; }   

        public string VenueType { get; set; }

        public string Location { get; set; }
    }
}
