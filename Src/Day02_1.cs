using System;

namespace AdventOfCode2021.Src
{
    class Day02_1
    {

        public static int CalcPosition1(string[] positionStrings)
        {
            int forward = 0;
            int depth = 0;

            foreach(string positionStr in positionStrings)
            {
                string[] parts = positionStr.Split(' ');
                _ = int.TryParse(parts[1], out int val);

                switch (parts[0])
                {
                    case "forward":
                        forward += val;
                        break;
                    case "down":
                        depth += val;
                        break;
                    case "up":
                        depth -= val;
                        break;
                    default:
                        Console.Write("Unknown identifier " + parts[0]);
                        break;
                }
            }
            return forward * depth;
        }

        internal static int CalcPosition2(string[] positionStrings)
        {
            int forward = 0;
            int depth = 0;
            int aim = 0;

            foreach (string positionStr in positionStrings)
            {
                string[] parts = positionStr.Split(' ');
                _ = int.TryParse(parts[1], out int val);

                switch (parts[0])
                {
                    case "forward":
                        forward += val;
                        depth += aim * val;
                        break;
                    case "down":
                        aim += val;
                        break;
                    case "up":
                        aim -= val;
                        break;
                    default:
                        Console.Write("Unknown identifier " + parts[0]);
                        break;
                }
            }
            return forward * depth;
        }
    }
}
