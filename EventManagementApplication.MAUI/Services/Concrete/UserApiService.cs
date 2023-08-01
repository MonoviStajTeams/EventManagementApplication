using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Concrete
{
    internal class UserApiService : GenericApiService<UserApiResponse>, IUserApiService
    {
        public UserApiService(string apiEndpoint) : base(apiEndpoint)
        {
        }
    }
}
