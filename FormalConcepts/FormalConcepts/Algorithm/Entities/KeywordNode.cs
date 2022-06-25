using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.Algorithm.Entities
{
    internal class KeywordNode
    {
        public int KeywordIndex { get; set; }
        public string Keyword 
        { 
            get
            {
                return RepresentingWords.Aggregate((i1, i2) => i1.Frequency > i2.Frequency ? i1 : i2).Word;
            }
            private set { } 
        }
        public string RootWord { get; set; }
        //public double KeywordRank { get; set; }
        public List<WordNode> RepresentingWords { get; set; }
        public HashSet<SentenceNode> AssociatedSentences { get; set; }
        public int RootWordFrequency { get; set; }

        public KeywordNode(int keywordIndex, string rootWord, string word)
        {
            KeywordIndex = keywordIndex;
            RootWord = rootWord;
            RepresentingWords = new List<WordNode>();
            RepresentingWords.Add(new WordNode { Word = word, Frequency = 1 });
            RootWordFrequency = 1;
            AssociatedSentences = new HashSet<SentenceNode>();
        }
    }
}
