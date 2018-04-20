using System.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        /*
        Подготовьте данные для построения карты интенсивностей, у которой по оси X — число месяца, по Y — номер месяца, 
        а интенсивность точки (она отображается цветом и размером) обозначает количество рожденных людей в это число 
        этого месяца. Не учитывайте людей, родившихся первого числа любого месяца.

        В качестве подписей (label) по X используйте число месяца (начиная со второго), 
        а по Y — номер месяца (январь — 1, февраль — 2, ...)
        */
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var drawData = new double[30, 12];
            foreach (var date in names)
            {
                if (date.BirthDate.Day != 1)
                {
                    drawData[date.BirthDate.Day - 2, date.BirthDate.Month - 1] += 1;
                }
            }

            return new HeatmapData("Пример карты интенсивностей", drawData,
                Enumerable.Range(2, 30).Select(x => x.ToString()).ToArray(),
                Enumerable.Range(1, 12).Select(x => x.ToString()).ToArray());
        }
    }
}