namespace GeometryTasks
{
    public class Vector
    {
        public double X, Y;

        public double GetLength() => Geometry.GetLength(this);
        public Vector Add(Vector v2) => Geometry.Add(this, v2);
        public bool Belongs(Segment sgm) => Geometry.IsVectorInSegment(this, sgm);
    }
}