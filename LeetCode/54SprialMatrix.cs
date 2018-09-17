namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            List<int> ret = new List<int>();
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int level = 1;
            int maxCol = col - level;
            int maxRow = row - level;
            int startCol = 0;
            int startRow = 0;

            while (startRow <= maxRow && startCol <= maxCol)
            {
                int i = startRow;
                int j = startCol;
                for (; j <= maxCol; j++)
                {
                    ret.Add(matrix[i, j]);
                }

                i = startRow + 1;
                j = maxCol;
                for (; i <= maxRow; i++)
                {
                    ret.Add(matrix[i, j]);
                }

                if (startRow != maxRow && startCol != maxCol)
                {
                    i = maxRow;
                    j = maxCol - 1;
                    for (; j >= startCol; j--)
                    {
                        ret.Add(matrix[i, j]);
                    }

                    i = maxRow - 1;
                    j = startCol;
                    for (; i > startRow; i--)
                    {
                        ret.Add(matrix[i, j]);
                    }
                }

                level++;
                startRow++;
                startCol++;
                maxCol = col - level;
                maxRow = row - level;
            }
            return ret;
        }
    }
}
