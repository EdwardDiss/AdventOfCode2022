using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Day6
    {
        private string _data;
        private Queue<char> _queue;

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            _data = File.ReadAllText("Day6.txt");
        }

        private void FindFirstUniqueSequence(int length)
        {
            _queue = new Queue<char>();
            for (int i = 0; i < length; i++)
            {
                _queue.Enqueue(_data[i]);
            }

            for (int i = length; i < _data.Length; i++)
            {
                if (_queue.Distinct().Count() == length)
                {
                    Console.WriteLine(i);
                    break;
                }

                _queue.Dequeue();
                _queue.Enqueue(_data[i]);
            }
        }

        [Test]
        public void Part1()
        {
            FindFirstUniqueSequence(4);
        }

        [Test]
        public void Part2()
        {
            FindFirstUniqueSequence(14);
        }
    }
}