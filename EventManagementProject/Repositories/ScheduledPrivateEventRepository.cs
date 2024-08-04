using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementProject.Repositories
{
    public class ScheduledPrivateEventRepository : Repository<int, ScheduledPrivateEvent>, IScheduledPrivateEventRepository
    {
        public ScheduledPrivateEventRepository(EventManagementContext _context) : base(_context)
        {
        }

        public async Task<List<ScheduledPrivateEvent>> GetScheduledPrivateEventByUserId(int userId)
        {
            try
            {
                var scheduledEvents = await  _context.ScheduledPrivateEvents.Include(spe => spe.PrivateQuotationRequest)
                    .ThenInclude(pqr => pqr.PrivateQuotationResponse)
                    .Include(spe=>spe.Event)
                    .Include(spe=>spe.User)
                    .Where(x => x.UserId == userId).ToListAsync();
                return scheduledEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ScheduledPrivateEvent>> GetScheduledPrivateEvents()
        {
            try
            {
                var scheduledEvents = await _context.ScheduledPrivateEvents.Include(spe=>spe.PrivateQuotationRequest)
                    .ThenInclude(pqr => pqr.PrivateQuotationResponse)
                    .Include(spe => spe.Event)
                    .Include(spe => spe.User).
                    ToListAsync();
                return scheduledEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
