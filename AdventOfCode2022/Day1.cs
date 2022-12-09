using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Day1
    {
        private List<int> _calorieSumList;

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            string calorieString = File.ReadAllText("Day1.txt");

            //Split into a string per elf
            var elfList = calorieString.Split(new [] { "\r\n\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            //Sum each elfs total
            _calorieSumList = elfList.Select(x => x.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None).Select(int.Parse).Sum()).ToList();
        }

        [Test]
        public void Part1NonLinq()
        {
             List<string> calorieList = File.ReadLines("Day1.txt").ToList();
            var currentElf = 0;
            var mostCalories = 0;
            foreach (var s in calorieList)
            {
                int value;
                if (int.TryParse(s,out value))
                {
                    currentElf += value;
                }
                else
                {
                    if (currentElf>mostCalories)
                    {
                        mostCalories = currentElf;
                    }

                    currentElf = 0;
                }
            }
            Console.WriteLine($"MostCalories: {mostCalories}");
        }

        [Test]
        public void Part1Linq()
        {
            Console.WriteLine($"Most Calories: {_calorieSumList.Max()}");
        }

        [Test]
        public void Part2Linq()
        {
            Console.WriteLine($"Top 3 Calories totals sum: {_calorieSumList.OrderByDescending(x => x).Take(3).Sum()}");
        }
    }
}