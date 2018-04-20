using System.Collections.Generic;

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
			return new Dictionary<string, string>();
		}

	}
}