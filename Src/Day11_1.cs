using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Src
{
    class Day11_1
    {

        public static long CalcFlashingOctopus(string[] codeLines)
        {
            int[][] grid = codeLines.Select(line => Array.ConvertAll(line.ToCharArray(), ch => ch - '0')).ToArray();

            int flashes = 0;

            for (int i = 0; i < 100; ++i)
            {
                for (int y = 0; y < grid.Length; ++y)
                {
                    for (int x = 0; x < grid[0].Length; ++x)
                    {
                        grid[y][x] += 1;
                        if (grid[y][x] == 10)
                        {
                            CheckAndIncrementAdjacent(y, x, grid);
                        }
                    }
                }

                for (int y = 0; y < grid.Length; ++y)
                {
                    for (int x = 0; x < grid[0].Length; ++x)
                    {
                        if (grid[y][x] > 9)
                        {
                            grid[y][x] = 0;
                            ++flashes;
                        }
                    }
                }
            }

            return flashes;
        }

        public static long CalcAllFlashingOctopus(string[] codeLines)
        {
            int[][] grid = codeLines.Select(line => Array.ConvertAll(line.ToCharArray(), ch => ch - '0')).ToArray();

            bool done = false;
            int step = 0;
            while ( ! done)
            {
                ++step;
                for (int y = 0; y < grid.Length; ++y)
                {
                    for (int x = 0; x < grid[0].Length; ++x)
                    {
                        grid[y][x] += 1;
                        if (grid[y][x] == 10)
                        {
                            CheckAndIncrementAdjacent(y, x, grid);
                        }
                    }
                }

                int flashes = 0;
                for (int y = 0; y < grid.Length; ++y)
                {
                    for (int x = 0; x < grid[0].Length; ++x)
                    {
                        if (grid[y][x] > 9)
                        {
                            grid[y][x] = 0;
                            ++flashes;
                        }
                    }
                }

                if (flashes == grid.Length * grid[0].Length)
                {
                    done = true;
                }

            }

            return step;
        }

        private static void CheckAndIncrementAdjacent(int y, int x, int[][] grid)
        {
            /* left upper */
            if (y > 0 && x > 0)
            {
                if (++grid[y - 1][x - 1] == 10)
                {
                    CheckAndIncrementAdjacent(y - 1, x - 1, grid);
                }
            }
            /* upper */
            if (y > 0)
            {
                if (++grid[y - 1][x] == 10)
                {
                    CheckAndIncrementAdjacent(y - 1, x, grid);
                }
            }
            /* right upper */
            if (y > 0 && x < grid[y].Length - 1)
            {
                if (++grid[y - 1][x + 1] == 10)
                {
                    CheckAndIncrementAdjacent(y - 1, x + 1, grid);
                }
            }
            /* left */
            if (x > 0)
            {
                if (++grid[y][x - 1] == 10)
                {
                    CheckAndIncrementAdjacent(y, x - 1, grid);
                }
            }
            /* right */
            if (x < grid[y].Length - 1)
            {
                if (++grid[y][x + 1] == 10)
                {
                    CheckAndIncrementAdjacent(y, x + 1, grid);
                }
            }
            /* left lower */
            if (y < grid.Length - 1 && x > 0)
            {
                if (++grid[y + 1][x - 1] == 10)
                {
                    CheckAndIncrementAdjacent(y + 1, x - 1, grid);
                }
            }
            /* lower */
            if (y < grid.Length - 1)
            {
                if (++grid[y + 1][x] == 10)
                {
                    CheckAndIncrementAdjacent(y + 1, x, grid);
                }
            }
            /* right lower */
            if (y < grid.Length - 1 && x < grid[y].Length - 1)
            {
                if (++grid[y + 1][x + 1] == 10)
                {
                    CheckAndIncrementAdjacent(y + 1, x + 1, grid);
                }
            }
        }
    }
}
