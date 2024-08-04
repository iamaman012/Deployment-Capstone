using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Services
{
    public interface IPvtQuotationResponseService
    {
        public Task AddQuotationResponse(PvtQuotationResponseDTO pvtQuotationResponseDTO);
        public Task<IEnumerable<ReturnPvtQuotationResponseDTO>> GetQuotationResponseByuserId(int userId);
        public Task SendMail(PrivateQuotationRequest quotation);
    }
}
