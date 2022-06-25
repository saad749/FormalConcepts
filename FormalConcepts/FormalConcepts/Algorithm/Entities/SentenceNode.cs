using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.Algorithm.Entities
{
    internal class SentenceNode
    {
        public int SetenceIndex { get; set; }
        public string SentenceText { get; set; }
        public HashSet<KeywordNode> AssociatedKeywords { get; set; }

        public SentenceNode(int setenceIndex, string sentenceText, HashSet<KeywordNode> associatedKeywords)
        {
            SetenceIndex = setenceIndex;
            SentenceText = sentenceText;
            AssociatedKeywords = associatedKeywords;
        }
    }
}
