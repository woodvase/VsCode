using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] a = { 8, 9, 10, 2 };
            solution.QuickSort(a);
            Console.WriteLine("After sort:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            int[] testData = new int[] { 2, 7, 11, 15 };
            int[] result = solution.TwoSum(testData, 9);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }

            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(8);
            n1.next = n2;
            ListNode n3 = new ListNode(0);
            solution.AddTwoNumbers(n1, n3);
            Console.WriteLine("Hello World!");
        }
    }
}
