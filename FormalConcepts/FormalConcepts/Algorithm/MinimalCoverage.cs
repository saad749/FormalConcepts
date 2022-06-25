using FormalConcepts.Algorithm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.Algorithm
{
    public static class MinimalCoverage
    {
        public static void Extract(string text, string language_iso639_3)
        {
            BinaryRelation binaryRelation = new BinaryRelation(text, language_iso639_3);
        }
    }
}
