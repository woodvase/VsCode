namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LeetCode;

    public partial class CrackCode
    {
        public void RemoveDuplicatedNode(ListNode head)
        {
            ListNode curNode = head;
            ListNode preNode = null;
            HashSet<int> dict = new HashSet<int>();
            while (curNode != null)
            {
                if (dict.Contains(curNode.val))
                {
                    preNode.next = curNode.next;
                    curNode = curNode.next;
                }
                else
                {
                    dict.Add(curNode.val);
                    preNode = curNode;
                    curNode = curNode.next;
                }
            }
        }

        public void RemoveDuplicatedNodeWithoutBuffer(ListNode head)
        {
            if (head == null)
            {
                return;
            }

            ListNode preNode = head;
            ListNode node = head.next;

            while (node != null)
            {
                ListNode tmp = head;
                while (tmp != node)
                {
                    if (tmp.val == node.val)
                    {
                        preNode.next = node.next;
                        node = node.next;
                        break;
                    }
                    else
                    {
                        tmp = tmp.next;
                    }
                }

                // Not found
                if (tmp == node)
                {
                    preNode = node;
                    node = node.next;
                }
            }
        }

        public int FindTheNthNodeFromLast(ListNode head, int n)
        {
            int l = 0;
            ListNode node = head;
            while (node != null)
            {
                l++;
            }
            if (l < n)
            {
                throw new Exception("List is not long enough");
            }

            int i = 0;
            node = head;
            while (i != l - n)
            {
                node = node.next;
                i++;
            }

            return node.val;
        }

        public int FindTheNthNodeFromLastTwoPointers(ListNode head, int n)
        {
            ListNode pre = head;
            ListNode cur = head;
            int i = 0;
            while (i < n - 1)
            {
                cur = cur.next;
                i++;
            }

            while (cur != null)
            {
                pre = pre.next;
                cur = cur.next;
            }

            return pre.val;
        }

        public void DeleteNodeWithOnlyAccessToTheNode(ListNode node)
        {
            ListNode n = node;
            if (n != null && n.next != null)
            {
                n.val = n.next.val;
                n.next = n.next.next;
            }

            if (n.next == null)
            {
                n = null;
            }
        }

        public void HanoiTower(int n, Stack<int> peg1, Stack<int> peg2, Stack<int> peg3)
        {
            if (n == 1)
            {
                int i = peg1.Pop();
                peg3.Push(i);
            }
            else
            {
                HanoiTower(n - 1, peg1, peg3, peg2);
                HanoiTower(1, peg1, peg2, peg3);
                HanoiTower(n - 1, peg2, peg1, peg3);
            }
        }

    }
}