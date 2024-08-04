using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace EventManagementProject.Services
{
    public class PvtQuotationRequestService : IPvtQuotationRequestService
    {
        private readonly IPvtQuotationRequestRepository _pvtQuotationRequestRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly EmailService _emailService;
        public PvtQuotationRequestService(IPvtQuotationRequestRepository pvtQuotationRequestRepository, IEventRepository eventRepository,IUserRepository userRepository,EmailService emailService)
        {
            _pvtQuotationRequestRepository = pvtQuotationRequestRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }
        public async Task AddPvtQuotationRequest(AddPvtQuotationRequestDTO pvtQuotationRequestDto)
        {
            try
            {
                var pvtQuotationRequest = new PrivateQuotationRequest
                {
                    UserId = pvtQuotationRequestDto.UserId,
                    EventId = pvtQuotationRequestDto.EventId,
                    ExpectedPeopleCount = pvtQuotationRequestDto.ExpectedPeopleCount,
                    VenueType = pvtQuotationRequestDto.VenueType,
                    LocationDetails = pvtQuotationRequestDto.LocationDetails,
                    FoodPreference = pvtQuotationRequestDto.FoodPreference,
                    CateringInstructions = pvtQuotationRequestDto.CateringInstructions,
                    SpecialInstructions = pvtQuotationRequestDto.SpecialInstructions,
                    EventStartDate = pvtQuotationRequestDto.EventStartDate,
                    EventEndDate = pvtQuotationRequestDto.EventEndDate,
                    EventTiming = pvtQuotationRequestDto.EventTiming,
                    RequestedDate = DateTime.Now

                };
                pvtQuotationRequest.QuotationStatus = "Pending";
                await _pvtQuotationRequestRepository.Add(pvtQuotationRequest);
                var user = await _userRepository.GetById(pvtQuotationRequestDto.UserId);
                await SendMail(user, pvtQuotationRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ReturnPvtQuotationsDTO>> ReturnPvtQuotation()
        {
            try
            {
                var privateEvents = await _pvtQuotationRequestRepository.GetAll();
                var returnPvtQuotations = privateEvents.Select(pvtQuotationRequest => new ReturnPvtQuotationsDTO
                {
                    PrivateQuotationRequestId = pvtQuotationRequest.PrivateQuotationRequestId,
                    UserId = pvtQuotationRequest.UserId,
                    EventId = pvtQuotationRequest.EventId,
                    ExpectedPeopleCount = pvtQuotationRequest.ExpectedPeopleCount,
                    VenueType = pvtQuotationRequest.VenueType,
                    LocationDetails = pvtQuotationRequest.LocationDetails,
                    FoodPreference = pvtQuotationRequest.FoodPreference,
                    CateringInstructions = pvtQuotationRequest.CateringInstructions,
                    SpecialInstructions = pvtQuotationRequest.SpecialInstructions,
                    EventStartDate = pvtQuotationRequest.EventStartDate,
                    EventEndDate = pvtQuotationRequest.EventEndDate,
                    EventTiming = pvtQuotationRequest.EventTiming,
                    RequestedDate = pvtQuotationRequest.RequestedDate,
                    QuotationStatus = pvtQuotationRequest.QuotationStatus,
                    EventName = _eventRepository.GetById(pvtQuotationRequest.EventId).Result.EventName
                }) ;

                return returnPvtQuotations;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SendMail(User user, PrivateQuotationRequest quotation)
        {
            try
            {    var eventName = await _eventRepository.GetEventNameById(quotation.EventId);
                string subject = "Quotation Applied Confirmation";
                string body = $"Dear {user.FullName},\n\n" +
                $"Thank you for appliying the quotation for the event '{eventName}'.\n\n" +
                $"Quotation Id: {quotation.PrivateQuotationRequestId}\n\n" +

                 $"We will review your quotation and reach out to you" +

                $"We look forward to seeing you there!\n\n" +
                "Best regards,\nEvent Management Team";


                _emailService.SendEmail(user.Email, subject, body);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
