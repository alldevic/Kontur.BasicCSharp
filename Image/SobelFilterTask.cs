using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        /* 
		Разберитесь, как работает нижеследующий код (называемый фильтрацией Собеля), 
		и какое отношение к нему имеют эти матрицы:
		
		     | -1 -2 -1 |           | -1  0  1 |
		Sx = |  0  0  0 |      Sy = | -2  0  2 |
		     |  1  2  1 |           | -1  0  1 |
		
		https://ru.wikipedia.org/wiki/Оператор_Собеля
		
		Попробуйте заменить фильтр Собеля 3x3 на фильтр Собеля 5x5 или другой аналогичный фильтр и сравните результаты. 
		Матрицу для фильтра Собеля 5x5 и другие матрицы можно посмотреть в статье SobelScharrGradients5x5.pdf 
		в архиве с проектом.
		Там Sx и Sy названы соответственно β и γ.

		Обобщите код применения фильтра так, чтобы можно было передавать ему любые матрицы, любого нечетного размера.
		Фильтры Собеля размеров 3 и 5 должны быть частным случаем. 
		После такого обобщения менять фильтр Собеля одного размера на другой должно быть легко.
		*/

        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            if (sx.GetLength(0) != sx.GetLength(1))
            {
                return g;
            }

            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var sy = ReflectMatrix(sx);
            var result = new double[width, height];
            var shift = sx.GetLength(0) / 2;
            var sobelSize = sx.GetLength(0);
            for (var x = shift; x < width - shift; x++)
            {
                for (var y = shift; y < height - shift; y++)
                {
                    var tmp = GetEnv(g, x, y, sobelSize);
                    var gx = ConvertValue(sx, tmp);
                    var gy = ConvertValue(sy, tmp);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            }

            return result;
        }

        private static double ConvertValue(double[,] matrix, double[,] env)
        {
            var cols = matrix.GetLength(0);
            var rows = matrix.GetLength(1);
            var res = 0.0;

            for (var i = 0; i < cols; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    res += matrix[i, j] * env[i, j];
                }
            }

            return res;
        }

        private static double[,] ReflectMatrix(double[,] matr)
        {
            var width = matr.GetLength(0);
            var res = new double[width, width];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    res[i, j] = matr[j, i];
                }
            }

            return res;
        }

        private static double[,] GetEnv(double[,] g, int x, int y, int size)
        {
            var res = new double[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    res[i, j] = g[x - size / 2 + i, y - size / 2 + j];
                }
            }

            return res;
        }
    }
}