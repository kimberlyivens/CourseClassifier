using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using ConsoleApp1.Domain;

namespace ConsoleApp1.Helpers
{
    public static class TestDataHelper
    {
        public static IEnumerable<TestData> GetListOfTestData(StreamReader stream,bool hasHeader)
        {
            using (var reader = stream)
            {
                var list = new List<TestData>();

                if (hasHeader)
                {
                    reader.ReadLine();
                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    list.Add(new TestData()
                    {
                        Category = values[0],
                        SubCategory = values[1],
                        Name = values[4]
                    });

                }

                return list;
            }
        }
    }
}
