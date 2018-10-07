namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public string ReverseString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }

            int i = 0;
            char[] a = new char[s.Length];
            while (i < s.Length)
            {
                a[i] = s[s.Length - i - 1];
                i++;
            }

            return new string(a);
        }

        public IList<string> FizzBuzz(int n)
        {
            List<string> ret = new List<string>();
            if (n <= 0)
            {
                return ret;
            }

            int i = 1;
            while (i <= n)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    ret.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    ret.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    ret.Add("Buzz");
                }
                else
                {
                    ret.Add(i.ToString());
                }
                i++;
            }

            return ret;
        }

        
    }
}