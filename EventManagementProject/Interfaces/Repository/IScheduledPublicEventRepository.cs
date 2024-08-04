using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IScheduledPublicEventRepository : IRepository<int, ScheduledPublicEvent >
    {
        public Task<List<ScheduledPublicEvent>> ScheduledPublicEventsByUserId(int userId);

        public Task<List<ScheduledPublicEvent>> GetAllScheduledPublicEvents();

        public Task UpdateRemainigSeats(int id, int seats);

        public Task<ScheduledPublicEvent> GetScheduledPublicEventById(int id );
    }
}
