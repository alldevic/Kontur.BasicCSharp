using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class BigramGeneratorTask
    {
        /*
        По словарю, созданному в предыдущей задаче и по первому слову фразы 
        продолжите фразу до длины phraseWordsCount слов так, чтобы каждое следующее 
        слово определялось предыдущим по переданному словарю.
        
        Если в какой-то момент по словарю продолжить фразу нельзя, то на этом месте фразу нужно закончить.
        */
        public static string ContinuePhraseWithBigramms(Dictionary<string, string> mostFrequentNextWords,
            string phraseBeginning, int phraseWordsCount)
        {
            var res = new StringBuilder(phraseBeginning);
            var lastStr = phraseBeginning;
            for (var i = 1; i < phraseWordsCount; i++)
            {
                if (!mostFrequentNextWords.ContainsKey(lastStr))
                {
                    break;
                }

                res.Append($" {mostFrequentNextWords[lastStr]}");
                lastStr = mostFrequentNextWords[lastStr];
            }

            return res.ToString();
        }
    }
}