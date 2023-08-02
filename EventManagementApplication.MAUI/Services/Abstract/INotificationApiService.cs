using EventManagementApplication.MAUI.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Abstract
{
    public interface INotificationApiService : IGenericApiService<NotificationApiResponse>
    {
        Task SendInvitationNotificationAsync(InvitationApiResponse ınvitationApiResponse, int userId);
        Task<IEnumerable<UserApiResponse>> GetUsersAsync();
        Task SendReminderNotificationsAsync();
    }
}
