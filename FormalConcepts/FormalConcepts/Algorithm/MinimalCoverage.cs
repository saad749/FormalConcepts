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
            ExtractOptimalConcepts(binaryRelation);


        }

        internal static void ExtractOptimalConcepts(BinaryRelation binaryRelation)
        {
            int conceptNumber = 0;
            foreach (SentenceNode sentence in binaryRelation.Sentences)
            {
                foreach(KeywordNode keyword in sentence.AssociatedKeywords)
                {
                    var associatedSentences = keyword.AssociatedSentences;
                    var keywordsInAssociatedSentences = associatedSentences.SelectMany(sentence => sentence.AssociatedKeywords);

                    var intersection = keywordsInAssociatedSentences.Intersect(sentence.AssociatedKeywords);

                    if(intersection.Count() > 0)
                    {
                        // Concept Found?

                        binaryRelation.OptimalConcepts.Add(
                            new OptimalConcept(
                                conceptNumber,
                                intersection.SelectMany(i => i.AssociatedSentences).ToHashSet(),
                                intersection.ToHashSet()
                                )
                            );
                    }
                }
            }
        }
    }
}
