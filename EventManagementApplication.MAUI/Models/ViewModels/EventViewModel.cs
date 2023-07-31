using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class EventViewModel : ObservableObject
    {
        private readonly IEventApiService _eventApiService;
        public EventViewModel()
        {
            _eventApiService = new EventApiService("event");
            MyEvents = new ObservableCollection<EventApiResponse>();
            LoadMyEventsCommand = new AsyncRelayCommand(LoadMyEventsAsync);
        }

        private ObservableCollection<EventApiResponse> _myEvents;
        public ObservableCollection<EventApiResponse> MyEvents
        {
            get => _myEvents;
            set => SetProperty(ref _myEvents, value);
        }

        public IAsyncRelayCommand LoadMyEventsCommand { get; }


        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;


        [ObservableProperty]
        private string subContent;


        [ObservableProperty]
        private string type;

        [ObservableProperty]
        private DateTime date;

        [ObservableProperty]
        private bool status;

        [ObservableProperty]
        private bool imageUrl;

        [ObservableProperty]
        private string starttime;

        [ObservableProperty]
        private string endtime;

        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private IEnumerable<EventApiResponse> _events;

        [RelayCommand]
        private void AddEvent()
        {
            var entity = new EventApiResponse
            {
                Title = title,
                Description = description,
                SubContent = subContent,
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
        private void UpdateEvent()
        {
            var entity = new EventApiResponse
            {
                Title = title,
                Description = description,
                SubContent = subContent,
                Type = type,
                Date = date,
                Status = status,
                StartTime = starttime,
                EndTime = endtime,
                UserId = userId 

            };

            _eventApiService.Update(entity);
        }

        private async Task LoadMyEventsAsync()
        {
            var events = await _eventApiService.GetAll();
            MyEvents = new ObservableCollection<EventApiResponse>(events);
        }
    }
}

