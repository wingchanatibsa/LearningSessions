using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using CoreML;
using Foundation;
using UIKit;

namespace BatteryRecorgnizer.iOS
{
    //reference url: https://github.com/DotNetToscana/CustomVisionCompanion/blob/master/Src/CustomVisionEngine/Platforms/iOS/OfflineClassifierImplementation.cs
    public class ImageClassifier
    {
        private MLModel _imageClassifierModel;
        private const int InputSize = 227;
        private const string InputName = "data";
        private const string OutputName = "loss";

        private const string ModelName = "batteryrecorgnizer";

        public ImageClassifier()
        {
            _imageClassifierModel = LoadModel(ModelName);
        }

        MLModel LoadModel(string modelName)
        {
            NSBundle bundle = NSBundle.MainBundle;
            var assetPath = bundle.GetUrlForResource(modelName, "mlmodelc");
            NSError err;

            var mdl = MLModel.Create(assetPath, out err);
            if (err != null)
            {
                Console.WriteLine("LoadModel Error: {0}", err);
            }
            return mdl;
        }

        public ImageClassificationResult RecognizeImage(UIImage imageSource)
        {
            var pixelBuffer = imageSource.Scale(new CGSize(InputSize, InputSize)).ToCVPixelBuffer();
            var imageValue = MLFeatureValue.Create(pixelBuffer);

            var inputs = new NSDictionary<NSString, NSObject>(new NSString(InputName), imageValue);

            NSError error, error2;
            var inputFp = new MLDictionaryFeatureProvider(inputs, out error);
            if (error != null)
            {
                Console.WriteLine("RecognizeImage Error 1: {0}", error);
                return null;
            }
            var outFeatures = _imageClassifierModel.GetPrediction(inputFp, out error2);
            if (error2 != null)
            {
                Console.WriteLine("RecognizeImage Error 2: {0}", error2);
                return null;
            }

            var predictionsDictionary = outFeatures.GetFeatureValue(OutputName).DictionaryValue;

            var outputs = new List<Tuple<double, string>>();
            foreach (var key in predictionsDictionary.Keys)
            {
                var description = (string)(NSString)key;
                var prob = (double)predictionsDictionary[key];
                outputs.Add(new Tuple<double, string>(prob, description));
            }

            var results = outputs
                .Select((t1, t2) => new ImageClassificationResult(t1.Item2, t1.Item1))
                .ToList();

            return results.OrderByDescending(t => t.Probability).First();
        }
    }
}
