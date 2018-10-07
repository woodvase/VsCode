namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode tmp = headA;
            int lenA = this.GetListLength(headA);
            int lenB = this.GetListLength(headB);
           
            int headStart = 0;
            ListNode tmp1;
            if (lenA > lenB)
            {
                tmp = headA;
                tmp1 = headB;
                headStart = lenA - lenB;
            }
            else
            {
                tmp = headB;
                tmp1 = headA;
                headStart = lenB - lenA;
            }

            while (headStart > 0)
            {
                tmp = tmp.next;
                headStart--;
            }

            while (tmp != null && tmp.val != tmp1.val)
            {
                tmp = tmp.next;
                tmp1 = tmp1.next;
            }

            return tmp;
        }

        private int GetListLength(ListNode ln)
        {
            int ret = 0;
            ListNode tmp = ln;
            while (tmp != null)
            {
                ret++;
                tmp = tmp.next;
            }

            return ret;
        }
    }
}