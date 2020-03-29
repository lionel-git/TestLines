using System;
using System.Collections.Generic;
using System.Text;

namespace TestLines
{
    public class Point2D
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Point2D()
        {
        }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X:0.00},{Y:0.00}";
        }
    }
}
