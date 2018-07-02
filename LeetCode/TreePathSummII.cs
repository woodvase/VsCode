namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // https://leetcode.com/problems/path-sum-ii/description/
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var ret = new List<IList<int>>();
            if (root == null)
            {
                return ret;
            }

            if (root.left == null && root.right == null)
            {
                if (root.val == sum)
                {
                    IList<int> l = new List<int>() { root.val };
                    ret.Add(l);
                }

                return ret;
            }

            var leftRet = this.PathSum(root.left, sum - root.val);
            if (leftRet != null)
            {
                foreach (List<int> l in leftRet)
                {
                    l.Insert(0, root.val);
                    ret.Add(l);
                }
            }

            var rightRet = this.PathSum(root.right, sum - root.val);
            if (rightRet != null)
            {
                foreach (List<int> l in rightRet)
                {
                    l.Insert(0, root.val);
                    ret.Add(l);
                }
            }

            return ret;
        }
    }
}