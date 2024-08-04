using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IPubQuotationResponseRepository : IRepository<int,PublicQuotationResponse>
    {
        public Task ResponseAcceptedByUser(int id);
    }
}
