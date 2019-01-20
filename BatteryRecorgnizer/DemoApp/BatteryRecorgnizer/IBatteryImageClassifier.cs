using System;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace BatteryRecorgnizer
{
    public interface IBatteryImageClassifier
    {
        Task<string> GetImageNameByImage(MediaFile image);
    }
}
