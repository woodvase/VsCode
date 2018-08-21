namespace DynamicPrograming
{
    using System;
    using System.Collections.Generic;
    public class DynamicprogrammingQuestions
    {
        public static bool WordBreakRecursive(HashSet<string> dictionary, string inputStr)
        {
            if (inputStr.Length == 0)
            {
                return true;
            }

            for (int i = 1; i < inputStr.Length + 1; i++)
            {
                string prefix = inputStr.Substring(0, i);
                if (dictionary.Contains(prefix) && WordBreakRecursive(dictionary, inputStr.Substring(i, inputStr.Length - i)))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool WordBreak(HashSet<string> dictionary, string inputStr)
        {
            bool[] cache = new bool[inputStr.Length + 1];

            for (int i = 1; i <= inputStr.Length; i++)
            {
                string prefix = inputStr.Substring(0, i);
                if (cache[i] == false && dictionary.Contains(prefix))
                {
                    cache[i] = true;
                }

                if (cache[i])
                {
                    if (i == inputStr.Length)
                    {
                        return true;
                    }
                    for (int j = i + 1; j <= inputStr.Length; j++)
                    {
                        string suffix = inputStr.Substring(i, j - i);
                        if (!cache[j] && dictionary.Contains(suffix))
                        {
                            cache[j] = true;
                        }

                        if (j == inputStr.Length && cache[j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static int CutRodRecursive(int[] prices, int rodLength)
        {
            if (rodLength == 0)
            {
                return 0;
            }

            int ret = 0;
            for (int i = 0; i < rodLength; i++)
            {
                ret = Math.Max(ret, prices[i] + CutRodRecursive(prices, rodLength - (i + 1)));
            }

            return ret;
        }

        public static int CutRod(int[] prices, int rodLength)
        {
            int ret = 0;
            List<int> val = new List<int>();
            val.Add(0);
            for (int i = 1; i <= rodLength; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    ret = Math.Max(ret, prices[j] + val[i - j - 1]);
                }
                val.Add(ret);
            }
            return ret;
        }

        public static int Knapsack(int[] value, int[] weight, int capacity)
        {
            throw new NotImplementedException();
        }

        public static int MinJumpsToEnd(int[] jumps)
        {
            if (jumps.Length == 0 || jumps[0] == 0)
            {
                return Int32.MaxValue;
            }

            int[] minJumps = new int[jumps.Length];

            for (int j = 1; j < jumps.Length; j++)
            {
                int jump = Int32.MaxValue;
                for (int k = 0; k < j; k++)
                {
                    if (jumps[k] >= j - k && minJumps[k] != Int32.MaxValue)
                    {
                        jump = Math.Min(jump, minJumps[k] + 1);

                        // Because jumps[k + 1] >= jumps[k]
                        // Say jumps[k] is the minimium value to reach k.
                        // If jumps[k + 1] < jumps[k], then k is reachable with jumps[k +1]. jumps[k] is not the minimium value, conflict! 
                        break;
                    }
                }

                minJumps[j] = jump;
            }

            return minJumps[jumps.Length - 1];
        }
    }
}