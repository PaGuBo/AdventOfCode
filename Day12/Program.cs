using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");

            foreach(var line in input)
            {
                Console.WriteLine($"     {line}");
            }
            var registers = new Dictionary<char, int> { { 'a', 0 }, { 'b', 0 }, { 'c', 1 }, { 'd', 0 } };
            //ShowRegisters(registers);
            int currLine = 0;
            while (currLine < input.Length)
            {
                //Console.ReadLine();
                //for (int i = 0; i < input.Length; i++)
                //{
                //    Console.SetCursorPosition(0, i);
                //    Console.WriteLine(i == currLine ? " --> " : "     ");
                //}
                var instruction = input[currLine].Split(' ');
                switch (input[currLine][0])
                {
                    case 'c':
                        var from = instruction[1];
                        var to = instruction[2];
                        var cValue = 0;
                        registers[to[0]] = int.TryParse(from, out cValue) ? cValue : registers[from[0]];
                        currLine++;
                        break;
                    case 'i':
                        registers[instruction[1][0]]++;
                        currLine++;
                        break;
                    case 'd':
                        registers[instruction[1][0]]--;
                        currLine++;
                        break;
                    case 'j':
                        var xValue = instruction[1];
                        var jumps = instruction[2];

                        var xValueInt= 0;
                        if (!int.TryParse(xValue, out xValueInt))
                        {
                            xValueInt = registers[xValue[0]];
                        }
                        if (xValueInt != 0)
                        {
                            var jumpsInt = 0;
                            if (!int.TryParse(jumps, out jumpsInt))
                            {
                                jumpsInt = registers[jumps[0]];
                            }
                            currLine += jumpsInt;
                        }
                        else
                        {
                            currLine++;
                        }

                        break;
                }
                if (currLine < 0)
                {
                    break;
                }
                //ShowRegisters(registers);
            }
            Console.ReadLine();
            
        }

        private static void ShowRegisters(Dictionary<char, int> registers)
        {
            Console.SetCursorPosition(0, 2);
            foreach (var key in registers.Keys)
            {
                Console.CursorLeft = 30;
                Console.WriteLine($"[{key} = {registers[key], 3}] ");
            }
        }
    }
}
