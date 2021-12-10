using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Src
{
    class Day10_1
    {
        public static long CalcSyntaxErrors(string[] codeLines)
        {
            return codeLines.Select(line => HandleLine(line).Item1).Aggregate((a, b) => a + b);
        }

        public static long CalcMissingChars(string[] codeLines)
        {
            List<long> scores = new();
            foreach (string codeLine in codeLines)
            {
                (_, Stack<char> stack) = HandleLine(codeLine);

                if (stack?.Count > 0)
                {
                    long sum = 0;
                    foreach (char c in stack)
                    {
                        sum *= 5;
                        sum += c switch
                        {
                            ')' => 1,
                            ']' => 2,
                            '}' => 3,
                            '>' => 4,
                            _ => throw new InvalidOperationException($"{c} not expected")
                        };
                    }
                    scores.Add(sum);
                }
            }
            scores.Sort();
            return scores[scores.Count >> 1];
        }

        private static (int, Stack<char>) HandleLine(string codeLine)
        {
            Stack<char> stack = new();

            foreach (char c in codeLine)
            {
                switch (c)
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '<':
                        stack.Push('>');
                        break;
                    default:
                        if (stack.Count == 0 || stack.Pop() != c)
                        {
                            return c switch
                            {
                                ')' => (3, null),
                                ']' => (57, null),
                                '}' => (1197, null),
                                '>' => (25137, null),
                                _ => throw new InvalidOperationException($"{c} not expected")
                            };
                        }
                        break;
                }
            }
            return (0, stack);
        }
    }
}
