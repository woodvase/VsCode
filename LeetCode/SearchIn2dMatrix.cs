namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        // https://leetcode.com/problems/search-a-2d-matrix-ii/description/
        public bool SearchMatrix(int[,] matrix, int target)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (row == 0 || col == 0 || target < matrix[0, 0] || target > matrix[row - 1, col - 1])
            {
                return false;
            }

            int r = 0;
            int c = col - 1;
            while (r < row && col >= 0)
            {
                if (target == matrix[r, c])
                {
                    return true;
                }
                else if (target > matrix[r, c])
                {
                    r++;
                }
                else
                {
                    c--;
                }
            }

            return false;
        }
    }
}