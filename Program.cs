using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Classifiers;
using ConsoleApp1.Helpers;
using Microsoft.ML.Runtime.EntryPoints;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream1 = CsvHelper.GetInputFile("CourseClassifier.Resources", "training-data.csv");
            var trainingList = TestDataHelper.GetListOfTestData(stream1,true).ToList();

            var classifier = new MatchingWordCountClassifier();
            classifier.Train(trainingList);

            var stream2 = CsvHelper.GetInputFile("CourseClassifier.Resources", "test-data.csv");
            var testList = TestDataHelper.GetListOfTestData(stream2, true).ToList();
            var result = classifier.Classify(testList);
        }
    }
}
