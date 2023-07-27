using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.ViewModels
{
    public partial class ForgotPasswordViewModel: ObservableObject
    {
        [ObservableProperty]
        private string email;


        [RelayCommand]
        private async Task FetchForgotPasswordInfo()
        {
        }
    }
}
