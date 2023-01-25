using System;
using api_pickupvb.model;

namespace api_pickupvb.service
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> GetEvent(Guid id);
        void Create(Event model);
        void Update(Event model);
        void Delete(Guid id);
        Task<int> SaveChanges();
    }
}
