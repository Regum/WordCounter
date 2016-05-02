using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    public class Text
    {
        private string fileName;
        private string originalText;
        private List<string> wordList;
        private Dictionary<string, long> wordCounts;
        private List<string> top50;
        private Dictionary<string, List<int>> frequencies;

        //Default constructor
        public Text()
        {
            originalText = "";
            wordList = new List<string>();
            wordCounts = new Dictionary<string, long>();
            top50 = new List<string>();
            frequencies = new Dictionary<string, List<int>>();
        }

        //Adds the given string to wordList
        public void AddWordToTextList(string word)
        {
            wordList.Add(word);
        }

        //Takes account of word by adding it to wordCounts.
        public void CountWord(string word)
        {
            if (wordCounts.ContainsKey(word))
                ++wordCounts[word];
            else
                wordCounts.Add(word, 1);
        }

        public void AddWordToTop50(string word)
        {
            top50.Add(word);
            frequencies.Add(word, new List<int>());
        }

        //Logs a frequency for a word.
        public void AddFrequency(string word, int blockNum, int frequency)
        {
            frequencies[word].Add(frequency);
        }

        //Returns the list of frequencies for a word.
        public List<int> GetFrequencies(string word)
        {
            return frequencies[word];
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string OriginalText
        {
            get { return originalText; }
            set { originalText = value; }
        }

        public List<string> WordList
        {
            get { return wordList; }
            set { wordList = value; }
        }

        public Dictionary<string, long> WordCounts
        {
            get { return wordCounts; }
            set { wordCounts = value; }
        }

        public List<string> Top50
        {
            get { return top50; }
            set { top50 = value; }
        }

        public Dictionary<string, List<int>> Frequencies
        {
            get { return frequencies; }
            set { frequencies = value; }
        }
    }
}
