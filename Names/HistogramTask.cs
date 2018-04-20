using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        /*
        Напишите код, готовящий данные для построения гистограммы 
        — количества людей в выборке c заданным именем в зависимости от числа (то есть номера дня в месяце) их рождения.
        Не учитывайте тех, кто родился 1 числа любого месяца.
        Если вас пугает незнакомое слово гистограмма — вам как обычно в википедию! 
        http://ru.wikipedia.org/wiki/%D0%93%D0%B8%D1%81%D1%82%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B0
        Посмотрите пример выше с годами рождения.
        В качестве подписей (label) по оси X используйте число месяца.
        Объясните наблюдаемый результат!
        Пример подготовки данных для гистограммы смотри в файле HistogramSample.cs
        */
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var data = new double[31];
            foreach (var nm in names)
            {
                data[nm.BirthDate.Day - 1] += (string.Equals(nm.Name, name) && nm.BirthDate.Day != 1) ? 1 : 0;
            }

            return new HistogramData($"Рождаемость людей с именем '{name}'",
                Enumerable.Range(1, 31).Select(x => x.ToString()).ToArray(), data);
        }
    }
}