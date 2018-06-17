namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // https://leetcode.com/problems/two-sum/description/
        public int[] TwoSum(int[] nums, int target)
        {
            int[] ret = new int[2];
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    ret[0] = Math.Min(i, dict[diff]);
                    ret[1] = Math.Max(i, dict[diff]);
                    return ret;
                }
                else
                {
                    dict.Add(nums[i], i);
                }
            }
            return null;
        }
    }
}