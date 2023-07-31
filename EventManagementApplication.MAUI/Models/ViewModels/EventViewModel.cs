using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.ViewModels
{
    public partial class EventViewModel : ObservableObject
    {
        private readonly IEventApiService _eventApiService;

        public EventViewModel()
        {
            _eventApiService = new EventApiService("event");
        }




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
        private async Task AddEvent()
        {
            var entity = new EventApiResponse
            {
                Title = title,
                Description = description,
                SubContent = subcontent,
                Type = type,
                Date = date,
                Status = status,
                StartTime = starttime,
                EndTime = endtime,
                UserId = userId
            };
            _eventApiService.Create(entity);
        }

        [RelayCommand]
        private async Task UpdateEvent()
        {
            var entity = new EventApiResponse
            {
                Title = title,
                Description = description,
                SubContent = subcontent,
                Type = type,
                Date = date,
                Status = status,
                StartTime = starttime,
                EndTime = endtime,
                UserId = userId 

            };

            _eventApiService.Update(entity);
        }
    }
}

