using EventManagementProject.DTOs.EventDTO;

namespace EventManagementProject.Interfaces.Services
{
    public interface IScheduledPublicEventService
    {
        public Task AddScheduledPublicEvent(AddScheduledPublicEventDTO scheduledPublicEventDTO);

        public Task<IEnumerable<ReturnSchedulePublicEventDTO>> GetScheduledEventByUserId(int userId);
        public Task<IEnumerable<ReturnSchedulePublicEventDTO>> GetAllScheduledPublicEvent();
    }
}
