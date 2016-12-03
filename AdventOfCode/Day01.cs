using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day01
    {
        enum Direction
        {
            North,
            East,
            South,
            West
        }
        public static int ShortestDistanceOnGrid(string input)
        {
            var instructions = input.Split(',');
            var xPos = 0;
            var yPos = 0;
            var dir = Direction.North;
            foreach(var instruction in instructions)
            {
                var turn = instruction[0].ToString();
                var distance = Convert.ToInt32(instruction.Substring(1));

                if ((dir == Direction.North && turn == "L") ||
                    (dir == Direction.South && turn == "R"))
                {
                    dir = Direction.West;
                    xPos -= distance;
                }

                else if ((dir == Direction.North && turn == "R") ||
                         (dir == Direction.South && turn == "L"))
                {
                    dir = Direction.East;
                    xPos += distance;
                }
                else if ((dir == Direction.East && turn == "L") ||
                         (dir == Direction.West && turn == "R"))
                {
                    dir = Direction.North;
                    yPos += distance;
                }
                else if ((dir == Direction.East && turn == "R") ||
                         (dir == Direction.West && turn == "L"))
                {
                    dir = Direction.South;
                    yPos -= distance;
                }
            }
            return Math.Abs(xPos) + Math.Abs(yPos);
        }

        public static int ShortestDistanceOnGridBetweenStartAndFirstDoublyVisitedLocation(string input)
        {
            var instructions = input.Split(',');
            var xPos = 0;
            var yPos = 0;
            var oldX = 0;
            var oldY = 0;

            var dir = Direction.North;
            var visited = new List<Tuple<int,int>>();
            foreach (var instruction in instructions)
            {
                var turn = instruction[0].ToString();
                var distance = Convert.ToInt32(instruction.Substring(1));

                if ((dir == Direction.North && turn == "L") ||
                    (dir == Direction.South && turn == "R"))
                {
                    dir = Direction.West;
                    xPos -= distance;
                }

                else if ((dir == Direction.North && turn == "R") ||
                         (dir == Direction.South && turn == "L"))
                {
                    dir = Direction.East;
                    xPos += distance;
                }
                else if ((dir == Direction.East && turn == "L") ||
                         (dir == Direction.West && turn == "R"))
                {
                    dir = Direction.North;
                    yPos += distance;
                }
                else if ((dir == Direction.East && turn == "R") ||
                         (dir == Direction.West && turn == "L"))
                {
                    dir = Direction.South;
                    yPos -= distance;
                }
                var foundDuplicate = false;
                foreach(int i in oldX.To(xPos))
                {
                    foreach (int j in oldY.To(yPos))
                    {
                        var loc = new Tuple<int, int>(i, j);
                        Console.WriteLine($"    Adding {i}, {j}");
                        if (visited.Any(x => x.Equals(loc)))
                        {
                            xPos = i;
                            yPos = j;
                            foundDuplicate = true;
                            break;
                        }
                        visited.Add(loc);
                    }
                    if (foundDuplicate)
                    {
                        break;
                    }
                }
                if (foundDuplicate)
                {
                    break;
                }
                //removing the last one because it will just get readded on the next run
                //I forgot how I did last time
                visited.RemoveAt(visited.Count - 1);
                oldX = xPos;
                oldY = yPos;
            }
            return Math.Abs(xPos) + Math.Abs(yPos);
        }
    }
}
