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
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Event>> UpdateProducts(Guid id, Event eventModel)
    {
        if (id != eventModel.Id || eventModel.Id == Guid.Empty)
            return BadRequest("Event Id mismatch or invalid format");
        _eventService.Update(eventModel);
        await _eventService.SaveChanges();

        return eventModel;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> PostProducts(Event eventModel)
    {
        try{
            _eventService.Create(eventModel);
            await _eventService.SaveChanges();

            if(eventModel?.Id != null) return Created(new Uri($"/Event/{eventModel.Id}"),eventModel.Id);

            return StatusCode(StatusCodes.Status500InternalServerError, "Event was not created");

        } catch(Exception ex){
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<Guid>> DeleteProducts(Guid id)
    {
        _eventService.Delete(id);
        await _eventService.SaveChanges();

        return id;
    }
}
