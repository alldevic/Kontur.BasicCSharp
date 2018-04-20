using System.Linq;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        /* 
         * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
         * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
         * заменяется на медиану всех цветов в некоторой окрестности пикселя.
         * https://en.wikipedia.org/wiki/Median_filter
         * 
         * Используйте окно размером 3х3 для не граничных пикселей,
         * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
         */
        public static double[,] MedianFilter(double[,] original)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);
            var res = new double[width, height];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var tmp = GetSubArray(original, i, j, width, height).Cast<double>().OrderBy(x => x).ToArray();
                    var tmpPos = tmp.Length / 2;
                    res[i, j] = tmp.Length % 2 != 0 ? tmp[tmpPos] : (tmp[tmpPos - 1] + tmp[tmpPos]) / 2;
                }
            }

            return res;
        }

        private static int CalcSize(int size, int pos)
        {
            return (size == 1 || size == 2) ? size : ((pos == 0 || pos == size - 1) ? 2 : 3);
        }

        private static double[,] GetSubArray(double[,] arr, int x, int y, int width, int height)
        {
            var res = new double[CalcSize(width, x), CalcSize(height, y)];
            var startI = (x == 0) ? 0 : -1;
            var endI = (x == width - 1) ? 0 : 1;
            var startJ = (y == 0) ? 0 : -1;
            var endJ = (y == height - 1) ? 0 : 1;

            for (int i = startI, i1 = 0; i < endI + 1; i++, i1++)
            {
                for (int j = startJ, j1 = 0; j < endJ + 1; j++, j1++)
                {
                    res[i1, j1] = arr[x + i, y + j];
                }
            }

            return res;
        }
    }
}