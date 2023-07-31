using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class NotificationViewModel : ObservableObject
    {

        [ObservableProperty]
        private int receivindid;

        [ObservableProperty]
        private int invitationid;

        [ObservableProperty]
        private DateTime createddate;



        [RelayCommand]
        private async Task FetchNotificationInfo()
        {

        }
    }
}
