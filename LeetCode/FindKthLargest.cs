namespace LeetCode
{
    using System;
    public partial class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }

            int ret = min;
            while (min <= max)
            {
                int mid = min + (max - min) / 2;
                int cnt = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] >= mid)
                    {
                        cnt++;
                    }
                }
                if (cnt == k)
                {
                    ret = mid;
                    break;
                }
                if (cnt > k)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            return ret;
        }
    }
}