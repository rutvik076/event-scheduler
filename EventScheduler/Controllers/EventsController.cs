using EventScheduler.Models;
using EventScheduler.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduler.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventService.GetEventsAsync();
            var eventList = new List<object>();

            foreach (var ev in events)
            {
                eventList.Add(new
                {
                    id = ev.Id,
                    title = ev.EventTitle,
                    start = ev.EventStartDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                    end = ev.EventEndDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                    description = ev.EventDescription,
                    priority = ev.EventPriority
                });
            }

            return Json(eventList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] Event newEvent)
        {
            if (ModelState.IsValid)
            {
                await _eventService.AddEventAsync(newEvent);
                return Ok(newEvent);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event updatedEvent)
        {
            if (id != updatedEvent.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var existingEvent = await _eventService.GetEventByIdAsync(id);
                if (existingEvent == null)
                {
                    return NotFound();
                }

                // Update properties of existing event
                existingEvent.EventTitle = updatedEvent.EventTitle;
                existingEvent.EventStartDate = updatedEvent.EventStartDate;
                existingEvent.EventEndDate = updatedEvent.EventEndDate;
                existingEvent.EventDescription = updatedEvent.EventDescription;
                existingEvent.EventPriority = updatedEvent.EventPriority;

                // Call service method to update event
                await _eventService.UpdateEventAsync(existingEvent);

                return Ok(existingEvent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update event: {ex.Message}");
            }
        }
    }
}
