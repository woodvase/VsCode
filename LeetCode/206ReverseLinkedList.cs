namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode reversedHead = new ListNode(-1);
            ListNode cur = head;
            while (cur != null)
            {
                ListNode next = cur.next;
                cur.next = reversedHead.next;
                reversedHead.next = cur;
                cur = next;
            }

            return reversedHead.next;
        }

        public ListNode ReverseListRecursive(ListNode head)
        {
            if (head.next == null)
            {
                return head;
            }
            else
            {
                ListNode reversed = this.ReverseListRecursive(head.next);
                ListNode ln = reversed;
                while (ln.next != null)
                {
                    ln = ln.next;
                }

                head.next = ln.next;
                ln.next = head;
                return reversed;
            }
        }

        public int kthSmallest(int[][] matrix, int k)
        {
            int lo = matrix[0][0];
            int hi = matrix[matrix.Length - 1][matrix[0].Length - 1] + 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int count = 0, j = matrix[0].Length - 1;
                for (int i = 0; i < matrix.Length; i++)
                {
                    while (j >= 0 && matrix[i][j] > mid)
                    {
                        j--;
                    }
                    count += (j + 1);
                }
                if (count < k)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;
                }
            }

            return lo;
        }
    }
}