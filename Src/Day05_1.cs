using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Src
{
    class Day05_1
    {

        private readonly struct Grid
        {
            readonly int[][] cells;

            public Grid(int maxY, int maxX)
            {
                cells = new int[maxY][];
                for (int i = 0; i < cells.Length; ++i)
                {
                    cells[i] = new int[maxX];
                }
            }

            public void Mark(int y, int x)
            {
                ++cells[y][x];
            }

            public int CountGe2()
            {
                int count = 0;
                foreach (int[] row in cells)
                {
                    foreach(int col in row)
                    {
                        if (col >= 2)
                        {
                            ++count;
                        }
                    }
                }
                return count;
            }

            public override string ToString()
            {
                StringBuilder sb = new(cells.Length * cells[0].Length);
                foreach (int[] row in cells)
                {
                    foreach (int col in row)
                    {
                        sb.Append(col == 0 ? "." : col.ToString());
                    }
                    sb.Append('\n');
                }
                return sb.ToString();
            }
        }

        public static int CalcOverlaps(string[] coordStrings)
        {
            List<(Point, Point)> points = coordStrings.Select(coordString => coordString.Replace(" -> ", ",").ToString())
                .Select(combinedCoord => combinedCoord.Split(',')).ToArray()
                .Select(coordRow => (new Point(int.Parse(coordRow[0]), int.Parse(coordRow[1])), new Point(int.Parse(coordRow[2]), int.Parse(coordRow[3])))).ToList();

            int maxX = 0;
            int maxY = 0;

            foreach ((Point p1, Point p2) in points)
            {
                if (p1.X > maxX)
                {
                    maxX = p1.X;
                }
                if (p2.X > maxX)
                {
                    maxX = p2.X;
                }
                if (p1.Y > maxY)
                {
                    maxY = p1.Y;
                }
                if (p2.Y > maxY)
                {
                    maxY = p2.Y;
                }
            }

            Grid grid = new(maxY + 1, maxX + 1);
            points.RemoveAll(pointPair => pointPair.Item1.X != pointPair.Item2.X && pointPair.Item1.Y != pointPair.Item2.Y);

            foreach ((Point p1, Point p2) in points)
            {

                if (p1.X == p2.X)
                {
                    for (int i = p1.Y < p2.Y ? p1.Y : p2.Y; i <= (p1.Y < p2.Y ? p2.Y : p1.Y); ++i)
                    {
                        grid.Mark(i, p1.X);
                    }
                }
                else if (p1.Y == p2.Y)
                {
                    for (int i = p1.X < p2.X ? p1.X : p2.X; i <= (p1.X < p2.X ? p2.X : p1.X); ++i)
                    {
                        grid.Mark(p1.Y, i);
                    }
                }
            }

            return grid.CountGe2();
        }

        public static int CalcOverlaps2(string[] coordStrings)
        {
            List<(Point, Point)> points = coordStrings.Select(coordString => coordString.Replace(" -> ", ",").ToString())
                  .Select(combinedCoord => combinedCoord.Split(',')).ToArray()
                  .Select(coordRow => (new Point(int.Parse(coordRow[0]), int.Parse(coordRow[1])), new Point(int.Parse(coordRow[2]), int.Parse(coordRow[3])))).ToList();

            int maxX = 0;
            int maxY = 0;

            foreach ((Point p1, Point p2) in points)
            {
                if (p1.X > maxX)
                {
                    maxX = p1.X;
                }
                if (p2.X > maxX)
                {
                    maxX = p2.X;
                }
                if (p1.Y > maxY)
                {
                    maxY = p1.Y;
                }
                if (p2.Y > maxY)
                {
                    maxY = p2.Y;
                }
            }

            Grid grid = new(maxY + 1, maxX + 1);
            foreach ((Point p1, Point p2) in points)
            {

                if (p1.X == p2.X)
                {
                    for (int i = p1.Y < p2.Y ? p1.Y : p2.Y; i <= (p1.Y < p2.Y ? p2.Y : p1.Y); ++i)
                    {
                        grid.Mark(i, p1.X);
                    }
                }
                else if (p1.Y == p2.Y)
                {
                    for (int i = p1.X < p2.X ? p1.X : p2.X; i <= (p1.X < p2.X ? p2.X : p1.X); ++i)
                    {
                        grid.Mark(p1.Y, i);
                    }
                }
                else
                {
                    bool incX = p1.X < p2.X;
                    bool incY = p1.Y < p2.Y;
                    int idxY = p1.Y;
                    int idxX = p1.X;

                    for (int i = 0; i <= Math.Abs(p1.X - p2.X); ++i)
                    {
                        grid.Mark(incY ? idxY++ : idxY--, incX ? idxX++ : idxX--);
                    }
                }
            }

            return grid.CountGe2();
        }
    }
}
