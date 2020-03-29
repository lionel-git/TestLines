using System;
using System.Collections.Generic;
using System.Text;

namespace TestLines
{
    public class Line
    {
        public Point2D Direction { get; set; }
        public Point2D Origin { get; set; }

        public List<int> PointsOnLine { get; set; }

        public Line(Point2D A, Point2D B, bool throwIfNull = true)
        {
            Direction = new Point2D(B.X - A.X, B.Y - A.Y);
            Origin = A;
            if (throwIfNull && Direction.X * Direction.X + Direction.Y * Direction.Y < 1e-5)
                throw new Exception("Direction cannot be null!");

        }

        public bool IsParralel(Line b)
        {
            return Math.Abs(Direction.X * b.Direction.Y - b.Direction.X * Direction.Y) < 1e-5;
        }

        public void CheckPoints(List<Point2D> points)
        {
            PointsOnLine = new List<int>();
            for (int i = 0; i < points.Count; i++)
                if (IsPointOnLine(points[i]))
                    PointsOnLine.Add(i);
        }

        public bool IsPointOnLine(Point2D p)
        {
            var newLine = new Line(Origin, p, false);
            return IsParralel(newLine);
        }

        public bool IsSame(Line b)
        {
            if (IsParralel(b))
            {
                return IsPointOnLine(b.Origin);
            }
            else
                return false;
        }

        public override string ToString()
        {
            return $"O:{Origin},D:{Direction}";
        }

    }
}
