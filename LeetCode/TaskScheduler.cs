namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // Basiclly the idea is to sort the frequency of the tasks, then to create groups of n tasks including idles in between.
        // Tasks with most frequency should place together.  
        // For example, for (A,A,A,B,B,B) and n = 2, there are 3 groups: AB_AB_AB
        // If the rest of tasks can fill in the idles, then all the actual idles plus count of all tasks should be the answer.
        // If the rest of tasks is more than the idles, then the count of tasks will be the answer. Why?
        // If the rest of tasks are distinct tasks, then there is no need to add any idle in between.
        // If there are repeating tasks in the remaining tasks, then their frequency should be at most (Max - 1).
        // Thus they can be added to the previous groups without violating the rule. So there is no need to add idles to tasks
        // for the remaining tasks. For example, (A,A,A,B,B,B,C,C,D,E,E,F) and n = 2.
        // We have AB_AB_AB in the beginning. Then fill it with 'C'. It is ABCABCAB. D,E,E,F are left tasks. Task E can be added
        // To previous groups. It will be ABCEABCEAB, now D, F are left. They can be just appended to the end. It will be ABCEABCEABDF
        public int LeastInterval(char[] tasks, int n)
        {
            int[] charCount = new int[26];
            for (int i = 0; i < tasks.Length; i++)
            {
                charCount[tasks[i] - 'A']++;
            }

            int max = 0;
            int cntOfMax = 0;
            for (int i = 0; i < charCount.Length; i++)
            {
                if (max < charCount[i])
                {
                    max = charCount[i];
                    cntOfMax = 0;
                }
                if (max == charCount[i])
                {
                    cntOfMax += 1;
                }
            }

            // Total idles if no other tasks to fill
            int idleCnt = (max - 1) * (n - cntOfMax + 1);
            int leftTasks = tasks.Length - max * cntOfMax;
            int idles = Math.Max(0, idleCnt - leftTasks);
            return tasks.Length + idles;
        }
    }
}