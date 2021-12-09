using AdventOfCode2021.Src;
using System;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode2021
{
    class Program
    {

        private const string PATH = @"..\..\..\Res\";

        static void Main(string[] args)
        {
            RunDay09_2();
        }

        public static void RunDay09_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day09_1.txt");
            Console.WriteLine(Day09_1.CalcBasins(input));
        }

        public static void RunDay09_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day09_1.txt");
            Console.WriteLine(Day09_1.CalcRiskSum(input));
        }

        public static void RunDay08_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day08_1.txt");
            Console.WriteLine(Day08_1.CalcDigits2(input));
        }

        public static void RunDay08_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day08_1.txt");
            Console.WriteLine(Day08_1.CalcDigits(input));
        }

        public static void RunDay07_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day07_1.txt");
            Console.WriteLine(Day07_1.CalcCrabFule2(input));
        }

        public static void RunDay07_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day07_1.txt");
            Console.WriteLine(Day07_1.CalcCrabFule(input));
        }

        public static void RunDay06_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day06_1.txt");
            Console.WriteLine(Day06_1.CalcLanternFishs(input, 256));
        }

        public static void RunDay06_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day06_1.txt");
            Console.WriteLine(Day06_1.CalcLanternFishs(input, 80));
        }

        public static void RunDay05_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day05_1.txt");
            Console.WriteLine(Day05_1.CalcOverlaps2(input));
        }

        public static void RunDay05_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day05_1.txt");
            Console.WriteLine(Day05_1.CalcOverlaps(input));
        }

        public static void RunDay04_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day04_1.txt");
            Console.WriteLine(Day04_1.CalcScoreOfLastBoard(input));
        }

        public static void RunDay04_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day04_1.txt");
            Console.WriteLine(Day04_1.CalcScoreOfFirstBoard(input));
        }

        public static void RunDay03_2()
        {
            string[] input = File.ReadAllLines(PATH + "Day03_1.txt");
            Console.WriteLine(Day03_1.CalcConsumption2(input));
        }

        public static void RunDay03_1()
        {
            string[] input = File.ReadAllLines(PATH + "Day03_1.txt");
            Console.WriteLine(Day03_1.CalcConsumption1(input));
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
