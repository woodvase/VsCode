namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        // https://leetcode.com/problems/rectangle-overlap/description/
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            return !((rec2[0] >= rec1[2]) || (rec2[2] <= rec1[0]) || (rec2[1] >= rec1[3]) || (rec2[3] <= rec1[1]));
        }

        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            throw new NotImplementedException();
        }
    }
}