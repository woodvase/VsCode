namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            IList<int> p = new List<int>();
            bool[] status = new bool[nums.Length];
            this.PermuteHelper(nums, status, ret, p);
            return ret;
        }

        private void PermuteHelper(int[] nums, bool[] state, List<IList<int>> result, IList<int> permutation)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (state[i] == false)
                {
                    permutation.Add(nums[i]);
                    state[i] = true;
                    if (permutation.Count == nums.Length)
                    {
                        result.Add(new List<int>(permutation));
                    }
                    else
                    {
                        PermuteHelper(nums, state, result, permutation);
                    }
                    state[i] = false;
                    permutation.Remove(nums[i]);
                }
            }
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            int l = nums.Length;
            for (int i = 0; i < Math.Pow(2, l); i++)
            {
                List<int> set = new List<int>();
                for (int j = 0; j < l; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        set.Add(nums[j]);
                    }
                }

                ret.Add(set);
            }
            return ret;
        }
    }
}