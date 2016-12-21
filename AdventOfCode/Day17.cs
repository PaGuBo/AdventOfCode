using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day17
    {
        public static string GetShortestPath(string password, Point startPos, Point goalPos)
        {
            var q = new Queue<Tuple<string, Point>>();
            q.Enqueue(new Tuple<string, Point>("", startPos));

            bool up = true;
            bool down = true;
            bool left = true;
            bool right = true;

            while (q.Count > 0)
            {
                var item = q.Dequeue();
                var currentPath = item.Item1;
                var currPos = item.Item2;

                if (currPos == goalPos)
                {
                    return currentPath;
                }
                else
                {
                    CheckDoors(password + currentPath, out up, out down, out left, out right);
                    if (!up && !down && !left && !right)
                    {
                        continue;
                    }
                    if (up && currPos.Y > 0) //we can go up and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "U", new Point(currPos.X, currPos.Y - 1)));
                    }
                    if (down && currPos.Y < 3) //we can go down and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "D", new Point(currPos.X, currPos.Y + 1)));
                    }
                    if (left && currPos.X > 0) //we can go left and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "L", new Point(currPos.X - 1, currPos.Y)));
                    }
                    if (right && currPos.X < 3) //we can go right and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "R", new Point(currPos.X + 1, currPos.Y)));
                    }
                }
            }
            return "No path exists";
        }


        public static int GetLongestPathLength(string password, Point startPos, Point goalPos)
        {
            var longestPathLength = 0;
            var q = new Queue<Tuple<string, Point>>();
            q.Enqueue(new Tuple<string, Point>("", startPos));

            bool up = true;
            bool down = true;
            bool left = true;
            bool right = true;

            while (q.Count > 0)
            {
                var item = q.Dequeue();
                var currentPath = item.Item1;
                var currPos = item.Item2;

                if (currPos == goalPos)
                {
                    if (currentPath.Length > longestPathLength)
                    {
                        longestPathLength = currentPath.Length;
                    }
                }
                else
                {
                    CheckDoors(password + currentPath, out up, out down, out left, out right);
                    if (!up && !down && !left && !right)
                    {
                        continue;
                    }
                    if (up && currPos.Y > 0) //we can go up and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "U", new Point(currPos.X, currPos.Y - 1)));
                    }
                    if (down && currPos.Y < 3) //we can go down and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "D", new Point(currPos.X, currPos.Y + 1)));
                    }
                    if (left && currPos.X > 0) //we can go left and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "L", new Point(currPos.X - 1, currPos.Y)));
                    }
                    if (right && currPos.X < 3) //we can go right and it's open
                    {
                        q.Enqueue(new Tuple<string, Point>(currentPath + "R", new Point(currPos.X + 1, currPos.Y)));
                    }
                }
            }
            return longestPathLength;
        }
        private static void CheckDoors(string input, out bool up, out bool down, out bool left, out bool right)
        {
            using (var md5 = MD5.Create())
            {
                var openSymbols = new List<char> { 'B', 'C', 'D', 'E', 'F' };
                var hashArray = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var hashString = BitConverter.ToString(hashArray).Replace("-", "");

                up = openSymbols.Contains(hashString[0]);
                down = openSymbols.Contains(hashString[1]);
                left = openSymbols.Contains(hashString[2]);
                right = openSymbols.Contains(hashString[3]);
            }
        }
    }
}
