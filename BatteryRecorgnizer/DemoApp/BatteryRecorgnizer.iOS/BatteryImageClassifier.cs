using System;
using System.Threading.Tasks;
using BatteryRecorgnizer.iOS;
using Foundation;
using Plugin.Media.Abstractions;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(BatteryImageClassifier))]
namespace BatteryRecorgnizer.iOS
{
    public class BatteryImageClassifier : IBatteryImageClassifier
    {
        ImageClassifier _imageClassifier;
        public BatteryImageClassifier()
        {
            _imageClassifier = new ImageClassifier();
        }

        public async Task<string> GetImageNameByImage(MediaFile image)
        {
            var stream = image.GetStream();
            var imageData = NSData.FromStream(stream);
            var uIImage = UIImage.LoadFromData(imageData);

            var result = await Task.Run(() => _imageClassifier.RecognizeImage(uIImage));

            return result.ToString();
        }
    }
}
