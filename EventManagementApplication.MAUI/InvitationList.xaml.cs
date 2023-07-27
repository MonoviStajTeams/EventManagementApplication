using EventManagementApplication.Entities.Concrete; 
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementApplication.MAUI
{
    public partial class InvitationList : ContentPage
    {
        public IEnumerable<Invitation> Invitations { get; set; }

        public InvitationList()
        {
            InitializeComponent();
            Invitations = GetMockInvitations();

            BindingContext = this;
        }

        private void ViewButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int invitationId)
            {
                DisplayAlert("Invitation Details", $"Invitation Id: {invitationId}", "OK");
            }
        }

        private IEnumerable<Invitation> GetMockInvitations()
        {
            return Enumerable.Range(1, 5).Select(i => new Invitation
            {
                Id = i,
                Title = $"Invitation {i}"
            });
        }
    }
}
