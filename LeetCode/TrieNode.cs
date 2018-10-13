namespace LeetCode
{
    using System;
    public class TrieNode
    {
        const int count = 26;
        private TrieNode[] children;

        private Boolean isEnd;
        public TrieNode()
        {
            this.isEnd = false;
            this.children = new TrieNode[count];
        }

        public bool ContainsKey(char c)
        {
            return children[c - 'a'] != null;
        }

        public TrieNode Get(char c)
        {
            return children[c - 'a'];
        }

        public void Put(char c, TrieNode node)
        {
            children[c - 'a'] = node;
        }

        public bool IsEnd()
        {
            return this.isEnd;
        }

        public void SetEnd()
        {
            this.isEnd = true;
        }
    }
}