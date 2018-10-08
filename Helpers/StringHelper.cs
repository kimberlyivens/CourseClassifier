using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Helpers
{
    public static class StringHelper
    {
        public static List< string> Tokenize(this string input)
        {
            var punctuationMarks = new Regex(@"[\p{P}\p{S}]");
            var lineSplitter = new Regex(@"(?<=[.,;\!\?""“”])|(?=[.,;\!\?""“”'])|\s");
            var splittedSentence = lineSplitter.Split(input).Where(s => !string.IsNullOrWhiteSpace(s));
            var result = splittedSentence.Where(x => !punctuationMarks.IsMatch(x)).ToList();
            return result;
        }
    }
}
