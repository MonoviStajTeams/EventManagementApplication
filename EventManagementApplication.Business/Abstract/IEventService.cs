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
        IEnumerable<Event> GetAll();
        Event GetById(int id);
        void Create(Event entity);
        void Update(Event entity);
        void Delete(int id);
    }
}
