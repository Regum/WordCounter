using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipesAndFilters4DotNet;

namespace WordCounter
{
    public class TextBreaker : IOperation<Text>
    {
        public IEnumerable<Text> Execute(IEnumerable<Text> input)
        {
            foreach(Text t in input)
            {
                string[] wordArray = t.OriginalText.Split();

                for(int i = 0; i < wordArray.Length; ++i)
                    t.AddWordToTextList(wordArray[i].ToLower());
            }

            return input;
        }
    }
}
