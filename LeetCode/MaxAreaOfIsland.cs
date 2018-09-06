namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        // https://leetcode.com/problems/max-area-of-island/description/
        public int MaxAreaOfIsland(int[,] grid)
        {
            int max = 0;
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);
            bool[,] state = new bool[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i, j] == 1 && !state[i, j])
                    {
                        max = Math.Max(max, this.GetIslandArea(grid, state, i, j, row, col));
                    }
                }
            }

            return max;
        }

        private int GetIslandArea(int[,] grid, bool[,] state, int r, int c, int maxR, int maxC)
        {
            int ret = 1;
            state[r, c] = true;
            if (r >= 1 && !state[r - 1, c] && grid[r - 1, c] == 1)
            {
                state[r - 1, c] = true;
                ret = ret + this.GetIslandArea(grid, state, r - 1, c, maxR, maxC);
            }

            if (r + 1 < maxR && !state[r + 1, c] && grid[r + 1, c] == 1)
            {
                state[r + 1, c] = true;
                ret = ret + this.GetIslandArea(grid, state, r + 1, c, maxR, maxC);
            }

            if (c >= 1 && !state[r, c - 1] && grid[r, c - 1] == 1)
            {
                state[r, c - 1] = true;
                ret = ret + this.GetIslandArea(grid, state, r, c - 1, maxR, maxC);
            }

            if (c + 1 < maxC && !state[r, c + 1] && grid[r, c + 1] == 1)
            {
                state[r, c + 1] = true;
                ret = ret + this.GetIslandArea(grid, state, r, c + 1, maxR, maxC);
            }

            return ret;
        }
    }
}