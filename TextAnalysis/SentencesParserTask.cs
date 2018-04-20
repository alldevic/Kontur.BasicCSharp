using System.Collections.Generic;

namespace TextAnalysis
{
	static class SentencesParserTask
	{
		public static readonly string[] StopWords = { "the", "and", "to", "a", "of", "in", "on", "at", "that", "as", "but", "with", "out", "for", "up", "one", "from", "into" };

		/*
		Разбейте файл с текстом на предложения и слова. 
		Считайте, что слова могут состоять только из букв (используйте метод char.IsLetter) или символа апострофа ',
		а предложения разделены одним из следующих символов .!?;:()
		Удалите из файла слова, содержащиеся в массиве StopWords (частые незначащие слова при анализе текстов называют стоп-словами)
		Метод должен возвращать список предложений, где каждое предложение — это список оставшихся слов в нижнем регистре.
		*/
		public static List<List<string>> ParseSentences(string text)
		{
			return new List<List<string>>();
		}
	}
}