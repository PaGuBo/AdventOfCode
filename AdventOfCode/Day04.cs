using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day04
    {
        public static int SumOfSectorIds(List<string> roomCodes)
        {
            var sum = 0;
            var pattern = @"^(.*)\-(\d*)\[(.*)\]$";
            foreach(var roomCode in roomCodes)
            {
                var matches = Regex.Matches(roomCode.Replace("\r", ""), pattern);
                var room = matches[0].Groups[1].Value;
                var sector = Convert.ToInt32(matches[0].Groups[2].Value);
                var checksum = matches[0].Groups[3].Value;

                room = room.Replace("-", "");
                var roomLetters = room.GroupBy(letter => letter)
                    .Select(group => new
                    {
                        Letter = group.Key,
                        Count = group.Count()
                    })
                    .OrderByDescending(x => x.Count)
                    .ThenBy(x => x.Letter)
                    .Take(5).Select(x => x.Letter);
                var computedChecksum = string.Concat(roomLetters);

                if (computedChecksum == checksum)
                {
                    sum += sector;
                }
            }
            return sum;
        }


        public static int SectorOfNorthPoleObjectStorage(List<string> roomCodes)
        {
            var pattern = @"^(.*)\-(\d*)\[(.*)\]$";
            foreach (var roomCode in roomCodes)
            {
                var matches = Regex.Matches(roomCode.Replace("\r", ""), pattern);
                var room = matches[0].Groups[1].Value;
                var sector = Convert.ToInt32(matches[0].Groups[2].Value);
                var checksum = matches[0].Groups[3].Value;

                var roomLetters = room.Replace("-", "").GroupBy(letter => letter)
                    .Select(group => new
                    {
                        Letter = group.Key,
                        Count = group.Count()
                    })
                    .OrderByDescending(x => x.Count)
                    .ThenBy(x => x.Letter)
                    .Take(5).Select(x => x.Letter);
                var computedChecksum = string.Concat(roomLetters);

                if (computedChecksum == checksum)
                {
                    var roomWords = room.Split('-');
                    var sb = new StringBuilder();
                    for (int i = 0; i < roomWords.Count(); i++)
                    {
                        //sb.Clear();
                        for (int j = 0; j < roomWords[i].Length; j++)
                        {
                            var newAscii = roomWords[i][j] + (sector % 26);
                            if (newAscii > 122) newAscii -= 26;

                            sb.Append((char)newAscii );
                        }
                        sb.Append(' ');
                    }
                    if (sb.ToString().Trim() == "northpole object storage")
                    {
                        return sector;
                    }
                    Console.WriteLine($"{sb.ToString()} SECTOR: {sector}");
                }
            }
            return -1;
        }
    }
}
