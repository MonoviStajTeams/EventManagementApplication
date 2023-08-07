using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementApplication.Services
{
	public interface IEventService
	{
		Task<List<Event>> GetAllByUserIdAsync(int userId);
	}

	public class EventService : IEventService
	{
		private List<Event> eventList;

		public EventService()
		{
			eventList = GenerateSampleEvents(); 
		}

		private List<Event> GenerateSampleEvents()
		{
			List<Event> events = new List<Event>();

			for (int i = 1; i <= 10; i++)
			{
				int userId = i <= 3 ? 1 : 2; 
				events.Add(new Event { Id = i, UserId = userId, Title = $"Event {i}",

			return events;
		}

		public async Task<List<Event>> GetAllByUserIdAsync(int userId)
		{
			

			List<Event> userEvents = new List<Event>();

			foreach (Event evt in eventList)
			{
				if (evt.UserId == userId)
				{
					userEvents.Add(evt);
				}
			}

			return userEvents;
		}
	}

	
}
