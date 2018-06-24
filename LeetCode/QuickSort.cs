namespace LeetCode
{
    public partial class Solution
    {
        public void QuickSort(int[] a)
        {
            this.Sort(a, 0, a.Length - 1);
        }

        private void Sort(int[] a, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int i = this.Partition(a, start, end);
            this.Sort(a, start, i - 1);
            this.Sort(a, i + 1, end);
        }
        private int Partition(int[] a, int start, int end)
        {
            int pivot = a[start];
            int i = start, j = end;

            while (i <= j)
            {
                while (i <= end && a[i] <= pivot)
                {
                    i++;
                }
                while (j >= start && a[j] > pivot)
                {
                    j--;
                }

                if (i < j)
                {
                    int tmp = a[i];
                    a[i++] = a[j];
                    a[j--] = tmp;
                }
            }

            // j is the position where a[j] <= pivot
            a[start] = a[j];
            a[j] = pivot;
            return j;
        }
    }
}