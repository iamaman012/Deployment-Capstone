using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IEventRepository : IRepository<int,Event>
    {
        public Task<string> GetEventNameById(int eventId);
    }
}
