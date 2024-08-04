using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IPvtQuotationRequestRepository : IRepository<int,PrivateQuotationRequest>
    {
        public Task UpdateQuotationStatus(int id, string status);
        public Task<PrivateQuotationRequest> GetQuotationById(int id);
    }
}
