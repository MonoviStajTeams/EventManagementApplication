using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.ViewModels
{
    public partial class InvitationViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private int userid;

        [ObservableProperty]
        private int eventid;

        [RelayCommand]
        private async Task FetchInvitationInfo()
        {

        }
    }
}
