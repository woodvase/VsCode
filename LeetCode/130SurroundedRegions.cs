namespace LeetCode
{
    public partial class Solution
    {
        public void Solve(char[,] board)
        {
            if (board == null)
            {
                return;
            }

            int row = board.GetLength(0);
            int col = board.GetLength(1);
            bool[,] state = new bool[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i, j] == 'O')
                    {
                        if (canFlip(board, state, i, j, row, col))
                        {
                            board[i, j] = 'X';
                        }
                    }
                }
            }
        }

        private bool canFlip(char[,] board, bool[,] state, int r, int c, int row, int col)
        {
            if (board[r,c] == 'O' && (r >= row - 1 || r <= 0 || c >= col - 1 || c <= 0))
            {
                return false;
            }

            if (board[r,c] == 'X' || state[r, c])
            {
                return true;
            }

            state[r, c] = true;

            if (!canFlip(board, state, r - 1, c, row, col))
            {
                return false;
            }
            if (!canFlip(board, state, r + 1, c, row, col))
            {
                return false;
            }
            if (!canFlip(board, state, r, c - 1, row, col))
            {
                return false;
            }
            if (!canFlip(board, state, r, c + 1, row, col))
            {
                return false;
            }

            state[r, c] = false;

            return true;
        }
    }
}