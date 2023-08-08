namespace EventManagementApplication.MAUI
{
    public partial class UpdateEvent : ContentPage
    {
        public UpdateEvent()
        {
            InitializeComponent();

            // Bağlam ve olaylar tanımlanabilir
            // Örneğin, Button'un tıklanma olayına bir işlev eklemek
            UpdateCommand = new Command(UpdateEventDetails);
            BindingContext = this;
        }

        // ViewModel veya sayfa üzerindeki işlevler için özellikler
        public Command UpdateCommand { get; }

        private void UpdateEventDetails()
        {
            // Burada, gerekli güncelleme işlemleri gerçekleştirilir
            // Örneğin, Entry'lerden verileri alarak bir etkinliği güncellemek
            string eventTitle = eventTitleEntry.Text;
            string eventDescription = eventDescriptionEntry.Text;
            string eventSubContent = eventSubContentEntry.Text;
            DateTime eventDate = eventDatePicker.Date;
            TimeSpan startTime = eventStartTimePicker.Time;
            TimeSpan endTime = eventEndTimePicker.Time;
            bool isActive = statusActiveRadioButton.IsChecked;

            // Güncelleme işlemlerini gerçekleştir

            // Başarılı güncelleme durumunu görüntüleme
            eventUpdatedMessageLabel.IsVisible = true;
        }
    }
}
}