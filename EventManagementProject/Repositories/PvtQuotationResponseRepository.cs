using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;

namespace EventManagementProject.Repositories
{
    public class PvtQuotationResponseRepository : Repository<int, PrivateQuotationResponse>, IPvtQuotationResponseRepository
    {
        public PvtQuotationResponseRepository(EventManagementContext _context) : base(_context)
        {
        }

        public async Task ResponseAcceptedByUser(int responseId)
        {
            try
            {
                var response = _context.PrivateQuotationResponses.Find(responseId);
                response.IsAccepted=true;
                _context.Update(response);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
