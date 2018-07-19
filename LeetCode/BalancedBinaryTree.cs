namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public bool IsBalanced(TreeNode root)
        {
            int d = 0;
            return IsBalancedHelper(root, out d);
        }

        private bool IsBalancedHelper(TreeNode root, out int depth)
        {
            if (root == null)
            {
                depth = 0;
                return true;
            }

            int ld = 0;
            bool ifLeftBalanced = true;
            ifLeftBalanced = IsBalancedHelper(root.left, out ld);

            int rd = 0;
            bool ifRightBalanced = true;
            ifRightBalanced = IsBalancedHelper(root.right, out rd);

            depth = 1 + Math.Max(ld, rd);
            if (ifLeftBalanced && ifRightBalanced)
            {
                return Math.Abs(ld - rd) > 1;
            }
            
            return false;
        }
    }
}