using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    class Program
    {
        public static int PUZZLE_INPUT = 1358;
        static void Main(string[] args)
        {
            var start = new Point(1, 1);
            var destination = new Point(31, 39);

            var paths = new List<List<Point>> { new List<Point> { start } };
            var visitedPoints = new List<Point> { start };
            var shortestPath = FindShortestPath(destination.X, destination.Y, paths, visitedPoints, null);
            Console.WriteLine($"The shortest path to {destination.X}, {destination.Y} is {shortestPath.Count - 1} steps");

            paths = new List<List<Point>> { new List<Point> { start } };
            visitedPoints = new List<Point> { start };
            var maxSteps = 50;
            var foo = FindShortestPath(destination.X, destination.Y, paths, visitedPoints, maxSteps);
            Console.WriteLine($"The most positions we can visit in {maxSteps} steps is {visitedPoints.Count}");

                Console.ReadLine();
        }
        public static List<Point> FindShortestPath(int destX, int destY, List<List<Point>> paths, List<Point> visitedPoints, int? maxPathLength)
        {
            if (maxPathLength.HasValue && paths.Any(x => x.Count > maxPathLength.Value))
            {
                return new List<Point>(); //just return an empty one
            }
            //Console.WriteLine($"Checking {paths.Count} paths");
            var newPaths = new List<List<Point>>();

            foreach (var path in paths)
            {
                var end = path.Last();
                foreach (var newPoint in new List<Point> {
                    new Point(end.X, end.Y - 1),   //up
                    new Point(end.X, end.Y + 1),   //down
                    new Point(end.X - 1, end.Y),   //left
                    new Point(end.X + 1, end.Y),}) //right

                    //check up, down, left and right from the final point
                    if (IsOpenSpace(newPoint.X, newPoint.Y) == true)
                    {
                        if (!visitedPoints.Contains(newPoint))
                        {
                            visitedPoints.Add(newPoint);
                            if (!path.Contains(newPoint)) //don't walk in circles
                            {
                                var newPath = new List<Point>(path);
                                newPath.Add(new Point(newPoint.X, newPoint.Y));
                                if (newPoint.X == destX && newPoint.Y == destY)
                                {
                                    return newPath;
                                }
                                else
                                {
                                    newPaths.Add(newPath);
                                }
                            }
                        }
                    }
            }
            paths.Clear(); //should keep memory usage down
            return FindShortestPath(destX, destY, newPaths, visitedPoints, maxPathLength);
        }
        public static bool? IsOpenSpace(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return null;
            }
            else
            {
                var value = (x * x) + (3 * x) + (2 * x * y) + y + (y * y);
                value += PUZZLE_INPUT;
                var binary = Convert.ToString(value, 2);
                return binary.Count(c => c == '1') % 2 == 0;
            }
        }

        public static void DrawMaze(int width, int height)
        {
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    Console.Write(IsOpenSpace(x, y).Value ? '.' : '#');
                }
                Console.WriteLine();
            }
        }
    }
}
