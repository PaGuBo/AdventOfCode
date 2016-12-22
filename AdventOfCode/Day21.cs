using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.SleighPuzzles
{
    public static class Day21
    {
        public static string ScramblePassword(string password, List<string> instructions, bool unscramble = false)
        {
            var scrambledPassword = new StringBuilder(password);
            var swapXYPosition = new Regex(@"^swap position (?<xPosition>\d*) with position (?<yPosition>\d*)$");
            var swapXYLetters = new Regex(@"^swap letter (?<xLetter>[a-z]) with letter (?<yLetter>[a-z])$");
            var rotateLeftRightXSteps = new Regex(@"^rotate (?<direction>left|right) (?<xSteps>\d*) step(s)?$");
            var rotateBasedOnPositionOfLetterX = new Regex(@"^rotate based on position of letter (?<xLetter>[a-z])$");
            var reversePositionsXthroughY = new Regex(@"^reverse positions (?<xPosition>\d*) through (?<yPosition>\d*)$");
            var movePositionXtoPositionY = new Regex(@"^move position (?<xPosition>\d*) to position (?<yPosition>\d*)$");
            Console.WriteLine($"Starting password is {password}");
            foreach (var instruction in instructions)
            {
                Console.WriteLine($"\n   {instruction}");
                if (swapXYPosition.IsMatch(instruction))
                {
                    var xPos = Convert.ToInt32(swapXYPosition.Match(instruction).Groups["xPosition"].Value);
                    var yPos = Convert.ToInt32(swapXYPosition.Match(instruction).Groups["yPosition"].Value);

                    var temp = scrambledPassword[xPos];
                    scrambledPassword[xPos] = scrambledPassword[yPos];
                    scrambledPassword[yPos] = temp;
                }
                else if (swapXYLetters.IsMatch(instruction))
                {
                    var xLetter = Convert.ToChar(swapXYLetters.Match(instruction).Groups["xLetter"].Value);
                    var yLetter = Convert.ToChar(swapXYLetters.Match(instruction).Groups["yLetter"].Value);
                    scrambledPassword.Replace(xLetter, '#');
                    scrambledPassword.Replace(yLetter, xLetter);
                    scrambledPassword.Replace('#', yLetter);
                }
                else if (rotateLeftRightXSteps.IsMatch(instruction))
                {
                    var direction = rotateLeftRightXSteps.Match(instruction).Groups["direction"].Value;
                    var xSteps = Convert.ToInt32(rotateLeftRightXSteps.Match(instruction).Groups["xSteps"].Value);

                    var s = scrambledPassword.ToString() + scrambledPassword.ToString() + scrambledPassword.ToString() + scrambledPassword.ToString();
                    if (direction == "left")
                    {
                        s = s.Substring(xSteps, scrambledPassword.Length);
                    }
                    else if (direction == "right")
                    {
                        s = s.Substring(scrambledPassword.Length - xSteps % scrambledPassword.Length, scrambledPassword.Length);
                    }
                    scrambledPassword.Clear().Append(s);
                }
                else if (rotateBasedOnPositionOfLetterX.IsMatch(instruction))
                {
                    var xLetter = Convert.ToChar(rotateBasedOnPositionOfLetterX.Match(instruction).Groups["xLetter"].Value);
                    var indexOfXLetter = scrambledPassword.ToString().IndexOf(xLetter);
                    var stepsToRotate = indexOfXLetter < 4 ? indexOfXLetter + 1 : indexOfXLetter + 2;
                    var s = scrambledPassword.ToString() + scrambledPassword.ToString() + scrambledPassword.ToString() + scrambledPassword.ToString();
                    s = s.Substring(scrambledPassword.Length - stepsToRotate % scrambledPassword.Length, scrambledPassword.Length);
                    scrambledPassword.Clear().Append(s);
                }
                else if (reversePositionsXthroughY.IsMatch(instruction))
                {
                    var xPosition = Convert.ToInt32(reversePositionsXthroughY.Match(instruction).Groups["xPosition"].Value);
                    var yPosition = Convert.ToInt32(reversePositionsXthroughY.Match(instruction).Groups["yPosition"].Value);
                    var currScrambledString = scrambledPassword.ToString();
                    var tempSb = new StringBuilder();
                    if (xPosition > 0)
                    {
                        tempSb.Append(currScrambledString.Substring(0, xPosition));
                    }
                    for(int i = yPosition; i >= xPosition; i--)
                    {
                        tempSb.Append(currScrambledString[i]);
                    }
                    if (yPosition < currScrambledString.Length - 1)
                    {
                        tempSb.Append(currScrambledString.Substring(yPosition + 1));
                    }
                    scrambledPassword.Clear().Append(tempSb);

                }
                else if (movePositionXtoPositionY.IsMatch(instruction))
                {
                    var xPosition = Convert.ToInt32(movePositionXtoPositionY.Match(instruction).Groups["xPosition"].Value);
                    var yPosition = Convert.ToInt32(movePositionXtoPositionY.Match(instruction).Groups["yPosition"].Value);
                    var s = scrambledPassword.ToString();
                    var letter = s[xPosition].ToString();
                    s = s.Remove(xPosition, 1);
                    s = s.Insert(yPosition, letter);
                    scrambledPassword.Clear().Append(s);
                }
                else
                {
                    throw new NotImplementedException();
                }
                Console.WriteLine($"   Current password is {scrambledPassword.ToString()}");
            }
            return scrambledPassword.ToString();
        }
    }
}
