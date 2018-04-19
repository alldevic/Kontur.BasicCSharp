﻿namespace Fractals
{
    internal static class DragonFractalTask
    {
        /*
            Начните с точки (1, 0)
            Создайте генератор рандомных чисел с сидом seed
            
            На каждой итерации:

            1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

                Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
                x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
                y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

                Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
                x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
                y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
        
            2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

        */
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            double x = 1.0, y = 0.0;
            var random = new System.Random(seed);

            for (var i = 0; i < iterationsCount; i++)
            {
                var xt = (-x - y) / 2 + 1;
                var yt = (x - y) / 2;

                if (random.Next(10) > 4)
                {
                    xt = (x - y) / 2;
                    yt = (y + x) / 2;
                }

                x = xt;
                y = yt;
                pixels.SetPixel(x, y);
            }
        }
    }
}