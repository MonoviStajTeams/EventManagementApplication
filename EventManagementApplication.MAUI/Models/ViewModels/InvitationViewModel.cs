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

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class InvitationViewModel : ObservableObject
    {
        private readonly IInvitationApiService _invitationApiService;

        public InvitationViewModel()
        {
            _invitationApiService = new InvitationApiService("invitation");
        }

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
        [RelayCommand]
        private async Task AddInvitation()
        {
            var entity = new InvitationApiResponse
            {
                Title = title,
                Description = description,
                UserId = userid,
                EventId = eventid
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
                UserId = userid,
                EventId = eventid
            };

            _invitationApiService.Update(entity);
        }
    }
}
