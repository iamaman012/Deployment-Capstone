using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;

namespace EventManagementProject.Repositories
{
    public class EventRepository :Repository<int,Event>,IEventRepository
    {

        public EventRepository(EventManagementContext context) : base(context) { }

        public async Task<string> GetEventNameById(int eventId)
        {
            try
            {
                var eventName = await _context.Events.FindAsync(eventId);
                return eventName.EventName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
