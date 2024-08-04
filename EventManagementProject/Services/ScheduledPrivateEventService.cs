using EventManagementProject.DTOs.EventDTO;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using System.Net.Sockets;

namespace EventManagementProject.Services
{
    public class ScheduledPrivateEventService : ISchedulePrivateEventService
    {   private readonly IScheduledPrivateEventRepository _scheduledPrivateEventRepository;
        private readonly IEvent _eventService;
        private readonly IEventRepository _eventRepository;
        private readonly IPvtQuotationResponseRepository _pvtQuotationResponseRepository;
        private readonly IPvtQuotationRequestRepository _pvtQuotationRequestRepository;
        private readonly EmailService _emailService;

        public ScheduledPrivateEventService(IScheduledPrivateEventRepository scheduledPrivateEventRepository, IEvent eventService, IPvtQuotationResponseRepository pvtQuotationResponseRepository, IEventRepository eventRepository,IPvtQuotationRequestRepository pvtQuotationRequestRepository,EmailService emailService)
        {
            _scheduledPrivateEventRepository = scheduledPrivateEventRepository;
            _eventService = eventService;
            _pvtQuotationResponseRepository = pvtQuotationResponseRepository;
            _eventRepository = eventRepository;
            _emailService = emailService;
            _pvtQuotationRequestRepository = pvtQuotationRequestRepository;
        }
        public async Task AddSchedulePublicEvent(AddScheduledPrivateEventDTO addScheduledPrivateEventDTO)
        {
            try
            {
                var eventId = await _eventService.GetEventIdByName(addScheduledPrivateEventDTO.EventName);

                var scheduledPrivateEvent = new ScheduledPrivateEvent
                {
                    EventId = eventId,
                    PrivateQuotationRequestId = addScheduledPrivateEventDTO.PrivateQuotationRequestId,
                    UserId = addScheduledPrivateEventDTO.UserId
                };
                await _scheduledPrivateEventRepository.Add(scheduledPrivateEvent);
                await _pvtQuotationResponseRepository.ResponseAcceptedByUser(addScheduledPrivateEventDTO.PrivateQuotationResponseId);
               var quotation= await _pvtQuotationRequestRepository.GetQuotationById(addScheduledPrivateEventDTO.PrivateQuotationRequestId);
                await SendMail(quotation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReturnSchedulePrivateEventDTO>> GetAllScheduledPrivateEvent()
        {
            try
            {
                var scheduledEvents = await _scheduledPrivateEventRepository.GetScheduledPrivateEvents();
                var privateScheduledEvents = scheduledEvents.Select(scheduledEvent => new ReturnSchedulePrivateEventDTO
                {
                    ScheduledPrivateEventId = scheduledEvent.ScheduledPrivateEventId,
                    EventName = scheduledEvent.Event.EventName,
                    QuotatedAmount = scheduledEvent.PrivateQuotationRequest.PrivateQuotationResponse.QuotedAmount,
                    EventStartDate = scheduledEvent.PrivateQuotationRequest.EventStartDate,
                    EventEndDate = scheduledEvent.PrivateQuotationRequest.EventEndDate,
                    EventTiming = scheduledEvent.PrivateQuotationRequest.EventTiming,
                    VenueType = scheduledEvent.PrivateQuotationRequest.VenueType,
                    ResponseMessage = scheduledEvent.PrivateQuotationRequest.PrivateQuotationResponse.ResponseMessage,
                    UserName = scheduledEvent.User.FullName,
                    UserEmail = scheduledEvent.User.Email,
                    Location = scheduledEvent.PrivateQuotationRequest.LocationDetails
                });
                return privateScheduledEvents;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReturnSchedulePrivateEventDTO>> GetScheduledEventByUserId(int userId)
        {
            try
            {
                var scheduledEvents = await _scheduledPrivateEventRepository.GetScheduledPrivateEventByUserId(userId);

                var privateScheduledEvents = scheduledEvents.Select(scheduledEvent => new ReturnSchedulePrivateEventDTO
                {
                    ScheduledPrivateEventId = scheduledEvent.ScheduledPrivateEventId,
                    EventName =     scheduledEvent.Event.EventName,
                    QuotatedAmount = scheduledEvent.PrivateQuotationRequest.PrivateQuotationResponse.QuotedAmount,
                    EventStartDate = scheduledEvent.PrivateQuotationRequest.EventStartDate,
                    EventEndDate = scheduledEvent.PrivateQuotationRequest.EventEndDate,
                    EventTiming = scheduledEvent.PrivateQuotationRequest.EventTiming,
                    VenueType = scheduledEvent.PrivateQuotationRequest.VenueType,
                    ResponseMessage = scheduledEvent.PrivateQuotationRequest.PrivateQuotationResponse.ResponseMessage,
                    UserEmail = scheduledEvent.User.Email,
                    UserName = scheduledEvent.User.FullName,
                    Location = scheduledEvent.PrivateQuotationRequest.LocationDetails
                });

                

                return privateScheduledEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SendMail(PrivateQuotationRequest quotation)
        {
            try
            {
                string subject = "Event Scheduled Confirmation";
                string body = $"Dear {quotation.User.FullName},\n\n" +
                $"Your Event Scheduled Successfully.\n" +
                $"Event Name: {quotation.Event.EventName}\n" +
                $"Event Date: {quotation.EventStartDate.ToString("dd MMM yyyy")}\n" +
                $"Excepted people count: {quotation.ExpectedPeopleCount}\n" +
                $"Venue Type: {quotation.VenueType}\n" +
                $"Location Details: {quotation.LocationDetails}\n" +
                $"Food Preference: {quotation.FoodPreference}\n" +
                $"Catering Instructions: {quotation.CateringInstructions}\n" +
                $"Special Instructions: {quotation.SpecialInstructions}\n" +
                $"Total Amount: {quotation.PrivateQuotationResponse.QuotedAmount}\n\n" +
                
                
                $"We look forward to seeing you there!\n\n" +
                "Best regards,\nEvent Management Team";


                _emailService.SendEmail(quotation.User.Email, subject, body);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

