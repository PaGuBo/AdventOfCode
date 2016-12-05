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
    }
}
