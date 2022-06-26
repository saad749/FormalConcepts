using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.Algorithm.Entities
{
    [DebuggerDisplay("{ConceptName} - {Gain}")]
    internal class OptimalConcept
    {
        public string ConceptName 
        {
            get 
            {
                return Keywords.Aggregate((i1, i2) => i1.RootWordFrequency > i2.RootWordFrequency ? i1 : i2).Keyword;
            }
            private set { }
        }
        public int ConceptNumber { get; set; }
        public HashSet<SentenceNode> Sentences { get; set; }
        public HashSet<KeywordNode> Keywords { get; set; }
        public double Gain 
        { 
            get 
            {
                int r = Sentences.Count * Keywords.Count;
                int d = Keywords.Count;
                int c = Sentences.Count;
                return (r / (d*c)) * (r - (d + c));
            }
            private set { }
        }

        public OptimalConcept(int conceptNumber, HashSet<SentenceNode> sentences, HashSet<KeywordNode> keywords)
        {
            ConceptNumber = conceptNumber;
            Sentences = sentences;
            Keywords = keywords;
        }
    }
}
