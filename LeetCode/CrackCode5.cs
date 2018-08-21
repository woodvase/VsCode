namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public partial class CrackCode
    {
        public int updateBits(int n, int m, int i, int j)
        {
            int max = ~0; /* All 1’s */

            // 1’s through position j, then 0’s
            int left = max - ((1 << j) - 1);

            // 1’s after position i
            int right = ((1 << i) - 1);

            // 1’s, with 0s between i and j
            int mask = left | right;

            // Clear i through j, then put m in there
            return (n & mask) | (m << i);
        }
    }
}