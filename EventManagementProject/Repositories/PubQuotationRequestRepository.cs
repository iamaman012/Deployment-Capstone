using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;

namespace EventManagementProject.Repositories
{
    public class PubQuotationRequestRepository: Repository<int, PublicQuotationRequest>, IPubQuotationRequestRepository
    {
        public PubQuotationRequestRepository(EventManagementContext context) : base(context)
        {
        }

        public async  Task<int> GetTotalSeats(int id)
        {
            try
            {
                var quotation = await _context.PublicQuotationRequests.FindAsync(id);
                return quotation.TotalSeats;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateQuotationStatus(int id, string status)
        {
            try
            {
                var quotation = _context.PublicQuotationRequests.Find(id);
                quotation.QuotationStatus = status;
                _context.Update(quotation);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
   
}
