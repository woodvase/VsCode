namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public int LengthOfLongestSubstring_OriginalSolution(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }

            int start = 0;
            int max = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    if (dict[s[i]] >= start)
                    {
                        start = dict[s[i]] + 1;
                    }
                    dict[s[i]] = i;
                }
                else
                {
                    dict.Add(s[i], i);
                }

                max = Math.Max(max, i - start + 1);
            }

            return max;
        }

        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            int ret = 0;

            // Stores char and its position since there is no need to count every char.
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int startIndex = 0;
            int j = 0;
            while (j < s.Length)
            {
                if (dict.ContainsKey(s[j]))
                {
                    // startIndex is the the first repeating char's position + 1
                    // Why Math.Max(dict[s[j]] + 1, startIndex)? because that the repeating char could be 
                    // the one before the startIndex, for example, pwwkep, the last p. When it reaches to the second p,
                    // the dict has (p,0);
                    startIndex = Math.Max(dict[s[j]] + 1, startIndex);
                    dict[s[j]] = j;
                }
                else
                {
                    dict.Add(s[j], j);
                }

                ret = Math.Max(ret, j - startIndex + 1);
                j++;
            }

            return ret;
        }
    }
}