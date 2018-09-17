namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        // https://leetcode.com/submissions/detail/175252776/
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int level = 1;
            HashSet<string> dict = new HashSet<string>(wordList);
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            int curCnt = 1;
            int nextCnt = 0;
            HashSet<string> visited = new HashSet<string>();
            
            while (queue.Count > 0)
            {
                string s = queue.Dequeue();
                curCnt--;

                for (int i = 0; i < s.Length; i++)
                {
                    for (char j = 'a'; j <= 'z'; j++)
                    {
                        char[] a = s.ToCharArray();
                        if (s[i] != j)
                        {
                            a[i] = j;
                            string newStr = new string(a);

                            if (dict.Contains(newStr))
                            {
                                if (newStr == endWord)
                                {
                                    return level + 1;
                                }
                                if (!visited.Contains(newStr))
                                {
                                    visited.Add(newStr);
                                    queue.Enqueue(newStr);
                                    nextCnt++;
                                }
                            }
                        }
                    }
                }

                if (curCnt == 0)
                {
                    curCnt = nextCnt;
                    nextCnt = 0;
                    level++;
                }
            }

            return 0;
        }
    }
}