using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.ViewModels
{
    public class EventViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;


        [ObservableProperty]
        private string subcontent;


        [ObservableProperty]
        private string type;

        [ObservableProperty]
        private DateTime date;

        [ObservableProperty]
        private bool status;

        [ObservableProperty]
        private string starttime;

        [ObservableProperty]
        private string endtime;

        [ObservableProperty]
        private int userId;


        [RelayCommand]
        private async Task FetchEventInfo()
        {

        }
    }
}
