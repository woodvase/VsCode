namespace LeetCode
{
    using System.Collections.Generic;
    public partial class Solution
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            TreeNode pre = null;
            TreeNode n = FindNode(root, key, ref pre);
            if (n == null)
            {
                return root;
            }

            if (n.left == null && n.right == null)
            {
                if (pre == null)
                {
                    return null;
                }

                if (n == pre.left)
                {
                    pre.left = null;
                }
                else
                {
                    pre.right = null;
                }

                return root;
            }

            TreeNode tmp = null;
            pre = n;
            if (n.right != null)
            {
                tmp = n.right;
                while (tmp.left != null)
                {
                    pre = tmp;
                    tmp = tmp.left;
                }
            }
            else
            {
                tmp = n.left;
                while (tmp.right != null)
                {
                    pre = tmp;
                    tmp = tmp.right;
                }
            }

            n.val = tmp.val;
            if (tmp == pre.left)
            {
                pre.left = null;
            }
            else
            {
                pre.right = null;
            }

            return root;
        }
        private TreeNode FindNode(TreeNode root, int key, ref TreeNode pre)
        {
            while (root != null)
            {
                if (root.val == key)
                {
                    return root;
                }
                if (root.val < key)
                {
                    pre = root;
                    root = root.right;
                }
                else
                {
                    pre = root;
                    root = root.left;
                }
            }

            return null;
        }
    }
}