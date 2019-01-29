using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace BatteryRecorgnizer
{
    public class BatteryPageViewModel : INotifyPropertyChanged
    {
        public BatteryPageViewModel()
        {
            Result = "Result Text";
        }

        private Command _selectPhotoCommand;
        public Command SelectPhotoCommand
        {
            get
            {
                return _selectPhotoCommand ?? (_selectPhotoCommand = new Command(ExecuteSelectPhotoCommand));
            }
        }

        ImageSource _batteryImageSource;
        public ImageSource BatteryImageSource
        {
            get
            {
                return _batteryImageSource;
            }
            set
            {
                if (value != _batteryImageSource)
                {
                    _batteryImageSource = value;
                    OnPropertyChanged(nameof(BatteryImageSource));
                }
            }
        }

        private async void ExecuteSelectPhotoCommand(object execute)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                Result = "Cannot select photos from the device.";
                return;
            }

            try
            {
                var image = await CrossMedia.Current.PickPhotoAsync(
                       new PickMediaOptions { PhotoSize = PhotoSize.Medium }
                    );

                BatteryImageSource = ImageSource.FromStream(() =>
                {
                    var stream = image.GetStream();
                    image.Dispose();
                    return stream;
                });

                var batteryImageClassifier = DependencyService.Get<IBatteryImageClassifier>();
                var result = await batteryImageClassifier.GetImageNameByImage(image);

                Result = result;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }
        }

        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (value != _result)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
