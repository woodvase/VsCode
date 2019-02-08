namespace LeetCode
{
    using System;
    public class DisjointSet
    {
        int[] Rank;
        
        // Parent[i] represents the set;
        int[] Parent;
        
        // The set element is from 0 - (TotalCount -1);
        int TotalCount;

        public DisjointSet(int n)
        {
            this.Rank = new int[n];
            this.Parent = new int[n];
            this.TotalCount = n;

            for (int i = 0; i < n; i++)
            {
               this.Parent[i] = -1;
            }
        }

        public int Find(int n)
        {
            if (this.Parent[n] == -1)
            {
                return n;
            }

            return this.Find(this.Parent[n]);
        }

        public void Union(int a, int b)
        {
            int pa = this.Find(a);
            int pb = this.Find(b);
            if (pa == pb)
            {
                return;
            }

            if (this.Rank[pa] > this.Rank[pb])
            {
                this.Parent[pb] = pa;
            }
            else if (this.Rank[pb] > this.Rank[pa])
            {
                this.Parent[pa] = pb;
            }
            else
            {
                this.Parent[b] = pa;
                this.Rank[pa] += 1;
            }

            this.TotalCount--;
        }
    }
}