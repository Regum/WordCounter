using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PipesAndFilters4DotNet;

namespace WordCounter
{
    public class GetTexts : IOperation<Text>
    {
        public IEnumerable<Text> Execute(IEnumerable<Text> input)
        {
            List<Text> output = new List<Text>();
            
            string dirPath = Environment.GetCommandLineArgs()[1];

            Text t;
            
            try
            {
                DirectoryInfo di = new DirectoryInfo(dirPath);

                foreach(var file in di.GetFiles("*.txt"))
                {
                    t = new Text();
                    t.FileName = file.Name;
                    using (StreamReader sr = new StreamReader(file.OpenRead()))
                    {
                        t.OriginalText = sr.ReadToEnd();
                        output.Add(t);
                    }
                }
                
            }
            catch(Exception e)
            {
                Console.Write(e.StackTrace);
            }

            return output;
        }
    }
}
