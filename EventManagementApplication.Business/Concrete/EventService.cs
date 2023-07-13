using EventManagementApplication.Business.Abstract;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Concrete
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Event entity)
        {
            _unitOfWork.Events.Add(entity);
            _unitOfWork.Save();

        }

        public void Delete(int id)
        {
            var events = _unitOfWork.Events.GetById(id);
            if (events != null)
            {
                _unitOfWork.Events.Remove(events);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<Event> GetAll()
        {
            return _unitOfWork.Events.GetAll();
        }

        public Event GetById(int id)
        {
            return _unitOfWork.Events.GetById(id);

        }

        public void Update(Event entity)
        {
            _unitOfWork.Events.Update(entity);
            _unitOfWork.Save();
        }
    }
}
