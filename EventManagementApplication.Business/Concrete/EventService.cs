﻿using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
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
    [TransactionScopeAspect]
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [FluentValidateAspect(typeof(EventValidator))]
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


        [FluentValidateAspect(typeof(EventValidator))]
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
        public void ActivateEvent(int eventId, DateTime newDate, string newStartTime, string newEndTime)
        {
            var existingEvent = _unitOfWork.Events.GetById(eventId);
            if (existingEvent != null)
            {
                existingEvent.Date = newDate;
                existingEvent.StartTime = newStartTime;
                existingEvent.EndTime = newEndTime;
                existingEvent.Status = true;

                _unitOfWork.Events.Update(existingEvent);
                _unitOfWork.Save();
            }
        }

    }
}
