using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI
{
    public partial class ProfilePage: ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        private async void BacktoMainPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
