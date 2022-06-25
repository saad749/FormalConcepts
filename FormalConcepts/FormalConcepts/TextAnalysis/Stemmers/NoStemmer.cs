using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.TextAnalysis.Stemmers
{
    public class NoStemmer : IStemmer
    {
        public string Stem(string input)
        {
            return input;
        }
    }
}