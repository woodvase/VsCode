namespace LeetCode
{
    public class HeapSort
    {
        private int[] array;
        public HeapSort(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                throw new System.Exception("Wrong input");
            }
            this.array = a;
        }

        public int[] Sort()
        {
            BuildHeap();
            for (int i = this.array.Length - 1; i >= 0; i--)
            {
                int tmp = array[i];
                array[i] = array[0];
                array[0] = tmp;

                Heapify(this.array, 0, i);
            }

            return this.array;
        }

        private void BuildHeap()
        {
            for (int i = this.array.Length / 2; i >= 0; i--)
            {
                Heapify(this.array, i, this.array.Length);
            }
        }
        private void Heapify(int[] array, int index, int end)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int min = index;
            if (left < end && array[left] < array[min])
            {
                min = left;
            }

            if (right < end && array[right] < array[min])
            {
                min = right;
            }

            if (min != index)
            {
                int tmp = array[index];
                array[index] = array[min];
                array[min] = tmp;
                Heapify(array, min, end);
            }
        }
    }
}