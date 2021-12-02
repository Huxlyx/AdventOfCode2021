using System.Collections.Generic;

namespace AdventOfCode2021.Src
{
    class Day01_1
    {

        public static int DepthCount1(string[] depths)
        {
            int lastDepth = -1;
            int increaseCount = 0;

            foreach(string depthStr in depths)
            {
                _ = int.TryParse(depthStr, out int depth);

                if (lastDepth > 0 && depth > lastDepth)
                {
                    ++increaseCount;
                }
                lastDepth = depth;
            }
            return increaseCount;
        }

        public static int DepthCount2(string[] depths)
        {
            int lastSum = -1;
            Queue<int> depthQueue = new(3);
            int increaseCount = 0;
            bool canCompare = false;

            foreach (string depthStr in depths)
            {
                _ = int.TryParse(depthStr, out int depth);

                depthQueue.Enqueue(depth);

                if (depthQueue.Count > 3)
                {
                    depthQueue.Dequeue();
                    canCompare = true;
                }

                int sum = 0;
                foreach (int queuedDepth in depthQueue)
                {
                    sum += queuedDepth;
                }

                if (canCompare && sum > lastSum)
                {
                    ++increaseCount;
                }
                lastSum = sum;
            }
            return increaseCount;
        }
    }
}
