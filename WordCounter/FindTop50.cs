using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PipesAndFilters4DotNet;

namespace WordCounter
{
    class FindTop50 : IOperation<Text>
    {
        public IEnumerable<Text> Execute(IEnumerable<Text> input)
        {
            foreach(Text t in input)
            {
                foreach (var word in t.WordCounts.OrderByDescending(kp => kp.Value).Take(50))
                    t.AddWordToTop50(word.Key);
            }

            return input;
        }
    }
}
