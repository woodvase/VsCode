namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // https://leetcode.com/problems/search-in-rotated-sorted-array/description/
        public int Search(int[] nums, int target)
        {
            return this.SearchHelper(nums, target, 0, nums.Length - 1);
        }

        private int SearchHelper(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;

                if (nums[m] == target)
                {
                    return m;
                }
                if (nums[l] <= nums[m])
                {
                    if (target >= nums[l] && target < nums[m])
                    {
                        r = m;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }
                else
                {
                    if (target > nums[m] && target <= nums[r])
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m;
                    }
                }
            }

            return -1;
        }

        private int SearchHelper(int[] nums, int target, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int m = start + (end - start) / 2;
            if (nums[m] == target)
            {
                return m;
            }

            if (start == end)
            {
                return -1;
            }

            if (nums[start] <= nums[m])
            {
                if (target >= nums[start] && target < nums[m])
                {
                    return this.SearchHelper(nums, target, start, m - 1);
                }
                else
                {
                    return this.SearchHelper(nums, target, m + 1, end);
                }
            }
            else
            {
                if (target > nums[m] && target <= nums[end])
                {

                    return this.SearchHelper(nums, target, m + 1, end);
                }
                else
                {
                    return this.SearchHelper(nums, target, start, m - 1);
                }
            }
        }
    }
}