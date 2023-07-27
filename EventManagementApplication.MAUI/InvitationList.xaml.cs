using EventManagementApplication.Entities.Concrete; // If needed, add the correct namespace for your Invitation class
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementApplication.MAUI
{
    public partial class InvitationList : ContentPage
    {
        // The Invitations property should be of type IEnumerable<Invitation>
        public IEnumerable<Invitation> Invitations { get; set; }

        public InvitationList()
        {
            InitializeComponent();

            // Replace this with your actual data retrieval logic to populate the Invitations collection
            // For demonstration purposes, I'll populate with mock data
            Invitations = GetMockInvitations();

            // Set the BindingContext to this page
            BindingContext = this;
        }

        private void ViewButton_Clicked(object sender, EventArgs e)
        {
            // Get the clicked invitation's Id from the command parameter
            if (sender is Button button && button.CommandParameter is int invitationId)
            {
                // Implement the modal display here based on the invitationId
                // You can use a separate method or navigate to a new page with the details
                // For simplicity, we'll just display an alert with the invitation's Id
                DisplayAlert("Invitation Details", $"Invitation Id: {invitationId}", "OK");
            }
        }

        // Replace this with your actual data retrieval logic to get invitations
        private IEnumerable<Invitation> GetMockInvitations()
        {
            return Enumerable.Range(1, 5).Select(i => new Invitation
            {
                Id = i,
                Title = $"Invitation {i}"
                // Add more properties as needed
            });
        }
    }
}
