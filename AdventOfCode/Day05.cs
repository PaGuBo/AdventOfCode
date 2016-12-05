using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day05
    {
        public static string GetDoorPasswordPart1(string doorId)
        {
            var password = new StringBuilder();
            using (var md5 = MD5.Create())
            {
                int i = 0;
                string hash;
                do
                {
                    var input = doorId + i;
                    var hashArray = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                    hash = BitConverter.ToString(hashArray).Replace("-", "");
                    if (hash.Substring(0, 5) == "00000")
                    {
                        password.Append(hash[5]);
                        Console.WriteLine(input);
                    }
                    //Console.WriteLine(input + "$$$" + hash);
                    i++;
                } while (password.Length < 8);
                    
            }
            return password.ToString().ToLower();
        }


        public static string GetDoorPasswordPart2(string doorId)
        {
            var password = new char[8];
            int foundChars = 0;
            using (var md5 = MD5.Create())
            {
                int i = 0;
                string hash;
                do
                {
                    var input = doorId + i;
                    var hashArray = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                    hash = BitConverter.ToString(hashArray).Replace("-", "");
                    if (hash.Substring(0, 5) == "00000")
                    {
                        var potentialPosition = hash[5];
                        if ((potentialPosition >= '0' && potentialPosition <= '7') &&
                            password[Convert.ToInt32(char.GetNumericValue(potentialPosition))] == '\0')
                        {
                            password[Convert.ToInt32(char.GetNumericValue(potentialPosition))] = hash[6];
                            foundChars++;
                        }

                            //
                            //password.Append(hash[5]);
                        Console.WriteLine(input);
                        
                    }
                    //Console.WriteLine(input + "$$$" + hash);
                    i++;
                } while (foundChars < 8);

            }
            return (new string(password)).ToLower();
        }
    }
}
