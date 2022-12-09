using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2022
{
    [TestFixture]
    public class Day7
    {
        private List<string> data;
        private List<DirectoryInfo> directorySizes;

        //Create tree
        private record DirectoryInfo(DirectoryInfo parentDir, string name,int size);

        [SetUp]
        public void SetUp()
        {
            //Read into one string
            data = File.ReadAllLines("Day7.txt").ToList();
        }

        // private (int index, int size, string dirName,string parentDir) HandelCommand(int index, int size, string dirName, string parentDir)
        // {
        //     var elements = data[index].Split(' ');
        //
        //     if (elements.First().Equals("$"))
        //     {
        //         if (elements[1].Equals("ls"))
        //         {
        //
        //         } else if (elements[1].Equals("cd"))
        //         {
        //             if (elements[2].Equals(".."))
        //             {
        //             //     directorySizes.Add(new DirectoryInfo(dirName,size));
        //             //     //to do
        //             //     return (index + 1, size, dirName, null);
        //             }
        //         }
        //     }
        //     else
        //     {
        //         if (!elements.First().Equals("dir"))
        //         {
        //             //File
        //             return (index+1, size + int.Parse(elements.First()), dirName, parentDir);
        //         }
        //         else
        //         {
        //             //Directory
        //             return (index + 1, size, dirName, parentDir);
        //         }
        //     }
        //
        //     return null;
        // }

        // [Test]
        // public void Part1()
        // {
        //     foreach (var line in data)
        //     {
        //
        //     }
        // }
        //
        // [Test]
        // public void Part2()
        // {
        //
        // }
    }
}