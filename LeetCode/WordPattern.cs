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
            if (string.IsNullOrWhiteSpace(pattern) && string.IsNullOrWhiteSpace(str))
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

            Dictionary<char, string> dictPToS = new Dictionary<char, string>();
            Dictionary<string, char> dictSToP = new Dictionary<string, char>();
            for (int i = 0; i < pLen; i++)
            {
                if (!dictPToS.ContainsKey(pattern[i]))
                {
                    dictPToS.Add(pattern[i], strs[i]);

                }
                else if (dictPToS[pattern[i]] != strs[i])
                {
                    return false;
                }

                if (!dictSToP.ContainsKey(strs[i]))
                {
                    dictSToP.Add(strs[i], pattern[i]);
                }
                else if (dictSToP[strs[i]] != pattern[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}