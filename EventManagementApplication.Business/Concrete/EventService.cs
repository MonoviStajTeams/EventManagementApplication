using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Core.Aspects.CacheAspects;
using EventManagementApplication.Core.Aspects.LogAspects;
using EventManagementApplication.Core.Aspects.TransactionAspects;
using EventManagementApplication.Core.Aspects.ValidationAspects;
using EventManagementApplication.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
            return _unitOfWork.Events.GetAllWithIncludes(x => x.User);

        }

        
        public Event GetById(int id)
        {
            return _unitOfWork.Events.GetByIdWithIncludes(id,x=>x.User);

        }


        public void Update(Event entity)
        {
            _unitOfWork.Events.Update(entity);
            _unitOfWork.Save();
        }




        // list past events by user
        public IEnumerable<Event> GetInactiveEventsByUserId(int userId)
        {
            return _unitOfWork.Events.GetAll().Where(e => e.UserId == userId && !e.Status);
        }


        // reactivate events
        public void ActivateEvent(Event events)
        {
            var existingEvent = _unitOfWork.Events.GetById(events.Id);
            if (existingEvent != null)
            {
                existingEvent.Date = events.Date;
                existingEvent.StartTime = events.StartTime;
                existingEvent.EndTime = events.EndTime;
                existingEvent.Status = true;

                _unitOfWork.Events.Update(existingEvent);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<Event> GetByType(string type)
        {
            return _unitOfWork.Events.GetAll().Where(x => x.Type == type);
        }



        public IEnumerable<Event> GetAllByUserId(int id)
        {
            return _unitOfWork.Events.GetAllWithIncludes(x => x.User).Where(x=>x.UserId == id);

        }


        public void RepeatEvent(Event entity , string startdate,string enddate, DateTime time)
        {
            var repeatevent= GetById(entity.Id);
            if (repeatevent != null)
            {
                entity.StartTime = startdate;
                entity.EndTime = enddate;
                entity.Status = true;
                entity.Date = time;
                

                _unitOfWork.Events.Update(entity);
                _unitOfWork.Save();

            }
            
    }

    }
}
