namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
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
                    // startIndex will the the current position or the last repeating char's position
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