using EventManagementProject.Context;
using EventManagementProject.DTOs.TicketDTO;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementProject.Repositories
{
    public class TicketRepository : Repository<int, Ticket>, ITicketRepository
    {
        public TicketRepository(EventManagementContext _context) : base(_context)
        {
        }

        public async Task AddTicket(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ticket>> GetTicketByuserid(int userId)
        {
            try
            {
                var tickets = await _context.Tickets
                    .Include(t=>t.ScheduledPublicEvent)
                        .ThenInclude(spe=>spe.PublicQuotationRequest)
                        .Where(t => t.UserId == userId).ToListAsync();
                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
