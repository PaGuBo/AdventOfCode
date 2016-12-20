using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Utils
{
    public static class Extensions
    {
        public static IEnumerable<int> To(this int from, int to)
        {
            if (from < to)
            {
                while (from <= to)
                {
                    yield return from++;
                }
            }
            else
            {
                while (from >= to)
                {
                    yield return from--;
                }
            }
        }

        public static List<bool> ReverseAndFlipBits(this List<bool> bitList)
        {
            var returnList = new List<bool>(bitList);
            var returnListLength = returnList.Count;

            //reverse the order and flip the bits
            for (int i = 0; i < returnList.Count / 2; i++)
            {
                var temp = returnList[i];
                returnList[i] = !returnList[returnListLength - i - 1];
                returnList[returnListLength - i - 1] = !temp;
            }
            if (returnListLength % 2 != 0) //flip the middle bit
            {
                returnList[returnListLength / 2] = !returnList[returnListLength / 2];
            }
            return returnList;
        }

        public static string ToBitString(this List<bool> bitList)
        {
            var sb = new StringBuilder();
            foreach (var b in bitList)
            {
                sb.Append(b ? "1" : "0");
            }
            return sb.ToString();
        }
    }


}
