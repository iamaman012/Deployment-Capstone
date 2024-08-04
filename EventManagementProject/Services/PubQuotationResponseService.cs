using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;

namespace EventManagementProject.Services
{
    public class PubQuotationResponseService : IPubQuotationResponseService
    {
        private readonly IPubQuotationRequestRepository _pubQuotationRequestRepository;
        private readonly IPubQuotationResponseRepository _pubQuotationResponseRepository;
        private readonly IUserRepository _userRepository;

        public PubQuotationResponseService(IPubQuotationRequestRepository pubQuotationRequestRepository, IPubQuotationResponseRepository pubQuotationResponseRepository,IUserRepository userRepository)
        {
            _pubQuotationRequestRepository = pubQuotationRequestRepository;
            _pubQuotationResponseRepository = pubQuotationResponseRepository;
            _userRepository = userRepository;
        }
        public async Task AddPubQuotationResponse(PubQuotationResponseDTO pubQuotationResponseDTO)
        {
            try
            {
                var response = new PublicQuotationResponse
                {
                    PublicQuotationRequestId = pubQuotationResponseDTO.PublicQuotationRequestId,
                    RequestStatus="Initiated",
                    QuotedAmount = pubQuotationResponseDTO.QuotedAmount,
                    ResponseMessage = pubQuotationResponseDTO.ResponseMessage,
                    ResponseDate = DateTime.Now,
                    IsAccepted = false,
                   
                };
                await _pubQuotationResponseRepository.Add(response);
                await _pubQuotationRequestRepository.UpdateQuotationStatus(pubQuotationResponseDTO.PublicQuotationRequestId, "Responded");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReturnPubQuotationResponseDTO>> GetPubQuotationResponseByUserId(int userId)
        {
            try
            {
                var responses = await _userRepository.GetQuotationResponseByUserId<PublicQuotationResponse>(userId, "Public");
                var returnPubQuotationResponses = responses.Select(response => new ReturnPubQuotationResponseDTO
                {
                    PublicQuotationResponseId = response.PublicQuotationResponseId,
                    PublicQuotationRequestId = response.PublicQuotationRequestId,
                    QuotedAmount = response.QuotedAmount,
                    ResponseMessage = response.ResponseMessage,
                    EventName = response.PublicQuotationRequest.Event.EventName,
                    AcceptedByYou = response.IsAccepted,
                });
                return returnPubQuotationResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
