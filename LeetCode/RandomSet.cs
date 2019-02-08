namespace LeetCode
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RandomizedSet
    {
        private Dictionary<int, int> dict = null;
        private List<int> intArray;
        Random r = new Random();

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            this.dict = new Dictionary<int, int>();
            this.intArray = new List<int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (dict.ContainsKey(val))
            {
                return false;
            }

            intArray.Add(val);
            dict.Add(val, intArray.Count - 1);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val))
            {
                return false;
            }

            int tmp = dict[val];
            intArray[tmp] = intArray[intArray.Count - 1];
            dict[intArray[tmp]] = tmp;
            intArray.RemoveAt(intArray.Count - 1);
            dict.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            int i = r.Next(this.intArray.Count);
            return intArray[i];
        }
    }
}
