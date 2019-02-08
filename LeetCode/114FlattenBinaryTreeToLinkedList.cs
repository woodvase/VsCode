namespace LeetCode
{
    using System;
    public partial class Solution
    {
        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode n = root;
            while (n != null)
            {
                if (n.left != null)
                {
                    if (n.right != null)
                    {
                        TreeNode rightChild = n.left;
                        while (rightChild.right != null)
                        {
                            rightChild = rightChild.right;
                        }
                        rightChild.right = n.right;
                    }

                    n.right = n.left;
                    n.left = null;
                }
                n = n.right;
            }
        }
    }
}