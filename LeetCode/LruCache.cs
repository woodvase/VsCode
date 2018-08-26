
namespace LeetCode
{
    using System.Collections.Generic;

    public class LRUCache
    {
        private int Capacity = 0;
        private CacheNode head = null;

        private CacheNode tail = null;
        private int count = 0;

        private Dictionary<int, CacheNode> dict = new Dictionary<int, CacheNode>();
        public LRUCache(int capacity)
        {
            this.Capacity = capacity;
            
            // This trick to avoid null pointer check
            this.head = new CacheNode();
            this.head.Pre = null;
            this.tail = new CacheNode();
            this.tail.Next = null;

            this.head.Next = this.tail;
            this.tail.Pre = this.head;
        }

        public int Get(int key)
        {
            if (this.dict.ContainsKey(key))
            {
                CacheNode n = dict[key];
                n.Pre.Next = n.Next;
                n.Next.Pre = n.Pre;

                this.tail.Pre.Next = n;
                n.Pre = this.tail.Pre;
                this.tail.Pre = n;
                n.Next = this.tail;

                return n.Value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (this.dict.ContainsKey(key))
            {
                CacheNode n = this.dict[key];
                this.dict[key].Value = value;

                n.Pre.Next = n.Next;
                n.Next.Pre = n.Pre;

                this.tail.Pre.Next = n;
                n.Pre = this.tail.Pre;
                this.tail.Pre = n;
                n.Next = this.tail;
            }
            else
            {
                CacheNode newNode = new CacheNode(key, value);

                if (count < this.Capacity)
                {
                    count += 1;
                }
                else
                {
                    dict.Remove(this.head.Next.Key);
                    this.head = this.head.Next;
                    this.head.Pre = null;
                }

                this.tail.Pre.Next = newNode;
                newNode.Pre = this.tail.Pre;
                this.tail.Pre = newNode;
                newNode.Next = this.tail;

                dict.Add(key, newNode);
            }
        }

        private class CacheNode
        {
            public int Key;
            public int Value;
            public CacheNode Pre;
            public CacheNode Next;

            public CacheNode()
            {
            }
            public CacheNode(int key, int value)
            {
                this.Key = key;
                this.Value = value;
            }
        }
    }
}