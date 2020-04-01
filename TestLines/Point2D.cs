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

        public double ScalarProduct(Point2D p)
        {
            return X * p.X + Y * p.Y;
        }

        public Point2D Ortho()
        {
            return new Point2D(-Y, X);
        }

        public static Point2D operator-(Point2D a, Point2D b)
        {
            return new Point2D(a.X - b.X, a.Y - b.Y);
        }

        public static Point2D operator+(Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }

        public Point2D Mult(double l)
        {
            return new Point2D(X * l, Y * l);
        }


        public override string ToString()
        {
            return $"{X:0.00},{Y:0.00}";
        }
    }
}
