using System;
using System.Collections.Generic;

namespace TestLines
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var points = new List<Point2D>()
            {
                new Point2D(0.0, 0.0),
                new Point2D(1.0, 0.0),
                new Point2D(2.0, 0.0),

                new Point2D(0.0, 1.0),
                new Point2D(1.0, 1.0),
                new Point2D(2.0, 1.0),

                new Point2D(0.0, 2.0),
                new Point2D(1.0, 2.0),
                new Point2D(2.0, 2.0),
            };


            var lines = new List<Line>();
            for (int i = 0; i < points.Count; i++)
                for (int j = i + 1; j < points.Count; j++)
                {
                    var newLine = new Line(points[i], points[j]);
                    bool found = false;
                    foreach (var line in lines)
                    {
                        if (line.IsSame(newLine))
                            found = true;
                    }
                    if (!found)
                        lines.Add(newLine);
                }

            Console.WriteLine(lines.Count);
            foreach (var line in lines)
            {
                Console.WriteLine(line);

            }

        }
    }
}
