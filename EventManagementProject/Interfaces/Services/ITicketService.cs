using EventManagementProject.DTOs.TicketDTO;

namespace EventManagementProject.Interfaces.Services
{
    public interface ITicketService
    {
        public Task AddTicket(AddTicketDTO ticketDTO);

        public Task<IEnumerable<ReturnTicketDTO>> GetTicketByUserId(int userId);
       
    }
}
