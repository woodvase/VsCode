namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        // https://leetcode.com/problems/shortest-distance-to-a-character/description/
        public int[] ShortestToChar(string S, char C)
        {
            int prePosition;
            int currentPostion;
            List<int> pos = new List<int>();
            List<int> ret = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == C)
                {
                    pos.Add(i);
                }
            }

            int j = 0;
            prePosition = pos[j];
            j += 1;
            if (j < pos.Count)
            {
                currentPostion = pos[j];
            }
            else
            {
                currentPostion = prePosition;
            }

            for (int i = 0; i < pos[pos.Count - 1]; i++)
            {
                if (i <= prePosition)
                {
                    ret.Add(prePosition - i);
                }

                if (i > prePosition && i < currentPostion)
                {
                    ret.Add(Math.Min(i - prePosition, currentPostion - i));
                }

                if (i == currentPostion)
                {
                    ret.Add(0);
                    prePosition = currentPostion;
                    j += 1;
                    if (j < pos.Count)
                    {
                        currentPostion = pos[j];
                    }
                }
            }

            for (int i = pos[pos.Count - 1]; i < S.Length; i++)
            {
                ret.Add(i - currentPostion);
            }

            return ret.ToArray();
        }
    }
}