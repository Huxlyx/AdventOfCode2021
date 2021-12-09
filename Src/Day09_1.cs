using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Src
{
    class Day09_1
    {
        public static long CalcRiskSum(string[] smokeFlow)
        {
            char[][] map = smokeFlow.Select(line => line.ToCharArray()).ToArray();

            int maxY = smokeFlow.Length;
            int maxX = map[0].Length;

            long sum = 0;

            for (int y = 0; y < maxY; ++y)
            {
                for (int x = 0; x < maxX; ++x)
                {
                    char current = map[y][x];

                    if ((x > 0 && current >= map[y][x-1])
                    ||  (x < maxX -1 && current >= map[y][x+1])
                    ||  (y > 0 && current >= map[y-1][x])
                    ||  (y < maxY -1 && current >= map[y+1][x]))
                    {
                        continue;
                    }
                    sum += current - '0' + 1;
                }
            }

            return sum;
        }
        public static long CalcBasins(string[] smokeFlow)
        {
            char[][] map = smokeFlow.Select(line => line.ToCharArray()).ToArray();

            int maxY = smokeFlow.Length;
            int maxX = map[0].Length;

            List<(int, int)> lowPoints = new();
            for (int y = 0; y < maxY; ++y)
            {
                for (int x = 0; x < maxX; ++x)
                {
                    char current = map[y][x];

                    if ((x > 0 && current >= map[y][x - 1])
                    || (x < maxX - 1 && current >= map[y][x + 1])
                    || (y > 0 && current >= map[y - 1][x])
                    || (y < maxY - 1 && current >= map[y + 1][x]))
                    {
                        continue;
                    }
                    lowPoints.Add((y, x));
                }
            }


            List<int> basinSizes = new();
            foreach ((int y, int x) in lowPoints)
            {
                List<(int, int)> handledCoords = new();
                int size = TraverseUp(y, maxY, x, maxX, map, handledCoords);
                size += TraverseDown(y, maxY, x, maxX, map, handledCoords);
                size += TraverseLeft(y, maxY, x, maxX, map, handledCoords);
                size += TraverseRight(y, maxY, x, maxX, map, handledCoords);

                Console.WriteLine("Got basin of size " + size);
                basinSizes.Add(size);
            }


            return basinSizes.OrderByDescending(size => size).Take(3).Aggregate((a, b) => a * b);
        }

        private static int TraverseLeft(int startY, int maxY, int startX, int maxX, char[][] map, List<(int, int)> handledCoords)
        {
            int currentX = startX;
            int result = 0;
            while (--currentX >= 0 && map[startY][currentX] != '9')
            {
                if (!handledCoords.Contains((startY, currentX)))
                {
                    ++result;
                    handledCoords.Add((startY, currentX));
                    result += TraverseUp(startY, maxY, currentX, maxX, map, handledCoords);
                    result += TraverseDown(startY, maxY, currentX, maxX, map, handledCoords);
                }
            }
            return result;
        }

        private static int TraverseRight(int startY, int maxY, int startX, int maxX, char[][] map, List<(int, int)> handledCoords)
        {
            int currentX = startX;
            int result = 0;
            while (++currentX < maxX && map[startY][currentX] != '9')
            {
                if (!handledCoords.Contains((startY, currentX)))
                {
                    ++result;
                    handledCoords.Add((startY, currentX));
                    result += TraverseUp(startY, maxY, currentX, maxX, map, handledCoords);
                    result += TraverseDown(startY, maxY, currentX, maxX, map, handledCoords);
                }
            }
            return result;
        }
        private static int TraverseUp(int startY, int maxY, int startX, int maxX, char[][] map, List<(int, int)> handledCoords)
        {
            int currentY = startY;
            int result = 0;
            while (--currentY >= 0 && map[currentY][startX] != '9')
            {
                if (!handledCoords.Contains((currentY, startX)))
                {
                    ++result;
                    handledCoords.Add((currentY, startX));
                    result += TraverseLeft(currentY, maxY, startX, maxX, map, handledCoords);
                    result += TraverseRight(currentY, maxY, startX, maxX, map, handledCoords);
                }
            }
            return result;
        }
        private static int TraverseDown(int startY, int maxY, int startX, int maxX, char[][] map, List<(int, int)> handledCoords)
        {
            int currentY = startY;
            int result = 0;
            while (++currentY < maxY && map[currentY][startX] != '9')
            {
                if (!handledCoords.Contains((currentY, startX)))
                {
                    ++result;
                    handledCoords.Add((currentY, startX));
                    result += TraverseLeft(currentY, maxY, startX, maxX, map, handledCoords);
                    result += TraverseRight(currentY, maxY, startX, maxX, map, handledCoords);
                }
            }
            return result;
        }
    }

}
