using System.Linq;

namespace AdventOfCode2021.Src
{
    class Day06_1
    {

        public static long CalcLanternFishs(string[] lanternFishs, int iterations)
        {
            var points = lanternFishs[0].Split(',').Select(fish => int.Parse(fish)).GroupBy(age => age);

            long[] lanternfishs = new long[9];
            foreach (var point in points)
            {
                lanternfishs[point.Key] = point.Count();
            }

            for (int iteration = 0; iteration < iterations; ++iteration)
            {
                long zeroGen = lanternfishs[0];
                for (int i = 1; i < lanternfishs.Length; ++i)
                {
                    lanternfishs[i - 1] = lanternfishs[i];
                }

                lanternfishs[8] = zeroGen;
                lanternfishs[6] += zeroGen;
            }

            return lanternfishs.Sum();
        }
    }
}
