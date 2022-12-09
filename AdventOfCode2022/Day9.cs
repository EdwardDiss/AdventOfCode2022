using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Day9
    {
        private List<string> _data;
        //Used tuple instead of object as easier to check value equality
        private HashSet<(int, int)> _visited;

        private class Coordinate
        {
            public int X;
            public int Y;
            public string Name;

            public Coordinate(int x, int y, string name = "")
            {
                X = x;
                Y = y;
                Name = name;
            }
        }


        [SetUp]
        public void SetUp()
        {
            //Read into one string
            _data = File.ReadAllLines("Day9.txt").ToList();
            _visited = new();
        }

        [Test]
        public void Part1()
        {
            var headCoordinate = new Coordinate(0, 0);
            var tailCoordinate = new Coordinate(0, 0);
            _visited.Add((tailCoordinate.X, tailCoordinate.Y));

            foreach (var t in _data)
            {
                Move(t, headCoordinate, tailCoordinate);
            }

            Console.WriteLine(_visited.Count);
            Assert.That(_visited.Count, Is.EqualTo(6018));
        }

        private void Move(string move, Coordinate headCoordinate, Coordinate tailCoordinate)
        {
            string[] parts = move.Split(' ');
            var direction = parts.First();
            var distance = int.Parse(parts.Last());

            for (int i = 0; i < distance; i++)
            {
                MoveHead(direction, headCoordinate);
                MoveTail(headCoordinate, tailCoordinate);
                _visited.Add((tailCoordinate.X, tailCoordinate.Y));
            }
        }

        private void MoveTail(Coordinate headCoordinate, Coordinate tailCoordinate)
        {
            var xDiff = headCoordinate.X - tailCoordinate.X;
            var yDiff = headCoordinate.Y - tailCoordinate.Y;

            //Is Head boarding tail?
            if (Math.Abs(xDiff) <= 1 && Math.Abs(yDiff) <= 1)
            {
                //Nothing to update
                return;
            }

            if (Math.Abs(xDiff) > 1)
            {
                tailCoordinate.X += Math.Sign(xDiff);

                if (Math.Abs(yDiff) == 1)
                {
                    tailCoordinate.Y += Math.Sign(yDiff);
                }
            }

            if (Math.Abs(yDiff) > 1)
            {
                tailCoordinate.Y += Math.Sign(yDiff);

                if (Math.Abs(xDiff) == 1)
                {
                    tailCoordinate.X += Math.Sign(xDiff);
                }
            }
        }

        private void MoveHead(string direction, Coordinate headCoordinate)
        {
            switch (direction)
            {
                case "U":
                    headCoordinate.Y += 1;
                    break;

                case "D":
                    headCoordinate.Y -= 1;
                    break;

                case "L":
                    headCoordinate.X -= 1;
                    break;

                default: //"R"
                    headCoordinate.X += 1;
                    break;
            }
        }

        [Test]
        public void Part2()
        {
            _visited.Add((0, 0));
            var snake = new List<Coordinate>();
            var snakeLength = 10;

            snake.Add(new Coordinate(0, 0, "H"));

            for (int i = 1; i < snakeLength; i++)
            {
                snake.Add(new Coordinate(0, 0, i.ToString()));
            }

            foreach (var move in _data)
            {
                MoveLongTail(move, snake);
            }

            Console.WriteLine(_visited.Count);
            Assert.That(_visited.Count, Is.EqualTo(2619));
        }


        private void MoveLongTail(string move, List<Coordinate> snake)
        {
            string[] parts = move.Split(' ');
            var direction = parts.First();
            var distance = int.Parse(parts.Last());


            for (int i = 0; i < distance; i++)
            {
                MoveHead(direction, snake.First());

                for (int j = 0; j < snake.Count - 1; j++)
                {
                    MoveTail(snake[j], snake[j + 1]);
                    if (j == snake.Count - 2)
                    {
                        _visited.Add((snake.Last().X, snake.Last().Y));
                    }
                }
            }
        }

        private void Print(List<Coordinate> snake)
        {
            for (int y = -8; y < 16; y++)
            {
                var row = "";
                for (int x = -20; x < 20; x++)
                {
                    var matches = _visited.Contains((x, y));
                    if (matches)
                    {
                        row += "#";
                    }
                    else
                    {
                        row += ".";
                    }
                }

                Console.WriteLine(row);
            }

            Console.WriteLine();
        }
    }
}