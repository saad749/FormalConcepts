using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.Algorithm.Entities
{
    internal class OptimalConcept
    {
        public string ConceptName { get; set; }
        public int ConceptNumber { get; set; }
        public List<SentenceNode> Sentences { get; set; }
        public List<KeywordNode> Keywords { get; set; }
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
    }
}
