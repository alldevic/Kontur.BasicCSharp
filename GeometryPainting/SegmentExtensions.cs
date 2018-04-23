using System.Collections.Generic;
using System.Drawing;
using GeometryTasks;

namespace GeometryPainting
{
    public static class SegmentExtenshion
    {
        private static readonly Dictionary<Segment, Color> Colors = new Dictionary<Segment, Color>();

        public static Color GetColor(this Segment sgm) =>
            Colors.ContainsKey(sgm) ? Colors[sgm] : Colors[sgm] = Color.Black;


        public static void SetColor(this Segment sgm, Color color) => Colors[sgm] = color;
    }
}