using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PipesAndFilters4DotNet;

namespace WordCounter
{
    class WordPipeline : Pipeline<Text>
    {
        public WordPipeline()
        {
            Register(new GetTexts());
            Register(new TextBreaker());
            Register(new WordTrimmer());
            Register(new Counter());
            Register(new FindTop50());
            Register(new WordFrequency());
        }

    }
}
