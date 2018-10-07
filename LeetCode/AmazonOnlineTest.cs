namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Solution
    {
        public List<List<int>> ClosestXdestinations(int numDestinations, int[,] allLocations, int numDeliveries)
        {
            // WRITE YOUR CODE HERE
            List<List<int>> ret = new List<List<int>>();
            if (numDeliveries == 0)
            {
                return ret;
            }

            Dictionary<int, List<List<int>>> dict = new Dictionary<int, List<List<int>>>();
            for (int i = 0; i < numDestinations; i++)
            {
                // Assumption: the result doesn't overflow.
                int distance = allLocations[i, 0] * allLocations[i, 0] + allLocations[i, 1] * allLocations[i, 1];
                if (dict.ContainsKey(distance))
                {
                    dict[distance].Add(new List<int>() { allLocations[i, 0], allLocations[i, 1] });
                }
                else
                {
                    dict.Add(distance, new List<List<int>>() { new List<int>() { allLocations[i, 0], allLocations[i, 1] } });
                }
            }

            List<int> allDistance = dict.Keys.ToList();
            allDistance.Sort();

            for (int j = 0; j < numDeliveries; j++)
            {
                ret.AddRange(dict[allDistance[j]]);
            }

            // likely exceeds the numberDeliveris in the ret in case of two locations have same distance. so we need to remove
            return ret.Take(numDeliveries).ToList();
        }

        public int removeObstacleBfs(int numRows, int numColumns, int[,] lot)
        {
            bool[,] state = new bool[numRows, numColumns];
            Queue<Tuple<int, int, int>> Queue = new Queue<Tuple<int, int, int>>();
            Queue.Enqueue(Tuple.Create(0, 0, 0));
            while (Queue.Count > 0)
            {
                Tuple<int, int, int> pos = Queue.Dequeue();
                int r = pos.Item1;
                int c = pos.Item2;
                int s = pos.Item3;
                if (lot[r, c] == 9)
                {
                    return s;
                }

                state[r, c] = true;
                if ((r - 1 > 0 && !state[r - 1, c] && lot[r - 1, c] != 0))
                {
                    Queue.Enqueue(Tuple.Create(r - 1, c, s + 1));
                }

                if (r + 1 < numRows && !state[r + 1, c] && lot[r + 1, c] != 0)
                {
                    Queue.Enqueue(Tuple.Create(r + 1, c, s + 1));
                }

                if (c - 1 > 0 && !state[r, c - 1] && lot[r, c - 1] != 0)
                {
                    Queue.Enqueue(Tuple.Create(r, c - 1, s + 1));
                }

                if (c + 1 < numColumns && !state[r, c + 1] && lot[r, c + 1] != 0)
                {
                    Queue.Enqueue(Tuple.Create(r, c + 1, s + 1));
                }
            }
            return -1;
        }

        public int removeObstacle(int numRows, int numColumns, int[,] lot)
        {
            // WRITE YOUR CODE HERE
            bool[,] state = new bool[numRows, numColumns];
            return removeObstacleHelper(numRows, numColumns, lot, 0, 0, state);
        }

        private int removeObstacleHelper(int numRows, int numColumns, int[,] lot, int r, int c, bool[,] state)
        {
            int maxSteps = numRows * numColumns;
            if (r >= numRows || c >= numColumns)
            {
                return int.MaxValue;
            }

            if (lot[r, c] == 9)
            {
                return 0;
            }

            state[r, c] = true;
            int minStep = maxSteps;
            int step1 = maxSteps;
            if (r - 1 > 0 && !state[r - 1, c] && lot[r - 1, c] != 0)
            {
                step1 = 1 + removeObstacleHelper(numRows, numColumns, lot, r - 1, c, state);
            }

            if (step1 < minStep)
            {
                minStep = step1;
            }

            int step2 = maxSteps;
            if (r + 1 < numRows && !state[r + 1, c] && lot[r + 1, c] != 0)
            {
                step2 = 1 + removeObstacleHelper(numRows, numColumns, lot, r + 1, c, state);
            }

            if (step2 < minStep)
            {
                minStep = step2;
            }

            int step3 = maxSteps;
            if (c - 1 > 0 && !state[r, c - 1] && lot[r, c - 1] != 0)
            {
                step3 = 1 + removeObstacleHelper(numRows, numColumns, lot, r, c - 1, state);
            }

            if (step3 < minStep)
            {
                minStep = step3;
            }

            int step4 = maxSteps;
            if (c + 1 < numColumns && !state[r, c + 1] && lot[r, c + 1] != 0)
            {
                step4 = 1 + removeObstacleHelper(numRows, numColumns, lot, r, c + 1, state);
            }

            if (step4 < minStep)
            {
                minStep = step4;
            }

            return minStep;
        }
    }
}