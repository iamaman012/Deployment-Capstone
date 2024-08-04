using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;

namespace EventManagementProject.Repositories
{
    public class PubQuotationResponseRepository : Repository<int, PublicQuotationResponse>, IPubQuotationResponseRepository
    {
        public PubQuotationResponseRepository(EventManagementContext _context) : base(_context)
        {
        }

        public async Task ResponseAcceptedByUser(int id)
        {
            try
            {
                var response = await _context.PublicQuotationResponses.FindAsync(id);
                response.IsAccepted = true;
                _context.Update(response);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
