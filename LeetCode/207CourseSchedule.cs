namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // 拓扑排序
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            int[] inDegree = new int[numCourses];
            int row = prerequisites.GetLength(0);
            for (int i = 0; i < row; i++)
            {
                inDegree[prerequisites[i, 1]] += 1;
            }
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    stack.Push(i);
                }
            }

            int Count = 0;
            while (stack.Count > 0)
            {
                int i = stack.Pop();
                Count++;
                inDegree[i] -= 1;
                for (int j = 0; j < row; j++)
                {
                    if (prerequisites[j, 0] == i)
                    {
                        inDegree[prerequisites[j, 1]] -= 1;
                        if (inDegree[prerequisites[j, 1]] == 0)
                        {
                            stack.Push(prerequisites[j, 1]);
                        }
                    }
                }
            }

            return Count == numCourses;
        }
    }
}