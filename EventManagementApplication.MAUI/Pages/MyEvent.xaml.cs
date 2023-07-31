using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YourNamespace
{
    public partial class MyEvent : ContentPage
    {

        private MyEventViewModel viewModel;

        public MyEvent()
        {
            InitializeComponent();

            
            viewModel = new MyEventViewModel();
            BindingContext = viewModel;
        }

        
        private void OnEventClicked(object sender, EventArgs e)
        {
          

        }
    }
}

