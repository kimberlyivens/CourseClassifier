using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp1.Domain;
using ConsoleApp1.Helpers;

namespace ConsoleApp1.Classifiers
{
    public  class MatchingWordCountClassifier
    {
        private Dictionary<string,List<string>> Model { get; set; }
        public void Train(List<TestData> items)
        {
            //get all subcategories
            var dictionary = new Dictionary<string, List<string>>();
            var uniqueSubcategories = items.Select(x => x.SubCategory).Distinct().ToList();

            // get list of all words used per subcategory
            uniqueSubcategories.ForEach(s => dictionary.Add(s, items.Where(y => y.SubCategory == s).Select(z => z.Name.Tokenize())
                .Aggregate<IEnumerable<string>>((previousList, nextList) => previousList.Union(nextList)).ToList()));
            Model = dictionary;
        }

        public double Classify(List<TestData> items)
        {
            var results = new List<bool>();
            foreach (var item in items)
            {
                results.Add(Classify(item));
            }

            return results.Count(x => x) / (double)items.Count;
        }

        private bool Classify(TestData item)
        {
            var results = new Dictionary<string,int>();
          

                var list = item.Name.Tokenize();
            foreach (var subCategory in Model.Keys)
            {
                foreach (var word in list)
                {
                    if (!Model[subCategory].Contains(word.Trim().ToLower())) continue;
                    if (results.ContainsKey(subCategory))
                    {
                        results[subCategory] = ++results[subCategory];
                    }
                    else
                    {
                        results.Add(subCategory,1);
                    }
                }
            }

            if (results.Keys.Count == 0) return false;
            var result = results.FirstOrDefault(x => x.Value.Equals(results.Values.Max())).Key;
            return result == item.SubCategory;
        }

        public void PrintModel()
        {
            var outputList = new List<string>();
            foreach (var item in Model)
            {
                outputList.Add(item.Key + " :");
                outputList.Add(string.Join(",", item.Value));

            }
            WriteHelper.WriteListToFile("wordsPerSubCategory.txt", outputList);
        }

    }
}
