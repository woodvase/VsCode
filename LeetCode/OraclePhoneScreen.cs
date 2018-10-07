using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public string Sumup(string str1, string str2)
        {
            Stack<char> stack = new Stack<char>();
            int l1 = str1.Length - 1;
            int l2 = str2.Length - 1;
            int flag = 0;
            while (l1 >= 0 && l2 >= 0)
            {
                int result = str1[l1] - '0' + str2[l2] - '0' + flag;
                flag = result / 10;
                result = result % 10;

                stack.Push((char)(result + '0'));
                l1--;
                l2--;
            }

            while (l1 >= 0)
            {
                int result = str1[l1] - '0' + flag;
                flag = result / 10;
                result = result % 10;
                stack.Push((char)(result + '0'));
                l1--;
            }

            while (l2 >= 0)
            {
                int result = str2[l2] - '0' + flag;
                flag = result / 10;
                result = result % 10;
                stack.Push((char)(result + '0'));
                l2--;
            }

            if (flag == 1)
            {
                stack.Push('1');
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString();
        }
    }
}