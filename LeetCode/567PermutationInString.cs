namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s2) || s2.Length < s1.Length)
            {
                return false;
            }

            int[] dict = new int[26];
            foreach (char c in s1)
            {
                dict[c - 'a']++;
            }

            int start = 0;
            int end = 0;
            int neededCnt = s1.Length;
            while (end < s2.Length)
            {
                if (dict[s2[end] - 'a'] > 0)
                {
                    neededCnt--;
                }

                if (neededCnt == 0)
                {
                    return true;
                }

                dict[s2[end] - 'a']--;

                if (end - start + 1 == s1.Length)
                {
                    if (dict[s2[start] - 'a'] >= 0)
                    {
                        neededCnt++;
                    }

                    dict[s2[start] - 'a']++;
                    start++;
                }

                end++;
            }
            return false;
        }
    }
}