namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> ret = new List<string>();
            StringBuilder sb = new StringBuilder();
            this.Helper(0, 0, n, ret, sb);
            return ret;
        }

        private void Helper(int leftCnt, int rightCnt, int n, IList<string> lists, StringBuilder sb)
        {
            if (sb.Length == n * 2)
            {
                lists.Add(sb.ToString());
                return;
            }

            if (leftCnt < n)
            {
                sb.Append('(');
                this.Helper(leftCnt + 1, rightCnt, n, lists, sb);
                sb.Length = sb.Length - 1;
            }

            if (rightCnt < leftCnt)
            {
                sb.Append(')');
                this.Helper(leftCnt, rightCnt + 1, n, lists, sb);
                sb.Length = sb.Length - 1;
            }
        }
    }
}