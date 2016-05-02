using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PipesAndFilters4DotNet;

namespace WordCounter
{
    class WordFrequency : IOperation<Text>
    {
        public IEnumerable<Text> Execute(IEnumerable<Text> input)
        {
            long numWords, blockEnd;
            int currFreq, topCount;
            string word;

            //Iterate over texts.
            foreach(Text t in input)
            {
                numWords = t.WordList.Count;
                topCount = t.Top50.Count;

                //Iterate over author's top 50 words.
                for (int i = 0; i < topCount; ++i)
                {
                    word = t.Top50[i];
                    

                    //Iterate over 5000 word blocks.
                    for (int j = 0; j < numWords; j += 5000)
                    {
                        currFreq = 0;
                        blockEnd = j + 5000;

                        //Iterate over words in block, looking for matches.
                        for (int k = j; k < blockEnd && k < numWords; ++k)
                        {
                            if (t.WordList[k] == word)
                                ++currFreq;
                        }

                        //Log word frequency for the current block.
                        t.AddFrequency(word, j / 5000, currFreq);
                    }
                }

                Junction.AddText(t);
            }

            
            yield break;
        }
    }
}
