using Xamarin.Forms;

namespace BatteryRecorgnizer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new BatteryPageViewModel();
        }
    }
}
