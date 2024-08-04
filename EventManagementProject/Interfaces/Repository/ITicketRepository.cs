using EventManagementProject.DTOs.TicketDTO;
using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface ITicketRepository : IRepository<int, Ticket>
    {
        public Task AddTicket(Ticket ticket);
        public Task<List<Ticket>> GetTicketByuserid(int userId);
    }
}
