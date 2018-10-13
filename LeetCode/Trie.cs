namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public class Trie
    {
        private TrieNode root;
        public Trie()
        {
            this.root = new TrieNode();
        }

        public void Insert(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }

            TrieNode n = this.root;
            foreach (char c in word)
            {
                if (!n.ContainsKey(c))
                {
                    TrieNode newNode = new TrieNode();
                    n.Put(c, newNode);
                }
                n = n.Get(c);
            }

            n.SetEnd();
        }

        public bool Search(string word)
        {
            TrieNode n = this.root;
            foreach (char c in word)
            {
                if (!n.ContainsKey(c))
                {
                    return false;
                }
                n = n.Get(c);
            }

            return n.IsEnd();
        }

        public bool EndsWith(string suffix)
        {
            throw new NotImplementedException();
        }
        public bool StartsWith(string prefix)
        {
            TrieNode n = this.root;
            foreach (char c in prefix)
            {
                if (!n.ContainsKey(c))
                {
                    return false;
                }
                n = n.Get(c);
            }

            return true;
        }
    }
}