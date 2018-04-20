using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        /*
        Постройте по тексту словарь наиболее вероятного продолжения текста.

        Ключи этого словаря — это все слова, с которых начинается хотя бы одна биграмма исходного текста.
        В качестве значения должно быть второе слово самой частой биграммы, начинающейся с ключа.
        Если есть несколько биграмм с одинаковой частотой, то использовать лексикографически первую
        (используйте способ сравнения Ordinal, например с помощью метода string.CompareOrdinal).
        */

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var freqs = CalculateFreq(text);
            var res = new Dictionary<string, string>();

            foreach (var keyValuePair in freqs)
            {
                res[keyValuePair.Key] = GetOrdinalMax(keyValuePair.Value);
            }

            return res;
        }

        private static Dictionary<string, Dictionary<string, int>> CalculateFreq(List<List<string>> text)
        {
            var res = new Dictionary<string, Dictionary<string, int>>();

            text.ForEach(list =>
            {
                for (var i = 0; i < list.Count - 1; i++)
                {
                    if (!res.ContainsKey(list[i]))
                    {
                        res.Add(list[i], new Dictionary<string, int>());
                    }

                    if (!res[list[i]].ContainsKey(list[i + 1]))
                    {
                        res[list[i]].Add(list[i + 1], 0);
                    }

                    res[list[i]][list[i + 1]]++;
                }
            });

            return res;
        }


        private static string GetOrdinalMax(Dictionary<string, int> dict)
        {
            var res = string.Empty;
            var maxValue = dict.Select(keyValuePair => keyValuePair.Value).Concat(new[] {int.MinValue}).Max();

            return dict.Aggregate(res, (current, keyValuePair) =>
                keyValuePair.Value == maxValue &&
                (string.IsNullOrEmpty(current) || string.CompareOrdinal(keyValuePair.Key, current) < 0)
                    ? keyValuePair.Key
                    : current);
        }
    }
}