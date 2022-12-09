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
        //private Dictionary<string,int> directionValues = new(){{"U",-1},{"D",+1},{"L",-1},{"R",+1}};

        private class Coordinate
        {
            public int X;
            public int Y;

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
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
                // Console.WriteLine("No tail movement");
                return;
            }
            // Console.WriteLine("Tail movement");

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

            _visited.Add((tailCoordinate.X, tailCoordinate.Y));
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

            for (int i = 0; i < snakeLength; i++)
            {
                snake.Add(new Coordinate(0, 0));
            }


            foreach (var move in _data)
            {
                MoveLongTail(move,snake);
            }

            Console.WriteLine(_visited.Count);
        }


        private void MoveLongTail(string move, List<Coordinate> snake)
        {
            string[] parts = move.Split(' ');
            var direction = parts.First();
            var distance = int.Parse(parts.Last());


            for (int i = 0; i < distance; i++)
            {
                MoveHead(direction, snake.First());
                MoveTail(snake.First(), snake[1]);

                for (int j = 1; j < snake.Count-1; j++)
                {
                    snake[j + 1].X = snake[j].X;
                    snake[j + 1].Y = snake[j].Y;
                }

                _visited.Add((snake.Last().X, snake.Last().Y));
            }
        }


        private void Print(List<Coordinate> snake)
        {
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    // if (snake.Contains(()))
                    // {
                    //
                    // }
                }
            }
        }
    }
}