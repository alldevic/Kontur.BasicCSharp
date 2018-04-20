using System.Linq;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double threshold)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);

            if (threshold < 0 || threshold > 1)
            {
                return new double[width, height];
            }

            var res = new double[width, height];
            var whitePixels = (int) (threshold * original.Length);
            var tmp = original.Cast<double>().OrderByDescending(x => x).ToList();
            var bright = tmp.FirstOrDefault(y => (whitePixels <= tmp.Count(z => z > y)));

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    res[i, j] = original[i, j] > bright ? 1 : 0;
                }
            }

            return res;
        }
    }
}