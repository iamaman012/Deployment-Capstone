namespace EventManagementProject.DTOs.QuotationDTO.cs
{
    public class AddPubQuotationRequestDTO
    {
        
        public int UserId { get; set; }
        public string EventName { get; set; }
        public string Host { get; set; }
        public string Description { get; set; }
       
        public int TotalSeats { get; set; }
        public string? ImageURL { get; set; }
        public double TicketPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Timing { get; set; }
        public string Venue { get; set; }
        
        public string City { get; set; }

        public string Location { get; set; }
    }
}
