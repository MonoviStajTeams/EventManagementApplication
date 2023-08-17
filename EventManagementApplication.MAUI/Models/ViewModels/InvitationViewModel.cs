using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class InvitationViewModel : ObservableObject
    {
        private readonly IInvitationApiService _invitationApiService;

        public InvitationViewModel()
        {
            _invitationApiService = new InvitationApiService("Invitation");
            MyInvitationList = new ObservableCollection<InvitationApiResponse>();
            LoadMyEventsCommand = new AsyncRelayCommand(InvitationList);
            AcceptInvitationCommand = new AsyncRelayCommand(AcceptInvitation);
            CancelInvitationCommand = new AsyncRelayCommand(CancelInvitation);
            DeleteInvitationCommand = new AsyncRelayCommand(DeleteInvitation);
            InvitationList();
        }

        private ObservableCollection<InvitationApiResponse> _myInvitations;
        public ObservableCollection<InvitationApiResponse> MyInvitationList
        {
            get => _myInvitations;
            set => SetProperty(ref _myInvitations, value);
        }

        public IAsyncRelayCommand LoadMyEventsCommand { get; }
        public IAsyncRelayCommand AcceptInvitationCommand { get; }
        public IAsyncRelayCommand CancelInvitationCommand { get; }
        public IAsyncRelayCommand DeleteInvitationCommand { get; }


        [ObservableProperty]
        private string title;
  


        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private int eventId;

        [ObservableProperty]
        private int id;


        private async Task InvitationList()
        {
            var invitations = await _invitationApiService.GetAll();
            MyInvitationList = new ObservableCollection<InvitationApiResponse>(invitations);
        }


        [RelayCommand]
        private async Task AddInvitation()
        {
            var entity = new InvitationApiResponse
            {
                Title = title,
                Description = description,
                UserId = userId,
                EventId = eventId
            };
            _invitationApiService.Create(entity);
        }
       
        [RelayCommand]
        private async Task UpdateInvitation()
        {
            var entity = new InvitationApiResponse
            {
                Title = title,
                Description = description,
                UserId = userId,
                EventId = eventId
            };

            _invitationApiService.Update(entity);
        }

        [RelayCommand]
        private async Task DeleteInvitation()
        {
            await _invitationApiService.Delete(Id);
        }

        [RelayCommand]
        private async Task AcceptInvitation()
        {

        }

        [RelayCommand]
        private async Task CancelInvitation()
        {

        }


    }
}
