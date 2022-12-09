using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    public class Day5
    {
        private List<string> _fileLines;
        private readonly List<Stack<char>> _stacks = Enumerable.Range(0, 9).Select(i => new Stack<char>()).ToList();

        [SetUp]
        public void SetUp()
        {
            _fileLines = File.ReadAllLines("Day5.txt").ToList();
            ManualParseStacks();
        }

        private void ManualParseStacks()
        {
            new[] { 'J', 'Z', 'G', 'V', 'T', 'D', 'B', 'N' }.Reverse().ToList().ForEach(_stacks[0].Push);
            new[] { 'F', 'P', 'W', 'D', 'M', 'R', 'S' }.Reverse().ToList().ForEach(_stacks[1].Push);
            new[] { 'Z', 'S', 'R', 'C', 'V' }.Reverse().ToList().ForEach(_stacks[2].Push);
            new[] { 'G', 'H', 'P', 'Z', 'J', 'T', 'R' }.Reverse().ToList().ForEach(_stacks[3].Push);
            new[] { 'F', 'Q', 'Z', 'D', 'N', 'J', 'C', 'T' }.Reverse().ToList().ForEach(_stacks[4].Push);
            new[] { 'M', 'F', 'S', 'G', 'W', 'P', 'V', 'N' }.Reverse().ToList().ForEach(_stacks[5].Push);
            new[] { 'Q', 'P', 'B', 'V', 'C', 'G' }.Reverse().ToList().ForEach(_stacks[6].Push);
            new[] { 'N', 'P', 'B', 'Z' }.Reverse().ToList().ForEach(_stacks[7].Push);
            new[] { 'J', 'P', 'W' }.Reverse().ToList().ForEach(_stacks[8].Push);
        }

        [Test]
        public void Part1()
        {
            Simulate(MoveIndividually);
        }

        [Test]
        public void Part2()
        {
            Simulate(MoveTogether);
        }

        private void MoveIndividually(int from, int to, int count)
        {
            for (var j = 0; j <= count; j++)
            {
                _stacks[to].Push(_stacks[from].Pop());
            }
        }

        private void MoveTogether(int from, int to, int count)
        {
            var values = new Stack<char>();
            for (var i = 0; i <= count; i++)
            {
                values.Push(_stacks[from].Pop());
            }

            for (var i = 0; i <= count; i++)
            {
                _stacks[to].Push(values.Pop());
            }
        }

        private void Simulate(Action<int, int, int> move)
        {
            for (int i = 10; i < _fileLines.Count; i++)
            {
                var lineList = _fileLines[i].Split(' ');
                var times = int.Parse(lineList[1]) - 1;
                var from = int.Parse(lineList[3]) - 1;
                var to = int.Parse(lineList[5]) - 1;

                move(from, to, times);
            }

            _stacks.ForEach(i => Console.Write(i.Pop()));
        }
    }
}