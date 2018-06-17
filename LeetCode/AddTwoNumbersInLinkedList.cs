namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/add-two-numbers/description/
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;

            ListNode l1n = l1;
            ListNode l2n = l2;

            if (l1n == null)
            {
                return l2n;
            }

            if (l2n == null)
            {
                return l1n;
            }

            int carryBit = 0;
            ListNode preNode = null;
            while (l1n != null && l2n != null)
            {
                int val = l1n.val + l2n.val + carryBit;
                carryBit = val / 10;
                ListNode n = new ListNode(val % 10);

                if (preNode == null)
                {
                    preNode = n;
                    head = preNode;
                }
                else
                {
                    preNode.next = n;
                    preNode = preNode.next;
                }

                l1n = l1n.next;
                l2n = l2n.next;
            }

            while (l1n != null)
            {
                int val = l1n.val + carryBit;
                carryBit = val / 10;
                preNode.next = new ListNode(val % 10);
                preNode = preNode.next;
                l1n = l1n.next;
            }

            while (l2n != null)
            {
                int val = l2n.val + carryBit;
                carryBit = val / 10;
                preNode.next = new ListNode(val % 10);
                preNode = preNode.next;
                l2n = l2n.next;
            }

            if (carryBit > 0)
            {
                preNode.next = new ListNode(carryBit);
            }

            return head;
        }
    }
}