namespace EventManagementApplication.MAUI;

public partial class UpdateInvitation : ContentPage
{
	public UpdateInvitation()
	{
		InitializeComponent();
	}
    private void OnUpdateInvitationClicked(object sender, EventArgs e)
    {
        string title = invitationTitle.Text;
        string description = invitationDescription.Text;
    }
}