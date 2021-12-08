using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Src
{
    class Day08_1
    {

        public static long CalcDigits(string[] patterns)
        {
            int oneFourSevenEightCount = 0;

            foreach (string pattern in patterns)
            {
                string[] patternMappings = pattern.Split('|')[1].Split(' ');

                foreach (string patternMapping in patternMappings)
                {
                    switch (patternMapping.Length)
                    {
                        case 2:
                        case 3:
                        case 4:
                        case 7:
                            ++oneFourSevenEightCount;
                            break;
                    }
                }
            }
            return oneFourSevenEightCount;
        }

        private readonly struct Digit {
            private readonly char[] identifiers;

            public Digit(char[] identifiers)
            {
                this.identifiers = identifiers;
            }

            public bool IsDigit(char[] chars)
            {
                if (chars.Length != identifiers.Length)
                {
                    return false;
                }
                foreach(char c in chars)
                {
                    if ( ! identifiers.Contains(c))
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        public static long CalcDigits2(string[] inputs)
        {
            long combined = 0;

            foreach (string input in inputs)
            {
                string[] digitsAndNumbers = input.Split('|');
                string[] digits = digitsAndNumbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).OrderBy(s => s.Length).ToArray();

                char topSegment = '\0';
                char leftUpperSegment = '\0';
                char rightUpperSegment = '\0';
                char midSegment = '\0';
                char leftLowerSegment = '\0';
                char rightLowerSegment = '\0';
                char bottomSegment = '\0';

                List<char> rightUpperSegmentCandidates = digits[0].ToList();
                List<char> rightLowerSegmentCandidates = digits[0].ToList();

                /* find top segment */
                topSegment = digits[1].ToCharArray().First(c => ! rightUpperSegmentCandidates.Contains(c));

                List<char> midSegmentCandidates = digits[2].ToCharArray().Where(c => ! rightUpperSegmentCandidates.Contains(c)).ToList();

                /* find bottom segment - from digits with 5 segments only 3 has both right segments */
                foreach (string s in digits.Where(digit => digit.Length == 5 && digit.Contains(digits[0][0]) && digit.Contains(digits[0][1])))
                {
                    bottomSegment = s.ToCharArray().First(c => c != topSegment && ! digits[2].Contains(c));

                    /* we are working with 3 so we can now find the left upper segment of 4 */
                    leftUpperSegment = digits[2].ToCharArray().First(c => !s.Contains(c));

                    /* mid segment is the only thing left if we now remove the left upper segment from mid segment candidates */
                    midSegmentCandidates.Remove(leftUpperSegment);
                    midSegment = midSegmentCandidates.First();
                }


                /* 5 only has the lower segment on the right side, we can use this fact to find upper and lower right segments */
                /* from digits with 5 segments only 5 has a left upper segment */
                rightLowerSegment = digits.First(digit => digit.Length == 5 && digit.Contains(leftUpperSegment)).ToCharArray().First(c => rightLowerSegmentCandidates.Contains(c));

                rightUpperSegmentCandidates.Remove(rightLowerSegment);
                rightUpperSegment = rightUpperSegmentCandidates.First();

                foreach (char c in digits[9])
                {
                    if (c != topSegment && c != leftUpperSegment && c != rightUpperSegment && c != midSegment && c != rightLowerSegment && c != bottomSegment)
                    {
                        leftLowerSegment = c;
                        break;
                    }
                }

                Digit[] actualDigits = new Digit[]
                {
                    new Digit(new char[] { topSegment, leftUpperSegment, rightUpperSegment, leftLowerSegment, rightLowerSegment, bottomSegment }),
                    new Digit(new char[] { rightUpperSegment, rightLowerSegment }),
                    new Digit(new char[] { topSegment, rightUpperSegment, midSegment, leftLowerSegment, bottomSegment }),
                    new Digit(new char[] { topSegment, rightUpperSegment, midSegment, rightLowerSegment, bottomSegment }),
                    new Digit(new char[] { leftUpperSegment, rightUpperSegment, midSegment, rightLowerSegment }),
                    new Digit(new char[] { topSegment, leftUpperSegment, midSegment, rightLowerSegment, bottomSegment }),
                    new Digit(new char[] { topSegment, leftUpperSegment, midSegment, leftLowerSegment, rightLowerSegment, bottomSegment }),
                    new Digit(new char[] { topSegment, rightUpperSegment, rightLowerSegment }),
                    new Digit(new char[] { topSegment, leftUpperSegment, rightUpperSegment, midSegment, leftLowerSegment, rightLowerSegment, bottomSegment }),
                    new Digit(new char[] { topSegment, leftUpperSegment, rightUpperSegment, midSegment, rightLowerSegment, bottomSegment })
                };

                string[] numbers = digitsAndNumbers[1].Split(' ');

                int result = 0;
                foreach (string number in numbers)
                {
                    for (int i = 0; i < digits.Length; ++i)
                    {
                        if (actualDigits[i].IsDigit(number.ToArray()))
                        {
                            result *= 10;
                            result += i;
                            break;
                        }
                    }
                }
                combined += result;
            }

            return combined;
        }
    }
}
