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
            _eventApiService = new EventApiService("Event");
            MyEvents = new ObservableCollection<EventApiResponse>();
            LoadMyEventsCommand = new AsyncRelayCommand(LoadMyEventsAsync);
            LoadMyEventsAsync();
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
        private int id;

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
        private string startTime;

        [ObservableProperty]
        private string endTime;

        [ObservableProperty]
        private int userId;

        



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
                StartTime = startTime,
                EndTime = endTime,
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
                StartTime = startTime,
                EndTime = endTime,
                UserId = userId

            };

            _eventApiService.Update(entity);
        }

        
        public async Task LoadMyEventsAsync()
        {
            var events = await _eventApiService.GetAll();
            MyEvents = new ObservableCollection<EventApiResponse>(events);
        }

        [RelayCommand]
        public async Task GetEventById(int eventId)
        {
            var eventDetail = await _eventApiService.GetById(eventId);

            Title = eventDetail.Title;
            Description = eventDetail.Description;
            SubContent = eventDetail.SubContent;
            Type = eventDetail.Type;
            Date = eventDetail.Date;
            Status = eventDetail.Status;
            StartTime = eventDetail.StartTime;
            EndTime = eventDetail.EndTime;
            UserId = eventDetail.UserId;




        }
    }
}

