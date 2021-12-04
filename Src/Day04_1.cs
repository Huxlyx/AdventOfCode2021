using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Src
{
    class Day04_1
    {

        private readonly struct BingoBoard
        {
            private readonly float[][] fields;
            private readonly Dictionary<int, (int, int)> indexes;

            public BingoBoard(string[] bingoBoardStrings)
            {
                indexes = new();
                fields = new float[bingoBoardStrings.Length][];

                for (int y = 0; y < bingoBoardStrings.Length; ++y)
                {
                    string[] lineSplits = bingoBoardStrings[y].Split(' ', options: StringSplitOptions.RemoveEmptyEntries);
                    fields[y] = new float[lineSplits.Length];

                    for (int x = 0; x < lineSplits.Length; ++x)
                    {
                        _ = float.TryParse(lineSplits[x], out float val);
                        fields[y][x] = val;
                        indexes.Add((int)val, (y, x));
                    }
                }
            }

            public bool IsWin()
            {
                for (int y = 0; y < fields.Length; ++y)
                {
                    bool winCondX = true;
                    bool winCondY = true;
                    for (int x = 0; x < fields[y].Length; ++x)
                    {
                        if (winCondX && fields[y][x] >= 0)
                        {
                            if (fields[y][x] > 0 || ! IsNegativeZero(fields[y][x]))
                            {
                                winCondX = false;
                            }
                        }
                        if (winCondY && fields[x][y] >= 0)
                        {
                            if (fields[x][y] > 0 || ! IsNegativeZero(fields[x][y]))
                            {
                                winCondY = false;
                            }
                        }
                    }
                    if (winCondX || winCondY)
                    {
                        return true;
                    }
                }
                return false;
            }

            public void MaybeMark(int num)
            {
                (int y, int x) = indexes.GetValueOrDefault(num, (-1, -1));

                if (x < 0 || y < 0)
                {
                    return;
                }
                /* mark fields by turning them negative */
                fields[y][x] *= -1;
            }

            public int CalcBoarScore()
            {
                int result = 0;
                foreach (float[] line in fields)
                {
                    foreach (float row in line)
                    {
                        if (row > 0)
                        {
                            result += (int) row;
                        }
                    }
                }
                return result;
            }

            public override string ToString()
            {
                StringBuilder sb = new();
                foreach (float[] line in fields) 
                {
                    foreach (float row in line)
                    {
                        sb.Append(row.ToString().PadRight(3));
                    }
                    sb.Append('\n');
                }
                return sb.ToString();
            }
        }

        private static List<BingoBoard> SetupBoards(string[] bingoStrings)
        {
            List<BingoBoard> bingoBoards = new();

            int lineIdx = 1;
            int bingoBoardIdx = 0;
            string[] bingoBoardStrings = new string[5];
            while (++lineIdx < bingoStrings.Length)
            {
                if (bingoStrings[lineIdx].Length == 0)
                {
                    continue;
                }

                bingoBoardStrings[bingoBoardIdx++] = bingoStrings[lineIdx];

                if (bingoBoardIdx >= 5)
                {
                    bingoBoardIdx = 0;
                    bingoBoards.Add(new BingoBoard(bingoBoardStrings));
                }
            }
            return bingoBoards;
        }

        private static bool IsNegativeZero(double x)
        {
            return x == 0.0 && double.IsNegativeInfinity(1.0 / x);
        }

        public static int CalcScoreOfFirstBoard(string[] bingoStrings)
        {
            string[] numberStrings = bingoStrings[0].Split(',');
            int[] numbers = new int[numberStrings.Length];
            for (int i = 0; i < numberStrings.Length; ++i)
            {
                _ = int.TryParse(numberStrings[i], out int result);
                numbers[i] = result;
            }

            List<BingoBoard> bingoBoards = SetupBoards(bingoStrings);


            foreach (int number in numbers)
            {
                foreach (BingoBoard bingoBoard in bingoBoards)
                {
                    bingoBoard.MaybeMark(number);
                    if (bingoBoard.IsWin())
                    {
                        Console.WriteLine(bingoBoard);
                        return bingoBoard.CalcBoarScore() * number;
                    }
                }
            }
            return 1;
        }

        public static int CalcScoreOfLastBoard(string[] bingoStrings)
        {

            string[] numberStrings = bingoStrings[0].Split(',');
            int[] numbers = new int[numberStrings.Length];
            for (int i = 0; i < numberStrings.Length; ++i)
            {
                _ = int.TryParse(numberStrings[i], out int result);
                numbers[i] = result;
            }

            List<BingoBoard> bingoBoards = SetupBoards(bingoStrings);
            /* reverse so we can delete while iterating from back to front */
            bingoBoards.Reverse();


            int lastScore = 0;
            foreach (int number in numbers)
            {
                for (int i = bingoBoards.Count - 1; i >= 0; --i)
                {
                    BingoBoard bingoBoard = bingoBoards[i];
                    bingoBoard.MaybeMark(number);
                    if (bingoBoard.IsWin())
                    {
                        Console.WriteLine(bingoBoard);
                        lastScore = bingoBoard.CalcBoarScore() * number;
                        bingoBoards.RemoveAt(i);
                    }
                }
            }
            return lastScore;
        }
    }
}
