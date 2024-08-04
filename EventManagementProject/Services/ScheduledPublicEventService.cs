using EventManagementProject.DTOs.EventDTO;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using System.Linq.Expressions;

namespace EventManagementProject.Services
{
    public class ScheduledPublicEventService : IScheduledPublicEventService
    {  
        private readonly IScheduledPublicEventRepository _scheduledPublicEventRepository;
        private readonly IEvent _eventService;
        private readonly IPubQuotationRequestRepository _pubQuotationRequestRepository;
        private readonly IPubQuotationResponseRepository _pubQuotationResponseRepository;

        public ScheduledPublicEventService(IScheduledPublicEventRepository scheduledPublicEventRepository,IEvent eventService,
            IPubQuotationRequestRepository pubQuotationRequestRepository,IPubQuotationResponseRepository pubQuotationResponseRepository)
        {
                _scheduledPublicEventRepository = scheduledPublicEventRepository;
            _eventService = eventService;
            _pubQuotationRequestRepository = pubQuotationRequestRepository;
            _pubQuotationResponseRepository = pubQuotationResponseRepository;
        }
        public async Task AddScheduledPublicEvent(AddScheduledPublicEventDTO scheduledPublicEventDTO)
        {
            try
            {
                var eventid = await _eventService.GetEventIdByName(scheduledPublicEventDTO.EventName);
                var remainingSeats = await _pubQuotationRequestRepository.GetTotalSeats(scheduledPublicEventDTO.PublicQuotationRequestId);


                var ScheduledEvent =  new ScheduledPublicEvent
                {
                    EventId = eventid,
                    UserId = scheduledPublicEventDTO.UserId,

                    
                    PublicQuotationRequestId = scheduledPublicEventDTO.PublicQuotationRequestId,
                    RemainingSeats = remainingSeats,

                    UserEventName = scheduledPublicEventDTO.UserEventName,
                    IsActive = true,

                };
                await _scheduledPublicEventRepository.Add(ScheduledEvent);
                await _pubQuotationResponseRepository.ResponseAcceptedByUser(scheduledPublicEventDTO.PublicQuotationResponseId);



            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<IEnumerable<ReturnSchedulePublicEventDTO>> GetAllScheduledPublicEvent()
        {
            try
            {
                var scheduledEvents = await _scheduledPublicEventRepository.GetAllScheduledPublicEvents();
                var publicScheduledEvents = scheduledEvents.Select(scheduledEvent => new ReturnSchedulePublicEventDTO
                {
                    ScheduledPublicEventId = scheduledEvent.ScheduledPublicEventId,
                    EventName = scheduledEvent.Event.EventName,
                    UserEventName = scheduledEvent.UserEventName,
                    HostName = scheduledEvent.PublicQuotationRequest.Host,
                    QuotatedAmount = scheduledEvent.PublicQuotationRequest.PublicQuotationResponse.QuotedAmount,
                    EventStartDate = scheduledEvent.PublicQuotationRequest.StartDate,
                    EventEndDate = scheduledEvent.PublicQuotationRequest.EndDate,
                    EventTiming = scheduledEvent.PublicQuotationRequest.Timing,
                    VenueType = scheduledEvent.PublicQuotationRequest.Venue,
                    ResponseMessage = scheduledEvent.PublicQuotationRequest.PublicQuotationResponse.ResponseMessage,
                    UserName = scheduledEvent.User.FullName,
                    UserEmail = scheduledEvent.User.Email,

                    TotalSeats = scheduledEvent.PublicQuotationRequest.TotalSeats,
                    TicketPrice = scheduledEvent.PublicQuotationRequest.TicketPrice,
                    RemainingSeats = scheduledEvent.RemainingSeats,
                    IsActive = scheduledEvent.IsActive,
                    City = scheduledEvent.PublicQuotationRequest.City,
                    ImageUrl = scheduledEvent.PublicQuotationRequest.ImageURL,
                    Description = scheduledEvent.PublicQuotationRequest.Description,
                    Location = scheduledEvent.PublicQuotationRequest.LocationDetails,
                });
                return publicScheduledEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReturnSchedulePublicEventDTO>> GetScheduledEventByUserId(int userId)
        {
            try
            {
                var scheduledEvents = await _scheduledPublicEventRepository.ScheduledPublicEventsByUserId(userId);
                var publicScheduledEvents = scheduledEvents.Select(scheduledEvent => new ReturnSchedulePublicEventDTO
                {
                    ScheduledPublicEventId = scheduledEvent.ScheduledPublicEventId,
                    EventName = scheduledEvent.Event.EventName,
                    UserEventName = scheduledEvent.UserEventName,
                    HostName = scheduledEvent.PublicQuotationRequest.Host,
                    QuotatedAmount = scheduledEvent.PublicQuotationRequest.PublicQuotationResponse.QuotedAmount,
                    EventStartDate = scheduledEvent.PublicQuotationRequest.StartDate,
                    EventEndDate = scheduledEvent.PublicQuotationRequest.EndDate,
                    EventTiming = scheduledEvent.PublicQuotationRequest.Timing,
                    VenueType = scheduledEvent.PublicQuotationRequest.Venue,
                    ResponseMessage = scheduledEvent.PublicQuotationRequest.PublicQuotationResponse.ResponseMessage,
                    UserName = scheduledEvent.User.FullName,
                    UserEmail = scheduledEvent.User.Email,
                   
                    TotalSeats = scheduledEvent.PublicQuotationRequest.TotalSeats,
                    TicketPrice = scheduledEvent.PublicQuotationRequest.TicketPrice,
                    RemainingSeats = scheduledEvent.RemainingSeats,
                    IsActive = scheduledEvent.IsActive,
                    City = scheduledEvent.PublicQuotationRequest.City,
                    ImageUrl = scheduledEvent.PublicQuotationRequest.ImageURL,
                    Description = scheduledEvent.PublicQuotationRequest.Description,
                    Location = scheduledEvent.PublicQuotationRequest.LocationDetails,
                });
                return publicScheduledEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
