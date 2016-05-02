using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using PipesAndFilters4DotNet;

namespace WordCounter
{
    public class WordTrimmer : IOperation<Text>
    {
        public IEnumerable<Text> Execute(IEnumerable<Text> input)
        {
            foreach(Text t in input)
            {
                //Remove punctuation other than hyphens and apostrophes.
                for (int i = 0; i < t.WordList.Count; ++i)
                    t.WordList[i] = Regex.Replace(t.WordList[i], @"[^a-z-']", "");

                //Remove any empty strings or whitespace.
                t.WordList.RemoveAll(s => String.IsNullOrWhiteSpace(s));
            }

            return input;
        }
    }
}
