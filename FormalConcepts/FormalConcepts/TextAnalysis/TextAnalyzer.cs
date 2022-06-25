using FormalConcepts.TextAnalysis.Stemmers;
using Iso639;
using Snowball;
using StopWord;
using System.Text;
using System.Text.RegularExpressions;

namespace FormalConcepts.TextAnalysis
{
    internal class TextAnalyzer
    {
        public Language Language { get; set; }
        public IStemmer Stemmer { get; set; }

        public TextAnalyzer(string language_iso639_3)
        {
            Language = Language.FromPart3(language_iso639_3);
            Stemmer = GetStemmer(Language.Part3);
        }

        public IStemmer GetStemmer(string language_iso639_3)
        {
            switch (language_iso639_3)
            {
                case "ara":
                    return new ArabicStemmer();
                case "hye":
                    return new ArmenianStemmer();
                case "eus":
                    return new BasqueStemmer();
                case "cat":
                    return new CatalanStemmer();
                case "dan":
                    return new DanishStemmer();
                case "nld":
                    return new DutchStemmer();
                case "eng":
                    return new EnglishStemmer();
                case "fin":
                    return new FinnishStemmer();
                case "fra":
                    return new FrenchStemmer();
                case "deu":
                    return new GermanStemmer();
                case "ell":
                    return new GreekStemmer();
                case "hin":
                    return new HindiStemmer();
                case "hun":
                    return new HungarianStemmer();
                case "ind":
                    return new IndonesianStemmer();
                case "gle":
                    return new IrishStemmer();
                case "ita":
                    return new ItalianStemmer();
                case "lit":
                    return new LithuanianStemmer();
                case "nep":
                    return new NepaliStemmer();
                case "nor":
                    return new NorwegianStemmer();
                case "por":
                    return new PortugueseStemmer();
                case "ron":
                    return new RomanianStemmer();
                case "rus":
                    return new RussianStemmer();
                case "srp":
                    return new SerbianStemmer();
                case "spa":
                    return new SpanishStemmer();
                case "swe":
                    return new SwedishStemmer();
                case "tam":
                    return new TamilStemmer();
                case "tur":
                    return new TurkishStemmer();
                case "yid":
                    return new YiddishStemmer();
                case "none":
                    return new NoStemmer();
                default:
                    return null;

            }
        }

        public string Stem(string word)
        {
            return Stemmer.Stem(word);
        }

        public List<String> GetSentences(string text)
        {
            char[] delimiters = new char[] { '.' };
            List<string> sentences = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
            return sentences;
        }

        public List<string> Tokenizer(string sentence)
        {
            List<string> keywords = new List<string>();
            char[] splitChars =
                new char[] { ',', ' ', '\r', '\n', '\t', '©', '-', '<', '>', '/', '\\', '.', '(', ')', '?', '@', '^', '#', '%', '&', '*', '$', '!', ';', ':', '\"', '{', '}', '~', '\'', '[', ']', '“' };

            string[] tokens = TryRemoveStopWords(sentence).Split(splitChars);
            foreach (String word in tokens)
            {
                if (word.Length > 1)
                {
                    String root = Stemmer.Stem(word);
                    if (!String.IsNullOrEmpty(TryRemoveStopWords(root)))
                        keywords.Add(word); //Should we add word or root?
                }
            }
            return keywords;
        }

        public List<string> ExtractWords(string sentence)
        {
            char[] splitChars =
                new char[] { ',', ' ', '\r', '\n', '\t', '©', '-', '<', '>', '/', '\\', '.', '(', ')', '?', '@', '^', '#', '%', '&', '*', '$', '!', ';', ':', '\"', '{', '}', '~', '\'', '[', ']', '“' };

            string[] words = TryRemoveStopWords(sentence).Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

            return words.ToList();
        }

        public string RemoveDiacritics(string InputStr)
        {
            string BasicStr = InputStr.Normalize(NormalizationForm.FormD);
            string TempStr = "";
            for (int i = 0; i < BasicStr.Length; i++)
            {
                if (char.GetUnicodeCategory(BasicStr[i]) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    TempStr += BasicStr[i];
            }
            return TempStr;
        }

        public string TryRemoveStopWords(string text)
        {
            try
            {
                return text.RemoveStopWords(Language.Part1);
            }
            catch (ArgumentException ex) //The Language is not supported exception
            {
                return text;
            }
        }

        

    }
}
