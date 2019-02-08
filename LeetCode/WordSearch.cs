namespace LeetCode
{
    using System;

    public partial class Solution
    {
        public bool Exist(char[,] board, string word)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            bool[,] state = new bool[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (this.Helper(board, word, 0, state, i, j, row, col))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Helper(char[,] board, string word, int index, bool[,] visited, int r, int c, int row, int col)
        {
            if (index >= word.Length)
            {
                return true;
            }

            if (r < 0 || r >= row || c < 0 || c >= col || visited[r, c] || board[r, c] != word[index])
            {
                return false;
            }

            visited[r, c] = true;
            bool istrue = this.Helper(board, word, index + 1, visited, r - 1, c, row, col) ||
                this.Helper(board, word, index + 1, visited, r + 1, c, row, col) ||
                this.Helper(board, word, index + 1, visited, r, c - 1, row, col) ||
                this.Helper(board, word, index + 1, visited, r, c + 1, row, col);

            visited[r, c] = false;
            return istrue;
        }
    }
}