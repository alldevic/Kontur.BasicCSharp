namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
            var mod10 = count % 10;
            var mod100 = count % 100;
            if (mod100 > 10 && mod100 < 20) return "рублей";
            if (mod10 == 1) return "рубль";
            if (mod10 > 1 && mod10 < 5) return "рубля";
            return "рублей";
        }
    }
}