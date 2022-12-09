using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace AdventOfCode2022.Properties
{
    [TestFixture]
    public class Day3
    {
        private List<string> _backPacks;

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            _backPacks = File.ReadAllLines("Day3.txt").ToList();
        }

        [Test]
        public void Part1()
        {
            Console.WriteLine(_backPacks.Select(x => CharToValue(GetCharInBoth(x))).Sum());
        }

        public char GetCharInBoth(string backPack)
        {
            var firstCompartment = backPack.Substring(0, (backPack.Length / 2)).ToCharArray();
            var secondCompartment = backPack.Substring((backPack.Length / 2), backPack.Length / 2).ToCharArray();
            return firstCompartment.Intersect(secondCompartment).FirstOrDefault();
        }

        private int CharToValue(char c)
        {
            if (char.IsUpper(c))
            {
                return 27 + Math.Abs('A' - c);
            }

            return 1 + Math.Abs('a' - c);
        }

        [Test]
        public void Part2()
        {
            var sum = 0;
            for (int i = 0; i < _backPacks.Count; i += 3)
            {
                sum += CharToValue(_backPacks[i].Intersect(_backPacks[i + 1]).Intersect(_backPacks[i + 2]).First());
            }

            Console.WriteLine(sum);
        }
    }
}