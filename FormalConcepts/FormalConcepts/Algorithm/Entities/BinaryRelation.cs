using FormalConcepts.TextAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalConcepts.Algorithm.Entities
{
    internal class BinaryRelation
    {
        public HashSet<SentenceNode> Sentences { get; set; }
        public HashSet<KeywordNode> Keywords { get; set; }
        public HashSet<OptimalConcept> OptimalConcepts { get; set; }

        public BinaryRelation(string text, string language_iso639_3)
        {
            Sentences = new HashSet<SentenceNode>();
            Keywords = new HashSet<KeywordNode>();
            CreateBinaryRelation(text, language_iso639_3);
        }

        public void CreateBinaryRelation(string text, string language_iso639_3)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer(language_iso639_3);
            List<string> sentenceStrings = textAnalyzer.GetSentences(text);
            int sentenceIndex = 0;
            int keywordIndex = 0;

            foreach (string sentenceString in sentenceStrings)
            {
                List<string> words = textAnalyzer.ExtractWords(sentenceString);
                HashSet<KeywordNode> keywordNodesInSentence = new HashSet<KeywordNode>();
                foreach (string word in words)
                {
                    string root = textAnalyzer.Stem(word);
                    bool rootWordExists = Keywords.Any(k => k.RootWord.ToLower(textAnalyzer.Language.Culture) == root.ToLower(textAnalyzer.Language.Culture));
                    if (!rootWordExists)
                    {
                        KeywordNode keywordNode = new KeywordNode(keywordIndex, root, word);
                        keywordNodesInSentence.Add(keywordNode);
                        keywordIndex++;
                    }
                    else
                    {
                        KeywordNode keywordNode = Keywords.Single(k => k.RootWord.ToLower(textAnalyzer.Language.Culture) == root.ToLower(textAnalyzer.Language.Culture));
                        keywordNode.RootWordFrequency++;

                        WordNode? wordNode = keywordNode.RepresentingWords.SingleOrDefault(k => k.Word.ToLower(textAnalyzer.Language.Culture) == word.ToLower(textAnalyzer.Language.Culture));
                        if (wordNode != null)
                        {
                            wordNode.Frequency++;
                        }
                        else
                        {
                            keywordNode.RepresentingWords.Add(new WordNode { Word = word, Frequency = 1 });
                        }


                        keywordNodesInSentence.Add(keywordNode);
                    }
                }

                SentenceNode sentenceNode = new SentenceNode(sentenceIndex, sentenceString, keywordNodesInSentence);

                foreach (KeywordNode node in keywordNodesInSentence)
                {
                    node.AssociatedSentences.Add(sentenceNode);
                }

                sentenceIndex++;

                Keywords.UnionWith(keywordNodesInSentence);
                Sentences.Add(sentenceNode);

            }

        }
    }
}
