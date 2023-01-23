using api_pickupvb.model;
using Microsoft.EntityFrameworkCore;

namespace api_pickupvb.data;
public class EventContext: DbContext
{
    public DbSet<Event> Events{get;set;}
    
    public EventContext(DbContextOptions<EventContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
    {  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)  
    {  
        base.OnModelCreating(modelBuilder);
    }
}
