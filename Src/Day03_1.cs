using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Src
{
    class Day03_1
    {

        public static int CalcConsumption1(string[] positionStrings)
        {

            int width = positionStrings[0].Length;
            int[] digits = new int[width];


            foreach (string positionStr in positionStrings)
            {
                for (int i = 0; i < width; ++i)
                {
                    if (positionStr[i] == '1')
                    {
                        digits[i]++;
                    }
                    else
                    {
                        digits[i]--;
                    }
                }
            }

            int gamma = 0;
            int epsilon = 0;

            for (int i = 0; i < width; ++i)
            {
                int num = 0;
                if (digits[i] > 0)
                {
                    num = 1;
                }
                else if (digits[i] == 0)
                {
                    Console.WriteLine("digits at " + i + "is 0");
                }
                gamma <<= 1;
                gamma += num;
                epsilon <<= 1;
                epsilon += num == 1 ? 0 : 1;
            }

            return epsilon * gamma;
        }

        public static int CalcConsumption2(string[] positionStrings)
        {

            int width = positionStrings[0].Length;
            int[] digits = new int[width];

            List<string> oxygens = new(positionStrings);
            List<string> scrubbings = new(positionStrings);

            for (int i = 0; i < width; ++i)
            {
                int count = 0;
                foreach(string oxygen in oxygens)
                {
                    count += oxygen[i] == '1' ? 1 : -1;
                }
                bool keepOxygenOne = count >= 0;

                count = 0;
                foreach (string scrubbing in scrubbings)
                {
                    count += scrubbing[i] == '0' ? 1 : -1;
                }
                bool keepScrubbingOne = count > 0;

                oxygens.RemoveAll(oxyVal => oxyVal[i] == (keepOxygenOne ? '0' : '1') && oxygens.Count > 1);
                scrubbings.RemoveAll(scrubVal => scrubVal[i] == (keepScrubbingOne ? '0' : '1') && scrubbings.Count > 1);
            }

            int oxyRating = 0;
            int scrubbingRating = 0;

            for (int i = 0; i < width; ++i)
            {
                oxyRating <<= 1;
                oxyRating += oxygens[0][i] == '1' ? 1 : 0;
                scrubbingRating <<= 1;
                scrubbingRating += scrubbings[0][i] == '1' ? 1 : 0;
            }

            return oxyRating * scrubbingRating;
        }
    }
}
