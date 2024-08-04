using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;

namespace EventManagementProject.Services
{
    public class PubQuotationRequestService : IPubQuotationRequestService
    {   private readonly IPubQuotationRequestRepository _pubQuotationRequestRepository;
        private readonly IEvent _eventService;

        public PubQuotationRequestService(IPubQuotationRequestRepository pubQuotationRequestRepository, IEvent eventService)
        {
            _pubQuotationRequestRepository = pubQuotationRequestRepository;
            _eventService = eventService;
        }
        public async Task AddPubQuotationRequest(AddPubQuotationRequestDTO pubQuotationRequestDto)
        {
            try
            {
                var eventId = await _eventService.GetEventIdByName(pubQuotationRequestDto.EventName);
                var newPubQuotationRequest = new PublicQuotationRequest
                {
                    EventId = eventId,
                    UserId = pubQuotationRequestDto.UserId,
                    EventName = pubQuotationRequestDto.EventName,
                    Host = pubQuotationRequestDto.Host,
                   

                    Description = pubQuotationRequestDto.Description,
                     TotalSeats = pubQuotationRequestDto.TotalSeats,
                     ImageURL = pubQuotationRequestDto.ImageURL,
                    TicketPrice = pubQuotationRequestDto.TicketPrice,
                    StartDate = pubQuotationRequestDto.StartDate,
                    EndDate = pubQuotationRequestDto.EndDate,
                    Timing = pubQuotationRequestDto.Timing,
                    Venue = pubQuotationRequestDto.Venue,
                    City = pubQuotationRequestDto.City,
                    CreatedDate = DateTime.Now,
                    QuotationStatus = "Pending",
                    LocationDetails = pubQuotationRequestDto.Location

                };
                await _pubQuotationRequestRepository.Add(newPubQuotationRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReturnPubQuotationDTO>> ReturnPubQuotation()
        {
            try
            {
                var responses = await _pubQuotationRequestRepository.GetAll();
                var returnResponses = responses.Select(response => new ReturnPubQuotationDTO
                { 
                    PublicQuotationRequestId= response.PublicQuotationRequestId,
                    UserId = response.UserId,
                    EventName = response.EventName,
                    Host = response.Host,
                    Description = response.Description,
                    TotalSeats = response.TotalSeats,
                    TicketPrice = response.TicketPrice,
                    StartDate = response.StartDate,
                    EndDate= response.EndDate,
                    Timing = response.Timing,
                    Venue = response.Venue,
                    City = response.City,
                    RequestedDate = response.CreatedDate,
                    QuotationStatus= response.QuotationStatus,
                    Location = response.LocationDetails

                });
                return returnResponses;
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
