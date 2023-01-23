using api_pickupvb.model;
using Microsoft.EntityFrameworkCore;

namespace api_pickupvb.data;
public class EventContext: DbContext
{
    public DbSet<Event> Events{get;set;}
    


}
