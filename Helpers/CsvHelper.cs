using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ConsoleApp1.Helpers
{
    public static class CsvHelper
    {
        public static StreamReader GetInputFile(string path, string filename)
        {
            var thisAssembly = Assembly.GetCallingAssembly();
            var stream = thisAssembly.GetManifestResourceStream(path + "." + filename);
            if (stream == null)
                throw new Exception($"The resource {filename} was not loaded properly.");

            return new StreamReader(stream);
        }
    }
}
