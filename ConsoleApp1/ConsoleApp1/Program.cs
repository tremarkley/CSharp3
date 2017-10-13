using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static PointList points = new PointList();
        static void Main(string[] args)
        {
            points.Changed += delegate (object sender, PointListChangedEventArgs e)
            {
                Console.WriteLine($"Points object changed: {e.Operation}");
            };

            points.Add(new Point(-4, -7));
            points.Add(new Point(0, 0));
            points.Add(new Point(1, 2));
            points.Add(new Point(-4, 5));
            points.Insert(2, new Point(3, 1));
            points.Add(new Point(7, -2));
            points[0] = new Point(2, 1);
            points.RemoveAt(2);

            bool containsOrigin = points.Any((x) => x.X == 0 && x.Y == 0);
            Console.WriteLine($"Point List contains point at origin: {containsOrigin}");

            IEnumerable<Point> firstQuadrant = points.Where((x) => (x.X > 0 && x.Y > 0));
            foreach (Point match in firstQuadrant)
            {
                Console.WriteLine($"Found Match: {match}");
            }

            int max_X = points.Max((x) => x.X);
            Console.WriteLine($"Max X is {max_X}");

            Console.WriteLine("Press <Enter> to quit...");
            Console.ReadLine();
        }
    }
}
