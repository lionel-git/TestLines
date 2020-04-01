using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLines
{
    class Program
    {

        static HashSet<int> Join(HashSet<int> h1, HashSet<int> h2, HashSet<int> h3)
        {
            var h = new HashSet<int>();
            foreach (var item in h1)
            {
                h.Add(item);
            }
            foreach (var item in h2)
            {
                h.Add(item);
            }
            foreach (var item in h3)
            {
                h.Add(item);
            }
            return h;
        }

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
            for (int i=0;i<lines.Count;i++)
            {
                Console.WriteLine($"{i}:{lines[i]}");

            }

            // Calculer les index des points sur chaque line
            foreach (var line in lines)
                line.CheckPoints(points);

            // Selectionner 4 lignes parmi les 20 avec ordre
            // 20 * 19 * 18 * 17 = 116 280
            // generer les 20^4 cas et eliminer les doublons

            var testCase = new List<Tuple<int, int, int, int>>();
            for (int i = 0; i < lines.Count; i++)
                for (int j = 0; j < lines.Count; j++)
                    for (int k = 0; k < lines.Count; k++)
                        for (int l = 0; l < lines.Count; l++)
                        {
                            if (i != j && i != k && i != l && j != k && j != l && k != l)
                                testCase.Add(new Tuple<int, int, int, int>(i, j, k, l));
                        }
            Console.WriteLine(testCase.Count);

            int ok = 0;
            foreach (var test in testCase)
            {
                // Tester que 2 lignes consecutives ne sont pas paralleles (le crayon ne se leve pas)
                // surement une condition supplementaire
                // Calculer les 4 'segments' suivants:
                // ) l1    ; l1^l2 ]
                // [ l1^l2 ; l2^l3 ]
                // [ l2^l3 ; l3^l4 ]
                // [ l3^l4 ; l4    (
                // Compter le nombre de points dictincts Pi sur ces segments




                int i = test.Item1;
                int j = test.Item2;
                int k = test.Item3;
                int l = test.Item4;

                if (!lines[i].IsParralel(lines[j]) &&
                    !lines[j].IsParralel(lines[k]) &&
                    !lines[k].IsParralel(lines[l]))
                {
                    ok++;
                    // checker les points
                    var h = new HashSet<int>();
                    foreach (var index in lines[i].PointsOnLine)
                        h.Add(index);
                    foreach (var index in lines[j].PointsOnLine)
                        h.Add(index);
                    foreach (var index in lines[k].PointsOnLine)
                        h.Add(index);
                    foreach (var index in lines[l].PointsOnLine)
                        h.Add(index);
                    if (h.Count==9)
                    {
                        Console.WriteLine($"{lines[i]}");
                        Console.WriteLine($"{lines[j]}");
                        Console.WriteLine($"{lines[k]}");
                        Console.WriteLine($"{lines[l]}");
                        Console.WriteLine("==");

                        // Inter
                        var p1 = lines[i].Intersection(lines[j]);
                        var p2 = lines[j].Intersection(lines[k]);
                        var p3 = lines[k].Intersection(lines[l]);
                        Console.WriteLine($"{p1}");
                        Console.WriteLine($"{p2}");
                        Console.WriteLine($"{p3}");
                        Console.WriteLine("===============");


                        var h0a = Segment.ContainsPoint(p1, lines[i], true, points);
                        var h0b = Segment.ContainsPoint(p1, lines[i], false, points);
                        var h1 = Segment.ContainsPoint(p1, p2, points);
                        var h2 = Segment.ContainsPoint(p2, p3, points);
                        var h3a = Segment.ContainsPoint(p1, lines[l], true, points);
                        var h3b = Segment.ContainsPoint(p1, lines[l], false, points);

                        var hc = new HashSet<int>();
                        foreach (var item in h1)
                        {
                            hc.Add(item);
                        }
                        foreach (var item in h2)
                        {
                            hc.Add(item);
                        }

                        var htest1 = Join(h0a, hc, h3a);
                        var htest2 = Join(h0a, hc, h3b);
                        var htest3 = Join(h0b, hc, h3a);
                        var htest4 = Join(h0b, hc, h3b);

                        if (htest1.Count == 9)
                            Console.WriteLine("!!!!!!!!! htest1 !!!!!");
                        if (htest2.Count == 9)
                            Console.WriteLine("htest2");
                        if (htest3.Count == 9)
                            Console.WriteLine("htest3");
                        if (htest4.Count == 9)
                            Console.WriteLine("htest4");

                    }
                }

            }
            Console.WriteLine(ok);
        }
    }
}
