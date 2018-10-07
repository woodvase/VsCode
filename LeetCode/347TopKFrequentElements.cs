namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            List<int> ret = new List<int>();

            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (frequency.GetValueOrDefault(num) > 0)
                {
                    frequency[num] += 1;
                }
                else
                {
                    frequency.Add(num, 1);
                }
            }

            List<int>[] bucket = new List<int>[nums.Length + 1];
            foreach (int num in frequency.Keys)
            {
                if (bucket[frequency[num]] == null)
                {
                    bucket[frequency[num]] = new List<int>();
                }
                bucket[frequency[num]].Add(num);
            }

            for (int i = bucket.Length - 1; ret.Count < k; i--)
            {
                if (bucket[i] != null && bucket[i].Count > 0)
                {
                    ret.AddRange(bucket[i]);
                }
            }

            return ret.GetRange(0, k);
        }
    }
}
