namespace LeetCode
{
    using System.Collections.Generic;
    public partial class Solution
    {
        public int SumUpInString(string str)
        {
            Stack<int> s = new Stack<int>();
            Stack<char> o = new Stack<char>();

            int start = -1;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] >= '0' && str[j] <= '9')
                {
                    if (start == -1)
                    {
                        start = j;
                    }
                }

                if (str[j] == '+' || str[j] == '-')
                {
                    string tmp = str.Substring(start, j - start);
                    int num = int.Parse(tmp);
                    s.Push(num);
                    o.Push(str[j]);
                    start = -1;
                }
            }

            if (start > 0)
            {
                s.Push(int.Parse(str.Substring(start, str.Length - start)));
            }

            while (o.Count > 0 && s.Count > 0)
            {
                char c = o.Pop();
                int n1 = s.Pop();
                int n2 = s.Pop();
                if (c == '+')
                {
                    s.Push(n2 + n1);
                }
                else
                {
                    s.Push(n2 - n1);
                }
            }

            return s.Pop();
        }
    }
}
