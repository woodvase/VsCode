namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int level = 0;
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            int curCnt = 1;
            int nextCnt = 0;
            while (queue.Count > 0)
            {
                char[] s = queue.Dequeue().ToCharArray();
                curCnt--;
                
                for (int i = 0; i < s.Length; i++)
                {
                    for (char j = 'a'; j <= 'z'; j++)
                    {
                        if (s[i] != j)
                        {
                            s[i] = j;
                            string newS = new string(s);
                            if (newS == endWord)
                            {
                                return level + 1;
                            }
                            if (wordList.Contains(newS))
                            {
                                queue.Enqueue(newS);
                                nextCnt++;
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