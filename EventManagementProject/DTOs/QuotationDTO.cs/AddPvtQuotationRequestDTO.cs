namespace EventManagementProject.DTOs.QuotationDTO.cs
{
    public class AddPvtQuotationRequestDTO
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int ExpectedPeopleCount { get; set; }
        public string VenueType { get; set; }
        public string LocationDetails { get; set; }
        public string FoodPreference { get; set; }
        public string CateringInstructions { get; set; }
        public string SpecialInstructions { get; set; }
        
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventTiming { get; set; }
    }
}
