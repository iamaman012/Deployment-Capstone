using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IPvtQuotationResponseRepository : IRepository<int, PrivateQuotationResponse>
    {
        public Task ResponseAcceptedByUser(int responseId);
    }
}
