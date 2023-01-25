using api_pickupvb.model;
using api_pickupvb.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_pickupvb.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly IEventService _eventService;

    public EventController(ILogger<EventController> logger,IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IEnumerable<Event>> GetEvents()
    {
        return await _eventService.GetEvents();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(Guid id)
    {
        var eventModel = await _eventService.GetEvent(id);

        if (eventModel == null)
        {
            return NotFound();
        }

        return eventModel;
    }

    // PUT: api/Products/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducts(Guid id, Event eventModel)
    {
        if (id != eventModel.Id)
        {
            return BadRequest();
        }
        _eventService.Update(eventModel);
        await _eventService.SaveChanges();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult> PostProducts(Event eventModel)
    {
        _eventService.Create(eventModel);
        await _eventService.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<Guid>> DeleteProducts(Guid id)
    {
        _eventService.Delete(id);
        await _eventService.SaveChanges();

        return id;
    }
}
