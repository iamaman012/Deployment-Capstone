namespace EventManagementProject.DTOs.EventDTO
{
    public class ReturnSchedulePublicEventDTO
    {

        public int ScheduledPublicEventId { get; set; }
        public string EventName { get; set; }

        public string UserEventName { get; set; }

        public string HostName { get; set; }
        public double QuotatedAmount { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventTiming { get; set; }

        public string Description { get; set; }

        public string ResponseMessage { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string VenueType { get; set; }
        public int TotalSeats { get; set; }
        public double TicketPrice { get; set; } 

        public bool IsActive { get; set; }

        public int RemainingSeats { get; set; } 

        public string City { get; set; }

        public string ImageUrl { get; set; }
        public string Location { get; set; }
       


    }
}
