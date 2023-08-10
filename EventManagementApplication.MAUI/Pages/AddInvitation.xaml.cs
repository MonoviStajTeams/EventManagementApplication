using EventManagementApplication.MAUI.Models.ViewModels;

namespace EventManagementApplication.MAUI;

public partial class AddInvitation : ContentPage
{
	public AddInvitation(InvitationViewModel ivm)
	{
		InitializeComponent();
        BindingContext = ivm;
	}
    private void OnAddInvitationClicked(object sender, EventArgs e)
    {
        string title = Title.Text;
        string description = Description.Text;
    }
}