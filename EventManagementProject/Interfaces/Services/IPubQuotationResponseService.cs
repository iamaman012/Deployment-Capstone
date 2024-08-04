using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Services
{
    public interface IPubQuotationResponseService
    {
        public Task AddPubQuotationResponse(PubQuotationResponseDTO pubQuotationResponseDTO);
        public Task<IEnumerable<ReturnPubQuotationResponseDTO>> GetPubQuotationResponseByUserId(int userId);
       
    }
}
