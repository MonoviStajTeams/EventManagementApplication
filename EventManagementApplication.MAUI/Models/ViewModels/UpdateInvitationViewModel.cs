using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.MAUI.Models.ApiModels;
using EventManagementApplication.MAUI.Services.Abstract;
using EventManagementApplication.MAUI.Services.Concrete;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class UpdateInvitationViewModel :ObservableObject
    {
        private readonly IInvitationService _ınvitationService;
        private readonly IInvitationApiService _ınvitationApiService;
        public UpdateInvitationViewModel()
        {
            _ınvitationApiService = new InvitationApiService("Invitation");
        }
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private int userId;
        
        [ObservableProperty]
        private int eventId;
        //[ObservableProperty]
        //private Event event;
        //[ObservableProperty]
        //private User user;



        [RelayCommand]
        private void UpdateInvitation()
        {
            var entity = new InvitationApiResponse
            {
                Title = title,
                Description = description,
                UserId = userId,
                EventId = eventId,               
                             
            };
            
        }

    }
}
