using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Dayx
    {
        private List<string> data;

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            data = File.ReadAllLines("Dayx.txt").ToList();
        }

        [Test]
        public void Part1()
        {

        }

        [Test]
        public void Part2()
        {

        }
    }
}