namespace LeetCode
{
    using System;

    public partial class Solution
    {
        public Node Flatten(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node n = head;
            while (n != null)
            {
                if (n.child != null)
                {
                    if (n.next != null)
                    {
                        Node childTail = n.child;
                        while (childTail.next != null)
                        {
                            childTail = childTail.next;
                        }
                        childTail.next = n.next;
                        n.next.prev = childTail;
                    }

                    Node childHead = n.child;
                    n.next = childHead;
                    childHead.prev = n;
                    n.child = null;
                }
                n = n.next;
            }

            return head;
        }
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node() { }
        public Node(int _val, Node _prev, Node _next, Node _child)
        {
            val = _val;
            prev = _prev;
            next = _next;
            child = _child;
        }
    }
}