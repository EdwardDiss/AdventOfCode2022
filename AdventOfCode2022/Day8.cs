using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Day8
    {
        private int[][] _data;
        private int _count = 0;

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            _data = File.ReadAllLines("Day8.txt").Select(x => x.Select(c => Int32.Parse(c.ToString())).ToArray()).ToArray();
            _count = _data.Length * 2 + (_data[0].Length-2)*2;
        }

        private int[] GetCol(int col)
        {
            return _data.Select(x => x[col]).ToArray();
        }

        [Test]
        public void Part1()
        {
            for (int row = 1; row < _data.Length-1; row++)
            {
                for (int col = 1; col < _data.Length-1; col++)
                {
                    var tree = _data[row][col];

                    var wholeCol = GetCol(col);
                    var colNorth = wholeCol.Take(row);
                    var colSouth = wholeCol.Skip(row+1);

                    var wholeRow = _data[row];
                    var rowEast = wholeRow.Take(col);
                    var rowWest = wholeRow.Skip(col+1);

                    if (rowEast.Max()<tree || rowWest.Max()<tree||colSouth.Max()<tree || colNorth.Max()<tree)
                    {
                        _count++;
                    }
                }
            }

            Console.WriteLine(_count);
        }

        [Test]
        public void Part2()
        {
            int highScore = 0;
            for (int row = 0; row < _data.Length-1; row++)
            {
                for (int col = 0; col < _data.Length-1; col++)
                {
                    var tree = _data[row][col];

                    var wholeCol = GetCol(col);
                    var colNorth = wholeCol.Take(row).Reverse().ToArray();
                    var colSouth = wholeCol.Skip(row+1).ToArray();

                    var wholeRow = _data[row];
                    var rowEast = wholeRow.Take(col).Reverse().ToArray();
                    var rowWest = wholeRow.Skip(col+1).ToArray();
                    var score = CalcViewDistance(tree, rowEast) * CalcViewDistance(tree, rowWest) *
                                CalcViewDistance(tree, colSouth) * CalcViewDistance(tree, colNorth);
                    if (score > highScore)
                    {
                        highScore = score;
                    }

                }
            }

            Console.WriteLine(highScore);
        }


        private int CalcViewDistance(int treeHouseHeight, int[] treeHeights)
        {
            int distance = 0;
            for (int i = 0; i < treeHeights.Length; i++)
            {
                distance++;
                if (treeHeights[i]>=treeHouseHeight)
                {
                    break;
                }
            }

            return distance;
        }
    }
}