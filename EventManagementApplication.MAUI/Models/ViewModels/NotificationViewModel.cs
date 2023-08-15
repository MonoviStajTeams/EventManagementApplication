using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class NotificationViewModel : ObservableObject
    {
        private INotificationApiService _notificationApiService;

      

       
        public NotificationViewModel(INotificationApiService notificationApiService)
        {
            _notificationApiService = notificationApiService;
            MyNotifications = new ObservableCollection<NotificationApiResponse>();
            LoadMyNotificationsCommand = new AsyncRelayCommand(FetchNotification);
        }


        private ObservableCollection<NotificationApiResponse> _myNotifications;
        public ObservableCollection<NotificationApiResponse> MyNotifications
        {
            get => _myNotifications;
            set => SetProperty(ref _myNotifications, value);
        }

        public IAsyncRelayCommand LoadMyNotificationsCommand { get; }


        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private int receivindid;
        
        [ObservableProperty]
        private int invitationid;

        [ObservableProperty]
        private DateTime createddate;

  

        [RelayCommand]
        private async Task FetchNotification()
        {
            var notificationList = await _notificationApiService.GetAll();
            MyNotifications = new ObservableCollection<NotificationApiResponse>(notificationList);
        }

        [RelayCommand]
        private async Task DeleteNotification()
        {

            await _notificationApiService.Delete(id).ConfigureAwait(false);
        }

    }
}
