using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day03
    {
        public static int NumberOfValidTriangles(int[,] triangles)
        {
            int valid = 0;
            for (int i = 0; i < triangles.GetLength(0); i++)
            {
                if ((triangles[i, 0] + triangles[i, 1] > triangles[i, 2]) &&
                    (triangles[i, 0] + triangles[i,2] > triangles[i, 1]) &&
                    (triangles[i, 1] + triangles[i, 2] > triangles[i, 0]) )
                {
                    valid++;
                }
            }
            return valid;
        }
        public static int NumberOfValidTrianglesVertically(int[,] triangles)
        {
            int valid = 0;
            int offset = 0;

            for (int i = 0; i < triangles.GetLength(0); i++)
            {
                offset = i % 3;
                var side1 = triangles[i - offset, offset];
                var side2 = triangles[i - offset + 1, offset];
                var side3 = triangles[i - offset + 2,offset];
                Console.WriteLine($"{side1} x {side2} x {side3}");
                if (side1 + side2 > side3 &&
                    side1 + side3 > side2 &&
                    side3 + side2 > side1)
                {
                    valid++;
                }
            }
            return valid;
        }
    }
}
