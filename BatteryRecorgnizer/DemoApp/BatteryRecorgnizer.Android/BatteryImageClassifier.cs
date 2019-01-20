using System;
using System.Threading.Tasks;
using Android.Graphics;
using BatteryRecorgnizer.Droid;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(BatteryImageClassifier))]
namespace BatteryRecorgnizer.Droid
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
            var bitmap = await BitmapFactory.DecodeStreamAsync(
                    image.GetStreamWithImageRotatedForExternalStorage()
                );

            var result = await Task.Run(() => _imageClassifier.RecognizeImage(bitmap));

            return result.ToString();
        }
    }
}
