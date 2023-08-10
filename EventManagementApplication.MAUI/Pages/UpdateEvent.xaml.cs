using EventManagementApplication.MAUI.Models.ViewModels;

namespace EventManagementApplication.MAUI
{
    public partial class UpdateEvent : ContentPage
    {
        public UpdateEvent(EventViewModel evm)
        {
            InitializeComponent();
            BindingContext = evm;
        }

       
    }
}
