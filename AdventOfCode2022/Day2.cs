using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Day2
    {
        private abstract class Choice
        {
            private readonly int _choiceValue;
            private readonly string _choice;
            private readonly string _weakAgainst;
            private readonly string _strongAgainstC;

            protected Choice(int choiceValue, string choice, string weakAgainst, string strongAgainst)
            {
                _choiceValue = choiceValue;
                _choice = choice;
                _weakAgainst = weakAgainst;
                _strongAgainstC = strongAgainst;
            }

            public int CalculateScore(string opponentsChoice)
            {
                if (opponentsChoice.Equals(_choice))
                {
                    return _choiceValue + 3;
                }

                if (opponentsChoice.Equals(_weakAgainst))
                {
                    return _choiceValue;
                }

                return _choiceValue + 6;
            }

            public string GetStrength() => _strongAgainstC;

            public string GetWeakness() => _weakAgainst;
        }

        private class Rock : Choice { public Rock() : base(1, "A", "B","C"){} }

        private class Paper : Choice { public Paper() : base(2, "B", "C","A"){} }

        private class Scissors : Choice { public Scissors() : base(3, "C", "A","B"){} }

        private static Choice LetterToChoice(string choice)
        {
            switch (choice)
            {
                case "A":
                case "X":
                    return new Rock();
                case "B":
                case "Y":
                    return new Paper();
                default:
                    return new Scissors();
            }
        }

        private static int CalculateResult(string choices)
        {
            var choicesList = choices.Split(' ');
            return LetterToChoice(choicesList.Last()).CalculateScore(choicesList.First());
        }

        private static int CalculateDesiredResult(string choices)
        {
            var choicesList = choices.Split(' ');
            var outComeString = choicesList.Last();
            var opponentsChoiceString = choicesList.First();
            var opponentsChoice = LetterToChoice(opponentsChoiceString);

            string myChoice;
            switch (outComeString)
            {
                case "X": // I want to lose
                    myChoice = opponentsChoice.GetStrength();
                    break;
                case "Z": // I want to win
                    myChoice = opponentsChoice.GetWeakness();
                    break;
                default: // I want to draw
                    myChoice = opponentsChoiceString;
                    break;
            }

            return LetterToChoice(myChoice).CalculateScore(opponentsChoiceString);
        }

        private List<string> _fileLines;

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            _fileLines = File.ReadAllLines("Day2.txt").ToList();
        }

        [Test]
        public void Part1Linq()
        {
            Console.WriteLine($"Total Score: {_fileLines.Select(CalculateResult).Sum()}");
        }

        [Test]
        public void Part2Linq()
        {
            Console.WriteLine($"Top score: {_fileLines.Select(CalculateDesiredResult).Sum()}");
        }
    }
}