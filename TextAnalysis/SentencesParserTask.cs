using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static readonly string[] StopWords =
        {
            "the", "and", "to", "a", "of", "in", "on", "at", "that", "as", "but", "with", "out", "for", "up", "one",
            "from", "into"
        };

        /*
        Разбейте файл с текстом на предложения и слова. 
        Считайте, что слова могут состоять только из букв (используйте метод char.IsLetter) или символа апострофа ',
        а предложения разделены одним из следующих символов .!?;:()
        Удалите из файла слова, содержащиеся в массиве StopWords (частые незначащие слова при анализе текстов называют 
        стоп-словами).
        Метод должен возвращать список предложений, где каждое предложение — это список оставшихся слов в нижнем 
        регистре.
        */
        public static List<List<string>> ParseSentences(string text)
        {
            var sep1 = new[] {'.', '!', '?', ';', ':', '(', ')'};
            var result = new List<List<string>>();

            foreach (var i in text.Split(sep1, StringSplitOptions.RemoveEmptyEntries))
            {
                var k = SplitWords(i);
                k.RemoveAll(x => (StopWords.Contains(x) || string.IsNullOrEmpty(x)));

                if (k.Any())
                {
                    result.Add(k);
                }
            }

            return result;
        }

        private static List<string> SplitWords(string lst)
        {
            var str = new StringBuilder();
            var res = new List<string>();
            foreach (var s in lst)
            {
                if (char.IsLetter(s) || s.Equals('\''))
                {
                    str.Append(char.ToLower(s));
                }
                else
                {
                    if (string.IsNullOrEmpty(str.ToString())) continue;
                    res.Add(str.ToString());
                    str.Clear();
                }
            }

            res.Add(str.ToString());
            return res;
        }
    }
}