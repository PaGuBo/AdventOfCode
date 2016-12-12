using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day10
{
    class Program
    {
        private static Dictionary<string, Bot> bots;
        private static Dictionary<string, List<int>> outputBins;
        private static List<Tuple<string, bool>> instructionsList = new List<Tuple<string, bool>>();
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"input.txt");

            InitializeTheBots(input);
            InitializeOutputBins(input);
            
            //use a tupple to keep track of whether or not instructions have been processed
            instructionsList = input.Split('\n').Select(x => new Tuple<string, bool> (x, false )).ToList();
            
            //while there are unprocessed instructions, keep going
            while (instructionsList.Any(x => x.Item2 == false))
            {
                ProcessInstructions();
            }
            var output = outputBins["0"][0] * outputBins["1"][0] * outputBins["2"][0];

            Console.WriteLine($"Multiplied value is {output}");
            Console.ReadLine();
        }



        private static void InitializeTheBots(string input)
        {
            bots = new Dictionary<string, Bot>();
            var botIdRegEx = new Regex(@"bot (\d*)");
            //initialize the bots
            foreach (Match match in botIdRegEx.Matches(input))
            {
                var botId = match.Groups[1].Value;
                if (!bots.ContainsKey(botId))
                {
                    bots.Add(botId, new Bot(botId, null, null));
                }
            }
        }

        private static void InitializeOutputBins(string input)
        {
            outputBins = new Dictionary<string, List<int>>();
            var outputBinIdRegEx = new Regex(@"output (\d*)");
            foreach (Match match in outputBinIdRegEx.Matches(input))
            {
                var binId = match.Groups[1].Value;
                if (!outputBins.ContainsKey(binId))
                {
                    outputBins.Add(binId, new List<int>());
                }
            }
        }
        public static void ProcessInstructions()
        {
            var botRegex = new Regex(@"bot (?<giverBotId>\d*) gives low to (?<lowTakerType>bot|output) (?<lowTakerId>\d*) and high to (?<highTakerType>bot|output) (?<highTakerId>\d*)");
            var valueRegex = new Regex(@"value (\d*) goes to bot (\d*)");

            for (int i = 0; i < instructionsList.Count; i++)
            {
                if(instructionsList[i].Item2 == true)
                {
                    continue;
                }
                //this is a bot instruction
                if (instructionsList[i].Item1[0] == 'b')
                {
                    var matches = botRegex.Match(instructionsList[i].Item1);

                    var giverBotId = matches.Groups["giverBotId"].Value;
                    var lowTakerType = matches.Groups["lowTakerType"].Value;
                    var lowTakerId = matches.Groups["lowTakerId"].Value;
                    var highTakerId = matches.Groups["highTakerId"].Value;
                    var highTakerType = matches.Groups["highTakerType"].Value;

                    var giverBot = bots[giverBotId];

                    if (giverBot.HasTwoChips())
                    {
                        if (lowTakerType == "bot")
                        {
                            bots[lowTakerId].SetValue(giverBot.Low.Value);
                        }
                        else
                        {
                            outputBins[lowTakerId].Add(giverBot.Low.Value);
                        }

                        if (highTakerType == "bot")
                        {
                            bots[highTakerId].SetValue(giverBot.High.Value);
                        }
                        else
                        {
                            outputBins[highTakerId].Add(giverBot.High.Value);
                        }
                        giverBot.Low = null;
                        giverBot.High = null;
                        instructionsList[i] = new Tuple<string, bool>(instructionsList[i].Item1, true);
                    }
                }
                else if (instructionsList[i].Item1[0] == 'v')
                {
                    var matches = valueRegex.Match(instructionsList[i].Item1);
                    var value = Convert.ToInt32(matches.Groups[1].Value);
                    var botId = matches.Groups[2].Value;
                    bots[botId].SetValue(value);
                    instructionsList[i] = new Tuple<string, bool>(instructionsList[i].Item1, true);
                }
            }
        }

    }
}
