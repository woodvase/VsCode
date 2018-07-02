namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // https://leetcode.com/problems/path-sum/description/
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.left == null && root.right == null)
            {
                return root.val == sum;
            }

            return this.HasPathSum(root.left, sum - root.val) || this.HasPathSum(root.right, sum - root.val);
        }
    }
}