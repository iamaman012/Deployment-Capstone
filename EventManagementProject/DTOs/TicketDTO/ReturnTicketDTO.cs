namespace EventManagementProject.DTOs.TicketDTO
{
    public class ReturnTicketDTO
    {
        public int TicketId { get; set; }
        
        public string UserEventName { get; set; }

        public DateTime StartDate { get; set; }

        public string EventTiming { get; set; }

        public string Location { get; set; }    

        public string City { get; set; }

        public int TotalSeats { get; set; }

        public double TotalAmount { get; set; }

        public string PurchaseDate { get; set; }
    }
}
