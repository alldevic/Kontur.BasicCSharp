using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            if (data is null) yield break;
            var fl = true;
            var pr = 0.0;
            foreach (var t in data)
            {
                if (fl)
                {
                    t.ExpSmoothedY = t.OriginalY;
                    pr = t.ExpSmoothedY;
                    fl = false;
                    yield return t;
                    continue;
                }

                pr = t.ExpSmoothedY = pr + alpha * (t.OriginalY - pr);
                yield return t;
            }
        }
    }
}