using EventManagementProject.DTOs.EventDTO;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using EventManagementProject.Repositories;

namespace EventManagementProject.Services
{
    public class EventService : IEvent
    {
        private readonly IEventRepository _eventRepo;
        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }
        public async Task AddEvent(AddEventDTO eventDto)
        {
            try
            {
                var newEvent = new Event
                {
                    EventName = eventDto.EventName,
                    Description = eventDto.Description,
                    Category = eventDto.Category,
                    ImageURL = eventDto.ImageURL,
                    EventType = eventDto.EventType,
                    Theme = eventDto.Theme
                };
                 await _eventRepo.Add(newEvent);

            }
            catch(Exception ex  )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventListDTO>> GetAllEventByCategory(string category)
        {
            try
            {
                var events = await _eventRepo.GetAll();
                events= events.Where(e => e.Category == category);

                return events.Select(e => new EventListDTO
                {
                    EventId = e.EventId,
                    EventName = e.EventName,
                    Description = e.Description,
                    Category = e.Category,
                    ImageURL = e.ImageURL,
                    EventType = e.EventType,
                    Theme = e.Theme
                });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<IEnumerable<EventListDTO>> GetAllPublicEvents()
        {
            try
            {
                var events = await _eventRepo.GetAll();
                events = events.Where(e => e.EventType == "Public");
                return events.Select(e => new EventListDTO
                {
                    EventId = e.EventId,
                    EventName = e.EventName,
                    Description = e.Description,
                    Category = e.Category,
                    ImageURL = e.ImageURL,
                    EventType = e.EventType,
                    Theme = e.Theme
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async   Task<int> GetEventIdByName(string eventName)
        {
            try
            {   var newEvent = await  _eventRepo.GetAll();
                var eventNameId = newEvent.Where(e => e.EventName == eventName).FirstOrDefault();
                return eventNameId.EventId;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
         }

        
    }
}
