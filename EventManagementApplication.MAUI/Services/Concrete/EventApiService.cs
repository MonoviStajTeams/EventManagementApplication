using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Concrete
{
    public class EventApiService : GenericApiService<EventApiResponse>, IEventApiService
    {
        public EventApiService(string apiEndpoint) : base(apiEndpoint)
        {
        }
    }
}
