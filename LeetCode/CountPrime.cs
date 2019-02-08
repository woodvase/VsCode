namespace LeetCode
{
    using System;

    public partial class Solution
    {
        public int CountPrimes(int n)
        {
            if (n < 2)
            {
                return 0;
            }
            int cnt = 0;
            bool[] NotPrime = new bool[n];
            for (int i = 2; i < n; i++)
            {
                if (NotPrime[i])
                {
                    continue;
                }
                cnt++;
                for (int j = i; j * i < n; j++)
                {
                    NotPrime[j * i] = true;
                }
            }

            return cnt;
        }
    }
}