namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    { 
        public int kthSmallest(TreeNode root, int k) {
        Stack<TreeNode> s = new Stack<TreeNode>();
        TreeNode n = root;
        while(s.Count > 0 || n != null)
        {
            while(n != null)
            {
                s.Push(n);
                n = n.left;
            }
            
            n = s.Pop();
            k --;
            if(k == 0)
            {
                return n.val;
            }
            n = n.right;
        }
        
        return -1;
    }
    }
}