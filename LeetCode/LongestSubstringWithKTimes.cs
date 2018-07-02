namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/description/
        public int LongestSubstringV1(string s, int k)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            if (s.Length < k)
            {
                return 0;
            }

            int l = 0;

            for (int i = 0; i < s.Length - l; i++)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();

                for (int j = i; j < s.Length; j++)
                {
                    if (dict.ContainsKey(s[j]))
                    {
                        dict[s[j]] += 1;
                    }
                    else
                    {
                        dict.Add(s[j], 1);
                    }

                    if (dict[s[j]] >= k)
                    {
                        bool allBigK = true;
                        foreach (char m in dict.Keys)
                        {
                            if (dict[m] < k)
                            {
                                allBigK = false;
                                break;
                            }
                        }
                        if (allBigK)
                        {
                            l = Math.Max(l, j - i + 1);
                        }
                    }
                }
            }

            return l;
        }

        public int LongestSubstringV2(string s, int k)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            if (s.Length < k)
            {
                return 0;
            }

            int l = 0;

            for (int i = 0; i < s.Length - l; i++)
            {
                int[] count = new int[26];
                int flag = 0;
                for (int j = i; j < s.Length; j++)
                {
                    int t = s[j] - 'a';
                    count[t]++;
                    if (count[t] < k)
                    {
                        flag |= (1 << t);
                    }
                    else
                    {
                        flag &= (~(1 << t));
                    }

                    if (flag == 0)
                    {
                        l = Math.Max(l, j - i + 1);
                    }
                }
            }

            return l;
        }
    }
}