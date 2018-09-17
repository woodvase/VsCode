namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Solution
    {
        // Sort and compare
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> indexes = new List<int>();
            if (s.Length < p.Length)
            {
                return indexes;
            }

            string sortedP = new string(p.OrderBy(c => c).ToArray());
            for (int i = 0; i <= s.Length - sortedP.Length + 1; i++)
            {
                string substr = s.Substring(i, sortedP.Length);
                substr = new string(substr.OrderBy(ch => ch).ToArray());
                if (string.Equals(sortedP, substr, StringComparison.OrdinalIgnoreCase))
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        public IList<int> FindAnagramsSlidingWindow(string s, string p)
        {
            List<int> indexes = new List<int>();
            if (string.IsNullOrEmpty(s) || s.Length < p.Length)
            {
                return indexes;
            }

            int[] dict = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                dict[p[i] - 'a'] += 1;
            }

            int start = 0;
            int end = 0;
            int neededCnt = p.Length;

            while (end < s.Length)
            {
                dict[s[end] - 'a'] -= 1;
                if (dict[s[end] - 'a'] >= 0)
                {
                    neededCnt -= 1;
                }

                if (neededCnt == 0)
                {
                    indexes.Add(start);
                }

                if (end - start + 1 == p.Length)
                {
                    if (dict[s[start] - 'a'] >= 0)
                    {
                        neededCnt += 1;
                    }

                    dict[s[start] - 'a'] += 1;
                    start++;
                }

                end++;
            }

            return indexes;
        }
    }
}