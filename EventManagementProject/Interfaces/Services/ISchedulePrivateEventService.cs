using EventManagementProject.DTOs.EventDTO;
using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Services
{
    public interface ISchedulePrivateEventService
    {
        public Task AddSchedulePublicEvent(AddScheduledPrivateEventDTO addScheduledPrivateEventDTO);
        public Task<IEnumerable<ReturnSchedulePrivateEventDTO>> GetScheduledEventByUserId(int userId);
        public Task<IEnumerable<ReturnSchedulePrivateEventDTO>> GetAllScheduledPrivateEvent();

        public Task SendMail(PrivateQuotationRequest quotation);
    }
}
