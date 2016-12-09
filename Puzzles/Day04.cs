using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.SnowPuzzles
{
    public static class Day04
    {
        public static int MineAdventCoin(string puzzleInput, int zeroCount)
        {
            int i = 0;
            using (var md5 = MD5.Create())
            {
                
                string hash = new String('x', zeroCount); ;
                string zeroes = new String('0', zeroCount);
                while (hash.Substring(0, zeroCount) != zeroes) 
                {
                    i++;
                    var input = puzzleInput + i;
                    var hashArray = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                    hash = BitConverter.ToString(hashArray).Replace("-", "");
                }
            }
            return i;
        }
    }
}
