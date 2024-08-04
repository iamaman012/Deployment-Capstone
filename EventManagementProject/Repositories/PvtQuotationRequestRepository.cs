using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventManagementProject.Repositories
{
    public class PvtQuotationRequestRepository:Repository<int, PrivateQuotationRequest>, IPvtQuotationRequestRepository
    {
        public PvtQuotationRequestRepository(EventManagementContext context) : base(context)
        {
        }

        public async Task<PrivateQuotationRequest> GetQuotationById(int id)
        {
            try
            {
                var quotation = _context.PrivateQuotationRequests
                    .Include(pqr=>pqr.User)
                    .Include(pqr => pqr.Event)
                    .Include(pqr => pqr.PrivateQuotationResponse)
                    .FirstOrDefault(pqr => pqr.PrivateQuotationRequestId == id);

                return quotation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateQuotationStatus(int id, string status)
        {
            try
            {
                var quotation = _context.PrivateQuotationRequests.Find(id);
                quotation.QuotationStatus = status;
                _context.Update(quotation);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }
    }
}
