using System;
namespace BatteryRecorgnizer.iOS
{
    public class ImageClassificationResult
    {
        public ImageClassificationResult(string predictedTag, double probability)
        {
            PredictedTag = predictedTag;
            Probability = probability;
        }

        public string PredictedTag { get; }

        public double Probability { get; }

        public override string ToString() => $"{PredictedTag} ({Math.Round(Probability * 100, 2)}%)";
    }
}
