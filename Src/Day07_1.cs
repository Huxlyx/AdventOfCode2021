using System;
using System.Linq;

namespace AdventOfCode2021.Src
{
    class Day07_1
    {

        public static long CalcCrabFule(string[] lanternFishs)
        {
            var positions = lanternFishs[0].Split(',').Select(pos => int.Parse(pos));
            var groupedPositions = positions.GroupBy(pos => pos);
            int max = groupedPositions.Max(pos => pos.Key);
            int[] crabsOnPos = new int[max + 1];

            foreach (var pos in groupedPositions)
            {
                crabsOnPos[pos.Key] = pos.Count();
            }

            long minFule = long.MaxValue;
            for (int i = 0; i < crabsOnPos.Length; ++i)
            {
                long fuleConsump = 0;
                for (int j = 0; j < crabsOnPos.Length; ++j)
                {
                    int delta = Math.Abs(i - j);
                    fuleConsump += delta * crabsOnPos[j];
                }
                if (fuleConsump < minFule)
                {
                    minFule = fuleConsump;
                }
                Console.WriteLine($"Fuel for {i} : {fuleConsump}");
            }
            return minFule;
        }

        public static long CalcCrabFule2(string[] lanternFishs)
        {
            var positions = lanternFishs[0].Split(',').Select(pos => int.Parse(pos));
            var groupedPositions = positions.GroupBy(pos => pos);
            int max = groupedPositions.Max(pos => pos.Key);
            int[] crabsOnPos = new int[max + 1];
            int[] deltaTbl = new int[max + 1];

            foreach (var pos in groupedPositions)
            {
                crabsOnPos[pos.Key] = pos.Count();
            }

            for (int i = 1; i < crabsOnPos.Length; ++i)
            {
                deltaTbl[i] = i + deltaTbl[i - 1];
            }

            long minFule = long.MaxValue;
            for (int i = 0; i < crabsOnPos.Length; ++i)
            {
                long fuleConsump = 0;
                for (int j = 0; j < crabsOnPos.Length; ++j)
                {
                    int delta = deltaTbl[Math.Abs(i - j)];
                    fuleConsump += delta * crabsOnPos[j];
                }
                if (fuleConsump < minFule)
                {
                    minFule = fuleConsump;
                }
                Console.WriteLine($"Fuel for {i} : {fuleConsump}");
            }
            return minFule;
        }
    }
}
