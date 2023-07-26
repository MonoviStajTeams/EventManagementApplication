namespace EventManagementApplication.MAUI;

public partial class AddInvitation : ContentPage
{
	public AddInvitation()
	{
		InitializeComponent();
	}
    private void OnAddInvitationClicked(object sender, EventArgs e)
    {
        string title = Title.Text;
        string description = Description.Text;
    }
}