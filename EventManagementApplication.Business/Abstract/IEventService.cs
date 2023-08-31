using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface IEventService : IGenericService<Event>
    {
        IEnumerable<Event> GetInactiveEventsByUserId(int userId);
        IEnumerable<Event> GetByType(string type);
        void ActivateEvent(Event events);
        void RepeatEvent(string Title, string newStartDate, string newEndDate, DateTime newTime);
        IEnumerable<Event> GetAllByUserId(int id);
    }
}
