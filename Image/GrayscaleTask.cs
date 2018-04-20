﻿namespace Recognizer
{
    public static class GrayscaleTask
    {
        /* 
         * Переведите изображение в серую гамму.
         * 
         * original[x, y] - массив пикселей с координатами x, y. 
         * Каждый канал R,G,B лежит в диапазоне от 0 до 255.
         * 
         * Получившийся массив должен иметь те же размеры, 
         * grayscale[x, y] - яркость пикселя (x,y) в диапазоне от 0.0 до 1.0
         *
         * Используйте формулу:
         * Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
         * 
         * Почему формула именно такая — читайте в википедии 
         * http://ru.wikipedia.org/wiki/Оттенки_серого
         */

        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);
            var res = new double[width, height];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var tmp = original[i, j];
                    res[i, j] = (0.299 * tmp.R + 0.587 * tmp.G + 0.114 * tmp.B) / 255;
                }
            }

            return res;
        }
    }
}