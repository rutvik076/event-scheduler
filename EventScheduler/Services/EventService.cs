using EventScheduler.Models;
using EventScheduler.Repositories;

namespace EventScheduler.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _eventRepository.GetEventsAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }

        public async Task AddEventAsync(Event newEvent)
        {
            await _eventRepository.AddEventAsync(newEvent);
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            await _eventRepository.UpdateEventAsync(updatedEvent);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _eventRepository.DeleteEventAsync(id);
        }
    }
}
