using EventManagementProject.DTOs.QuotationDTO.cs;

namespace EventManagementProject.Interfaces.Services
{
    public interface IPubQuotationRequestService
    {
        public Task AddPubQuotationRequest(AddPubQuotationRequestDTO pubQuotationRequestDto);

        public Task<IEnumerable<ReturnPubQuotationDTO>> ReturnPubQuotation();
    }
}
