using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.Algorithm.Entities
{
    [DebuggerDisplay("{SentenceIndex}. {SentenceText}")]
    internal class SentenceNode
    {
        public int SentenceIndex { get; set; }
        public string SentenceText { get; set; }
        public HashSet<KeywordNode> AssociatedKeywords { get; set; }
        public HashSet<OptimalConcept> CoveredByConcepts { get; set; }

        public SentenceNode(int setenceIndex, string sentenceText, HashSet<KeywordNode> associatedKeywords)
        {
            SentenceIndex = setenceIndex;
            SentenceText = sentenceText;
            AssociatedKeywords = associatedKeywords;
        }
    }
}
