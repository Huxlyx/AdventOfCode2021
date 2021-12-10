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
                        sum += CharVal(c);
                    }
                    scores.Add(sum);
                }
            }
            scores.Sort();
            return scores[scores.Count >> 1];
        }

        private static int CharVal(char c) => c switch
        {
            ')' => 1,
            ']' => 2,
            '}' => 3,
            '>' => 4,
            _ => throw new InvalidOperationException($"{c} not expected")
        };

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
                            if (c == ')')
                            {
                                return (3, null);
                            }
                            else if (c == ']')
                            {
                                return (57, null);
                            }
                            else if (c == '}')
                            {
                                return (1197, null);
                            }
                            else if (c == '>')
                            {
                                return (25137, null);
                            }
                        }
                        break;
                }
            }
            return (0, stack);
        }
    }
}
