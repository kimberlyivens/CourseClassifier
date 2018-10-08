using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1.Helpers
{
    public static class WriteHelper
    {
        public static void WriteListToFile( string filename, List<string> list)
        {
            var myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(myDocPath, filename)))
            {
                foreach (var line in list)
                {
                    outputFile.WriteLine(line);
                }
            }
        }
    }
}
