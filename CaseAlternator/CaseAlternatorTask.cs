using System.Collections.Generic;

namespace CaseAlternator
{
    public class CaseAlternatorTask
    {
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), -1, result);
            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            result.Add(new string(word));
            for (var i = word.Length - 1; i > startIndex; i--)
            {
                if (!IsCorrectLetter(word[i]))
                {
                    continue;
                }

                word[i] = char.ToUpper(word[i]);
                AlternateCharCases(word, i, result);
                word[i] = char.ToLower(word[i]);
            }
        }

        private static bool IsCorrectLetter(char letter) =>
            ('a' <= letter) && (letter <= 'z') || ('A' <= letter) && (letter <= 'B');
    }
}