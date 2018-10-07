namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            Array.Sort(coins);
            Array.Reverse(coins);
            return this.CoinChangeHelper(coins, amount, 0);
        }

        // Greedy, doesn't work for certain cases.
        private int CoinChangeHelper(int[] coins, int amount, int startIndex)
        {
            for (int i = startIndex; i < coins.Length; i++)
            {
                int m = amount / coins[i];
                int r = amount % coins[i];
                if (r == 0)
                {
                    return m;
                }

                if (i == coins.Length - 1 && r > 0)
                {
                    return -1;
                }

                for (; m >= 0; m--)
                {
                    r = amount - m * coins[i];
                    int c = CoinChangeHelper(coins, r, i + 1);
                    if (c != -1)
                    {
                        return m + c;
                    }
                }
            }

            return -1;
        }
    }
}