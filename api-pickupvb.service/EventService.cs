using System;
using api_pickupvb.data;
using api_pickupvb.model;
using Microsoft.EntityFrameworkCore;

namespace api_pickupvb.service
{
    public class EventService: IEventService
    {
        private EventContext _context { get; set; }
        public EventService(EventContext context)
        {
            _context = context;            
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEvent(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        public void Create(Event model)
        {
            model.Id = Guid.NewGuid();
            _context.Events.Add(model);
        }

        public void Update(Event model)
        {
            if (Guid.Empty == model.Id)
            {
                _context.Events.Update(model);
            }
        }

        public async void Delete(Guid id)
        {
            var model = await GetEvent(id);
            if(model != null)
                _context.Events.Remove(model);
            
        }
        public async Task<int> SaveChanges(){
            return await _context.SaveChangesAsync();
        }
    }
}
