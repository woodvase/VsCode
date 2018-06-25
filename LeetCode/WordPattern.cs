namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public bool WordPattern(string pattern, string str)
        {
            if (pattern == null || str == null)
            {
                return false;
            }
            if(string.IsNullOrWhiteSpace(pattern) && string.IsNullOrWhiteSpace(str))
            {
                return true;
            }

            int pLen = pattern.Length;
            string[] strs = str.Split(' ');
            int strLen = strs.Length;
            if (pLen != strLen)
            {
                return false;
            }

            Dictionary<char, string> dict = new Dictionary<char, string>();
            for (int i = 0; i < pLen; i++)
            {
                if (!dict.ContainsKey(pattern[i]))
                {
                    dict.Add(pattern[i], strs[i]);
                }
                else if (dict[pattern[i]] != strs[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}