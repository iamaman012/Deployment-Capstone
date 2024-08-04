using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IScheduledPrivateEventRepository :IRepository<int,ScheduledPrivateEvent>
    {
        public Task<List<ScheduledPrivateEvent>> GetScheduledPrivateEventByUserId(int userId);
        public Task<List<ScheduledPrivateEvent>> GetScheduledPrivateEvents();
    }
}
