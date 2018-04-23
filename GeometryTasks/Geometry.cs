using System;

namespace GeometryTasks
{
    public class Geometry
    {
        public static double GetLength(Vector vector) =>
            Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

        public static Vector Add(Vector vect1, Vector vect2) =>
            new Vector
            {
                X = vect2.X + vect1.X,
                Y = vect2.Y + vect1.Y
            };

        public static double GetLength(Segment sgm) =>
            Math.Sqrt(Math.Pow(sgm.End.X - sgm.Begin.X, 2.0) + Math.Pow(sgm.End.Y - sgm.Begin.Y, 2.0));


        public static bool IsVectorInSegment(Vector v, Segment sgm)
        {
            var mp1 = new Vector
            {
                X = sgm.Begin.X - v.X,
                Y = sgm.Begin.Y - v.Y,
            };
            var mp2 = new Vector
            {
                X = sgm.End.X - v.X,
                Y = sgm.End.Y - v.Y,
            };
            var p12 = new Vector
            {
                X = sgm.End.X - sgm.Begin.X,
                Y = sgm.End.Y - sgm.Begin.Y,
            };
            return (mp1.X * mp2.X + mp1.Y * mp2.Y <= 0) && Math.Abs(p12.X * mp2.Y - p12.Y * mp2.X) < double.Epsilon;
        }
    }
}