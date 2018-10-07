namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            int sum = 0;
            if (nums.Length < 2)
            {
                return false;
            }
            if (k == 0)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] + nums[i + 1] == 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            long kk = k;
            if (k < 0)
            {
                kk = (-1) * k;
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if ((sum % kk == 0) && i > 0)
                {
                    return true;
                }
                foreach (int num in dict.Keys)
                {
                    if (((sum - num) % kk == 0) && ((i - dict[num]) > 1))
                    {
                        return true;
                    }
                }

                if (!dict.ContainsKey(sum))
                {
                    dict.Add(sum, i);
                }
            }

            return false;
        }
    }
}