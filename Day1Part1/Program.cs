using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Part1
{
    class Program
    {
        enum Direction
        {
            North,
            Eeast,
            South,
            West
        }
        static void Main(string[] args)
        {

            var xPos = 0;
            var yPos = 0;
            var dir = Direction.North;
            var instruction = Console.ReadLine();
            while (instruction != "Q")
            {

                var direction = instruction[0];
                var distance = Convert.ToInt32(instruction.Substring(1));

                Console.Write($"[Currently at {xPos,-3}, {yPos,-3} facing {dir}]  ");
                Console.Write($"[Instructed to move {instruction,-5} ({dir},{distance,-3})]  ");
                var dirInt = (int) dir;

                dirInt = direction == 'R' ? dirInt + 1 : dirInt - 1;

                dirInt = dirInt == -1 ? 3 :
                         dirInt == 4 ? 0 :
                         dirInt;

                dir = (Direction) Enum.Parse(typeof(Direction), dirInt.ToString());


                switch (dir)
                {
                    case Direction.North:
                        yPos += distance;
                        break;
                    case Direction.Eeast:
                        xPos += distance;
                        break;
                    case Direction.South:
                        yPos -= distance;
                        break;
                    case Direction.West:
                        xPos -= distance;
                        break;
                }
                Console.Write($"[Ended up at {xPos,-3} {yPos,-3} facing {dir}]\n");

            }
        }
    }
}
