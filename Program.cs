using AdventOfCode2021.Src;
using System;
using System.IO;

namespace AdventOfCode2021
{
    class Program
    {

        private const string PATH = @"C:\Users\mtengler\source\repos\AdventOfCode2021\AdventOfCode2021\Res\";

        static void Main(string[] args)
        {
            RunDay02_2();
        }

        public static void RunDay02_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day02_1.txt");
            Console.WriteLine(Day02_1.CalcPosition2(input));
        }

        public static void RunDay02_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day02_1.txt");
            Console.WriteLine(Day02_1.CalcPosition1(input));
        }

        public static void RunDay01_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day01_1.txt");
            Console.WriteLine(Day01_1.DepthCount2(input));
        }

        public static void RunDay01_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day01_1.txt");
            Console.WriteLine(Day01_1.DepthCount1(input));
        }
    }
}
