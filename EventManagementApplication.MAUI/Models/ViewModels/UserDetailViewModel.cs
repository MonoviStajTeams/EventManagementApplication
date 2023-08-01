using CommunityToolkit.Mvvm.ComponentModel;
using EventManagementApplication.MAUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Models.ViewModels
{
    public partial class UserDetailViewModel : ObservableObject
    {
        private readonly IUserDetailApiService _userDetailApiService;

        public UserDetailViewModel(IUserDetailApiService userDetailApiService)
        {
            _userDetailApiService = userDetailApiService;
        }

        [ObservableProperty]
        private string phonenumber;

        [ObservableProperty]
        private string profileimagepath;

        [ObservableProperty]
        private int userid;

        [ObservableProperty]
        private int id;

        private Task<ApiModels.UserDetailApiResponse> GetUserDetail()
        {
            var userDetail = _userDetailApiService.GetById(id);
            return userDetail;
        }
        



        

    }
}
