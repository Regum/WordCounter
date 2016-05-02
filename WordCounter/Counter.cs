using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PipesAndFilters4DotNet;

namespace WordCounter
{
    public class Counter : IOperation<Text>
    {
        public IEnumerable<Text> Execute(IEnumerable<Text> input)
        {
            foreach (Text t in input)
                foreach (string word in t.WordList)
                {
                    if(!StopWordFilter.IsStopWord(word))
                        t.CountWord(word);
                }
                    
            return input;
        }
    }
}
