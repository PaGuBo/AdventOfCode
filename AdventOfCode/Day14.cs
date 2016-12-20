using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day14
    {
        public static int FindIndexOfXKey(int xKey, string salt)
        {
            int keyIndex = 0;
            int index = 1;
            using (var md5 = MD5.Create())
            {
                
                string hashFoo;
                string hashBar;
                byte[] hashArrayFoo;
                byte[] hashArrayBar;
                while (keyIndex < 64)
                {
                    hashArrayFoo = md5.ComputeHash(Encoding.ASCII.GetBytes(salt + index));
                    hashFoo = BitConverter.ToString(hashArrayFoo).Replace("-", "");
                    var foo = hashFoo.Substring(0, hashFoo.Length - 2).Where((c, i) => 
                        hashFoo[i] == hashFoo[i + 1] && hashFoo[i] == hashFoo[i + 2]);

                    if (foo.Count() > 0)
                    {
                        var stringToLookFor = new String(foo.First(), 5);
                        for (int j = 1; j < 1000; j++)
                        {
                            hashArrayBar = md5.ComputeHash(Encoding.ASCII.GetBytes(salt + (index + j)));
                            hashBar = BitConverter.ToString(hashArrayBar).Replace("-", "");

                            if (hashBar.Contains(stringToLookFor))
                            {
                                keyIndex++;
                                break;
                            }
                        }
                    }
                    //Console.WriteLine(input + "$$$" + hash);
                    index++;
                } 

            }

            return index - 1;
        }

        public static int FindIndexOfXKeyUsingStretchedHash(int xKey, string salt)
        {
            int keyIndex = 0;
            int index = 0;
            int numberOfStretches = 2016;
            var stretchedHashes = new Dictionary<int, string>();

            using (var md5 = MD5.Create())
            {

                string hashFoo;
                string hashBar;
                while (keyIndex < 64)
                {
                    if (!stretchedHashes.ContainsKey(index))
                    {
                        stretchedHashes.Add(index, HashAndStretch(salt + index, numberOfStretches));
                    }
                    hashFoo = stretchedHashes[index];

                    var foo = hashFoo.Substring(0, hashFoo.Length - 2).Where((c, i) =>
                        hashFoo[i] == hashFoo[i + 1] && hashFoo[i] == hashFoo[i + 2]);

                    if (foo.Count() > 0)
                    {
                        var stringToLookFor = new String(foo.First(), 5);
                        for (int j = 1; j < 1000; j++)
                        {
                            if (!stretchedHashes.ContainsKey(index + j))
                            {
                                stretchedHashes.Add(index + j, HashAndStretch(salt + (index + j), numberOfStretches));
                            }
                            hashBar = stretchedHashes[index + j];
                            if (hashBar.Contains(stringToLookFor))
                            {
                                keyIndex++;
                                break;
                            }
                        }
                    }
                    //Console.WriteLine(input + "$$$" + hash);
                    index++;
                }

            }

            return index - 1;
        }

        private static string HashAndStretch(string input, int numberOfStretches)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                for(int i = 0; i < numberOfStretches; i++)
                {
                    var strHash = BitConverter.ToString(hash).Replace("-", "").ToLower();
                    hash = md5.ComputeHash(Encoding.ASCII.GetBytes(strHash));
                }
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
