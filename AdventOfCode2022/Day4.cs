using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Day4
    {
        private List<(List<int>, List<int>)> _data;

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            _data = File.ReadAllLines("Day4.txt").Select(RangeSetToArrays).ToList();
        }

        private static List<int> RangeToArray(string range)
        {
            var secondRange = range.Split('-');
            return Enumerable
                .Range(int.Parse(secondRange[0]), int.Parse(secondRange[1]) - int.Parse(secondRange[0]) + 1).ToList();
        }

        private static (List<int>, List<int>) RangeSetToArrays(string range)
        {
            var ranges = range.Split(',');
            return (RangeToArray(ranges[0]), RangeToArray(ranges[1]));
        }

        private static bool DoSetsOverlap((List<int>, List<int>) sets)
        {
            return sets.Item1.Intersect(sets.Item2).Any();
        }

        private static bool DoesOneSetContainTheOther((List<int>, List<int>) sets)
        {
            return !sets.Item1.Except(sets.Item2).Any() || !sets.Item2.Except(sets.Item1).Any();
        }

        [Test]
        public void Part1()
        {
            Console.WriteLine(_data.Count(DoesOneSetContainTheOther));
        }

        [Test]
        public void Part2()
        {
            Console.WriteLine(_data.Count(DoSetsOverlap));
        }
    }
}