namespace LeetCode
{
    using System;

    public partial class Solution
    {

        // https://leetcode.com/problems/ugly-number-ii/description/
        public int NthUglyNumber(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            long[] ret = new long[n];
            ret[0] = 1;
            int[] primes = { 2, 3, 5 };

            for (int i = 1; i < n; i++)
            {
                ret[i] = Int64.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (ret[j] > (ret[i - 1] / 5))
                    {
                        for (int k = 0; k < primes.Length; k++)
                        {
                            long tmp = ret[j] * primes[k];
                            if (tmp > ret[i - 1] && tmp < ret[i])
                            {
                                ret[i] = tmp;
                                break;
                            }
                        }
                    }
                }
            }

            return (int)ret[n - 1];
        }
    }
}