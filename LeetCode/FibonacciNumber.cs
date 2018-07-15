namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public List<int> Fibonacci(int n)
        {
            if(n < 1)
            {
                throw new Exception("n > 0");
            }

            List<int> ret = new List<int>() { 1 };
            if (n == 1)
            {
                return ret;
            }

            int pre = 0;
            int current = 1;
            int i = 2;
            while (i <= n)
            {
                i++;
                current += pre;
                pre = current - pre;
                ret.Add(current);
            }

            return ret;
        }
    }
}