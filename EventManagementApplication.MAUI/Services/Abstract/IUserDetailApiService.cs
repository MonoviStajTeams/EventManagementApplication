using EventManagementApplication.MAUI.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Abstract
{
    public interface IUserDetailApiService : IGenericApiService<UserDetailApiResponse>
    {
        Task<UserDetailApiResponse> GetUserDetailByUserIdAsync(int userId);
    }
}
