using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using EventManagementProject.Repositories;

namespace EventManagementProject.Services
{
    public class PvtQuotationResponseService : IPvtQuotationResponseService
    {
        private readonly IPvtQuotationResponseRepository _pvtQuotationResponseRepository;
        private readonly IPvtQuotationRequestRepository _pvtQuotationRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly EmailService _emailService;
        public PvtQuotationResponseService(IPvtQuotationResponseRepository pvtQuotationResponseRepository, IPvtQuotationRequestRepository pvtQuotationRequestRepository, IUserRepository userRepository,EmailService emailService)
        {
            _pvtQuotationResponseRepository = pvtQuotationResponseRepository;
            _pvtQuotationRequestRepository = pvtQuotationRequestRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }
        public async Task AddQuotationResponse(PvtQuotationResponseDTO pvtQuotationResponseDTO)
        {
            try
            {
                var pvtQuotationResponse = new PrivateQuotationResponse
                {
                    PrivateQuotationRequestId = pvtQuotationResponseDTO.PrivateQuotationRequestId,
                    QuotedAmount = pvtQuotationResponseDTO.QuotedAmount,
                    ResponseMessage = pvtQuotationResponseDTO.ResponseMessage,
                    RequestStatus = "Initiated",
                    ResponseDate = DateTime.Now,
                    IsAccepted = false
                };
                await _pvtQuotationResponseRepository.Add(pvtQuotationResponse);
                await _pvtQuotationRequestRepository.UpdateQuotationStatus(pvtQuotationResponseDTO.PrivateQuotationRequestId, "Responded");
                var quotation = await _pvtQuotationRequestRepository.GetQuotationById(pvtQuotationResponseDTO.PrivateQuotationRequestId);
                await SendMail(quotation);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       

       public async Task<IEnumerable<ReturnPvtQuotationResponseDTO>>GetQuotationResponseByuserId(int userId)
        {
            try
            {
                var responses = await _userRepository.GetQuotationResponseByUserId<PrivateQuotationResponse>(userId,"Private");
                var returnPvtQuotationResponses = responses.Select(response => new ReturnPvtQuotationResponseDTO
                {
                    PrivateQuotationResponseId = response.PrivateQuotationResponseId,
                    PrivateQuotationRequestId = response.PrivateQuotationRequestId,
                    QuotedAmount = response.QuotedAmount,
                    ResponseMessage = response.ResponseMessage,
                    EventName = response.PrivateQuotationRequest.Event.EventName,
                    AcceptedByYou = response.IsAccepted,
                });
                return returnPvtQuotationResponses;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task SendMail(PrivateQuotationRequest quotation)
        {
            try
            {
                string subject = "Request Accepted Confirmation";
                string body = $"Dear {quotation.User.FullName},\n\n" +
                $"Your Request has been Accepted for the event '{quotation.Event.EventName}'.\n" +
                $"The Quotatated Amount is {quotation.PrivateQuotationResponse.QuotedAmount}.\n" +
                $"You can able to see the response on the portal.\n"+
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
