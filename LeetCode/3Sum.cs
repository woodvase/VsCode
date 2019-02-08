namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (nums == null || nums.Length < 2)
            {
                return ret;
            }

            Array.Sort(nums);
            HashSet<IList<int>> set = new HashSet<IList<int>>();
            for (int i = 0; i <= nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int start = i + 1;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int target = 0 - nums[i];
                    if (nums[start] + nums[end] == target)
                    {
                        IList<int> l = new List<int>() { nums[i], nums[start], nums[end] };
                        ret.Add(l);
                        while (start < end && nums[start] == nums[start + 1])
                        {
                            start++;
                        }

                        while (start < end && nums[end] == nums[end - 1])
                        {
                            end--;
                        }
                        
                        start++;
                        end--;
                    }
                    else if (nums[start] + nums[end] > target)
                    {
                        end--;
                    }
                    else
                    {
                        start++;
                    }
                }
            }

            return ret;
        }
    }
}