namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            string s = str.Trim();
            long ret = 0;
            int flag = 1;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c >= '0' && c <= '9')
                {
                    ret = ret * 10 + c - '0';
                    long tmp = ret * flag;

                    if (tmp > Int32.MaxValue)
                    {
                        return Int32.MaxValue;
                    }

                    if (tmp < Int32.MinValue)
                    {
                        return Int32.MinValue;
                    }
                }
                else
                {
                    if (i == 0 && c == '-')
                    {
                        flag = -1;
                    }
                    else if (i == 0 && c == '+')
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return (int)ret * flag;
        }
    }
}