namespace LeetCode
{
    public partial class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (p.Length == 0)
            {
                return s.Length == 0;
            }

            if (p.Length == 1)
            {
                return (s.Length == 1 && (p[0] == s[0] || p[0] == '.'));
            }

            int sl = s.Length;
            int pl = p.Length;

            if (p[1] != '*')
            {
                if (sl > 0 && (s[0] == p[0] || p[0] == '.'))
                {
                    return IsMatch(s.Substring(1, sl - 1), p.Substring(1, pl - 1));
                }

                return false;
            }
            else
            {
                if (IsMatch(s, p.Substring(2, pl - 2)))
                {
                    return true;
                }

                if (sl > 0 && (s[0] == p[0] || p[0] == '.'))
                {
                    return IsMatch(s.Substring(1, sl - 1), p);
                }

                return false;
            }
        }
    }
}