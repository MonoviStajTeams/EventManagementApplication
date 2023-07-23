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
        void ActivateEvent(int eventId, DateTime newDate, string newStartTime, string newEndTime);
        IEnumerable<Event> GetAllByUserId(int id);
    }
}
