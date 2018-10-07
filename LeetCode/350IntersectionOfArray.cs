namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> ret = new List<int>();
            Dictionary<int, int> d1 = new Dictionary<int, int>();
          
            for (int i = 0; i < nums1.Length; i++)
            {
                if (d1.ContainsKey(nums1[i]))
                {
                    d1[nums1[i]]++;
                }
                else
                {
                    d1.Add(nums1[i], 1);
                }
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (d1.ContainsKey(nums2[i]) && d1[nums2[i]] > 0)
                {
                    ret.Add(nums2[i]);
                    d1[nums2[i]]--;
                }
            }

            return ret.ToArray();
        }
    }
}