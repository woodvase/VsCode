namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public partial class CrackCode
    {
        public bool IsWithUniqueChars(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            HashSet<char> dict = new HashSet<char>();
            foreach (char c in s)
            {
                if (dict.Contains(c))
                {
                    return false;
                }
                else
                {
                    dict.Add(c);
                }
            }

            return true;
        }

        public string ReverseString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }

            char[] chars = s.ToCharArray();
            int i = 0;
            int j = chars.Length - 1;
            while (i < j)
            {
                char tmp = chars[i];
                chars[i] = chars[j];
                chars[j] = tmp;
                i++;
                j--;
            }

            return new string(chars);
        }

        public string RemoveDuplicateChars(string s)
        {
            char[] chars = s.ToCharArray();
            if (chars.Length == 1)
            {
                return s;
            }

            int tail = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                int j;
                for (j = 0; j < tail; j++)
                {
                    if (chars[j] == c)
                    {
                        break;
                    }
                }

                if (j == tail)
                {
                    chars[tail] = chars[i];
                    tail++;
                }
            }

            int k = 0;
            StringBuilder sb = new StringBuilder();
            while (k < tail)
            {
                sb.Append(chars[k++]);
            }

            return sb.ToString();
        }

        public bool AreAnagrams(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
            {
                return false;
            }

            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            Dictionary<char, int> dict2 = new Dictionary<char, int>();

            foreach (char c in str1)
            {
                if (dict1.ContainsKey(c))
                {
                    dict1[c]++;
                }
                else
                {
                    dict1.Add(c, 1);
                }
            }

            foreach (char c in str2)
            {
                if (dict2.ContainsKey(c))
                {
                    dict2[c]++;
                }
                else
                {
                    dict2.Add(c, 1);
                }
            }

            foreach (char k in dict1.Keys)
            {
                if (dict2.ContainsKey(k))
                {
                    if (dict1[k] != dict2[k])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool AreAnagrams2(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
            {
                return false;
            }

            var sortedStr1 = str1.OrderBy(c => c).ToString();
            var sortedStr2 = str2.OrderBy(c => c).ToString();
            return string.Equals(sortedStr1, sortedStr2, StringComparison.Ordinal);
        }

        public char[,] Rotate90Degrees(char[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            if (x != y)
            {
                return null;
            }

            if (x == 1)
            {
                return matrix;
            }

            char[,] newMatrix = new char[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    newMatrix[j, x - 1 - i] = matrix[i, j];
                }
            }

            return newMatrix;
        }

        public char[,] Rotate90DegreesInPlace(char[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            if (x != y)
            {
                return null;
            }

            if (x == 1)
            {
                return matrix;
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i < j)
                    {
                        char tmp = matrix[i, j];
                        matrix[i, j] = matrix[j, i];
                        matrix[j, i] = tmp;
                    }
                }
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y / 2; j++)
                {
                    char tmp = matrix[i, j];
                    matrix[i, j] = matrix[i, x - 1 - j];
                    matrix[i, x - 1 - j] = tmp;
                }
            }

            return matrix;
        }

        public char[,] Rotate90DegreesInPlaceII(char[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            if (x != y)
            {
                return null;
            }

            if (x == 1)
            {
                return matrix;
            }

            for (int layer = 0; layer < x / 2; layer++)
            {
                int first = layer;
                int last = x - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    char top = matrix[first, i];
                    matrix[first, i] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[offset, last - offset];
                    matrix[i, last] = top;
                }
            }

            return matrix;
        }

        public int[,] SetRowColTo0(int[,] matrix)
        {
            int rowCnt = matrix.GetLength(0);
            int colCnt = matrix.GetLength(1);

            int[] rows = new int[rowCnt];
            int[] cols = new int[colCnt];

            for (int i = 0; i < rowCnt; i++)
            {
                for (int j = 0; j < colCnt; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rows[i] = 1;
                        cols[j] = 1;
                    }
                }
            }

            for (int i = 0; i < rowCnt; i++)
            {
                for (int j = 0; j < colCnt; j++)
                {
                    if (rows[i] == 1 || cols[j] == 1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }
    }
}