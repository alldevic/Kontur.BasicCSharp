using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double s1 = Dist(x, y, ax, ay), s2 = Dist(x, y, bx, by), s12 = Dist(ax, ay, bx, by);

            if ((s1 >= Dist(s2, s12, 0, 0)) || (s2 >= Dist(s1, s12, 0, 0)))
            {
                return Math.Min(s1, s2);
            }

            var c = -ax * (by - ay) + ay * (bx - ax);
            var a = (by - ay) * (c > 0 ? -1 : 1);
            var b = (ax - bx) * (c > 0 ? -1 : 1);
            c *= c > 0 ? -1 : 1;

            return Math.Abs((a * x + b * y + c) / Dist(a, b, 0, 0));
        }

        private static double Dist(double ax, double ay, double bx, double by)
        {
            return Math.Sqrt(Math.Pow(bx - ax, 2.0) + Math.Pow(by - ay, 2.0));
        }
    }
}