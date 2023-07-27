namespace EventManagementApplication.MAUI
{
    public partial class AddEvent : ContentPage
    {
        public AddEvent()
        {
            InitializeComponent();
           
        }
        private async void AddEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateEvent());
        }
    }
}