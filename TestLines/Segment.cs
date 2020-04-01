using System;
using System.Collections.Generic;
using System.Text;

namespace TestLines
{
    public class Segment
    {     
        public static HashSet<int> ContainsPoint(Point2D A, Point2D B, List<Point2D> points)
        {
            var h = new HashSet<int>();
            for (int i = 0; i < points.Count; i++)
            {
                var AP = points[i] - A;
                var AB = B - A;
                if (Math.Abs(AB.Ortho().ScalarProduct(AP)) < 1e-5)
                {
                    var l = AP.ScalarProduct(AB) / (AB.ScalarProduct(AB));
                    if (l >= 0 - 1e-5 && l <= 1 + 1e-5)
                        h.Add(i);
                }
            }
            return h;
        }

        public static HashSet<int> ContainsPoint(Point2D A, Line line, bool direction, List<Point2D> points)
        {
            var dir = line.Direction.Mult(1000);
            Point2D B;
            if (direction)
                B = A + dir;
            else
                B = A - dir;            
            var h = new HashSet<int>();
            for (int i = 0; i < points.Count; i++)
            {
                var AP = points[i] - A;
                var AB = B - A;
                if (Math.Abs(AB.Ortho().ScalarProduct(AP)) < 1e-5)
                {
                    var l = AP.ScalarProduct(AB) / (AB.ScalarProduct(AB));
                    if (l >= 0 - 1e-5 && l <= 1 + 1e-5)
                        h.Add(i);
                }
            }
            return h;
        }

    }
}
