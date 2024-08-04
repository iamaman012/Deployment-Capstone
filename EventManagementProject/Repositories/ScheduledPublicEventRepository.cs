using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementProject.Repositories
{
    public class ScheduledPublicEventRepository : Repository<int,ScheduledPublicEvent>, IScheduledPublicEventRepository
    {
        public ScheduledPublicEventRepository(EventManagementContext _context) : base(_context)
        {
        }

        public async Task<List<ScheduledPublicEvent>> GetAllScheduledPublicEvents()
        {
            try
            {
                var scheduledPublicEvents = await _context.ScheduledPublicEvents.Include(spe => spe.PublicQuotationRequest)
                       .ThenInclude(pqr => pqr.PublicQuotationResponse)
                   .Include(spe => spe.User)
                   .Include(spe=>spe.Event)
                   .ToListAsync();
                return scheduledPublicEvents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ScheduledPublicEvent> GetScheduledPublicEventById(int id)
        {
            try
            {
                var scheduledEvent = await _context.ScheduledPublicEvents
                    
                    .Include(spe=>spe.PublicQuotationRequest)
                    .FirstOrDefaultAsync(spe => spe.ScheduledPublicEventId == id);
                return scheduledEvent;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ScheduledPublicEvent>> ScheduledPublicEventsByUserId(int userId)
        {
            try
            {
                var scheduledPublicEvents = await _context.ScheduledPublicEvents.Include(spe=>spe.PublicQuotationRequest)
                        .ThenInclude(pqr => pqr.PublicQuotationResponse)
                    .Include(spe=>spe.User)
                    .Include(spe => spe.Event)
                    .Where(s => s.UserId == userId).ToListAsync();
                return scheduledPublicEvents;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public  async Task UpdateRemainigSeats(int id, int seats)
        {
            try
            {
                var scheduledPublicEvent = await _context.ScheduledPublicEvents.FirstOrDefaultAsync(spe => spe.ScheduledPublicEventId == id);
                scheduledPublicEvent.RemainingSeats = scheduledPublicEvent.RemainingSeats - seats;
                _context.ScheduledPublicEvents.Update(scheduledPublicEvent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
