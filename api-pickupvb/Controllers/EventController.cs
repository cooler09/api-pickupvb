using api_pickupvb.model;
using Microsoft.AspNetCore.Mvc;

namespace api_pickupvb.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;

    public EventController(ILogger<EventController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetEvents")]
    public IEnumerable<Event> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Event
        {
            Id = Guid.NewGuid(),
            Name = "Test"
        })
        .ToArray();
    }
}
