using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI
{
    public partial class EventList: ContentPage
    {
        public EventList()
        {
            InitializeComponent();
        }
        private void OnEventClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var eventId = (int)button.CommandParameter;

            var eventSinglePage = new EventSinglePage();
            eventSinglePage.BindingContext = eventId;

            Navigation.PushAsync(eventSinglePage);
        }
    }
}
