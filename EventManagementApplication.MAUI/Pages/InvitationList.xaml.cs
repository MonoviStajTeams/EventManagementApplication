using EventManagementApplication.MAUI.Models.ViewModels;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementApplication.MAUI.Pages
{
    public partial class InvitationList : ContentPage
    {
       
        public InvitationList(InvitationViewModel ivm)
        {
            InitializeComponent();
            BindingContext = ivm;
        }
      
    }
}
