using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Services
{
    public interface IPvtQuotationRequestService
    {
        public Task AddPvtQuotationRequest(AddPvtQuotationRequestDTO pvtQuotationRequestDto);
        public Task<IEnumerable<ReturnPvtQuotationsDTO>> ReturnPvtQuotation();
        public Task SendMail(User user, PrivateQuotationRequest pvtQuotationRequestDto);
    }
}
