namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> ret = new List<string>();
            this.GenerateParenthesisHelper(ret, "", 0, 0, n);
            return ret;
        }

        private void GenerateParenthesisHelper(List<string> strs, string str, int open, int close, int n)
        {
            if (str.Length == n * 2)
            {
                strs.Add(str);
                Console.WriteLine(str);
                return;
            }

            if (open < n)
            {
                this.GenerateParenthesisHelper(strs, str + '(', open + 1, close, n);
            }

            if (close < open)
            {
                this.GenerateParenthesisHelper(strs, str + ')', open, close + 1, n);
            }
        }
    }
}