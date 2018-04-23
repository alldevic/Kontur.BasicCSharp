namespace GeometryTasks
{
    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength(Segment sgm) => Geometry.GetLength(this);
        public bool Contains(Vector v) => Geometry.IsVectorInSegment(v, this);
    }
}