using System.Collections.Generic;

namespace LeetCode
{
    public partial class Solution
    {
        public void WallsAndGates(int[,] rooms)
        {
            if (rooms == null)
            {
                return;
            }

            int row = rooms.GetLength(0);
            int col = rooms.GetLength(1);
            Queue<Node1> q = new Queue<Node1>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (rooms[i, j] == 0)
                    {
                        q.Enqueue(new Node1(i, j, rooms[i, j]));
                    }
                }
            }

            while (q.Count > 0)
            {
                Node1 n = q.Dequeue();
                rooms[n.r, n.c] = n.distance;
                if (n.r > 0 && rooms[n.r - 1, n.c] == int.MaxValue)
                {
                    q.Enqueue(new Node1(n.r - 1, n.c, n.distance + 1));
                }
                if (n.r + 1 < row && rooms[n.r + 1, n.c] == int.MaxValue)
                {
                    q.Enqueue(new Node1(n.r + 1, n.c, n.distance + 1));
                }

                if (n.c > 0 && rooms[n.r, n.c - 1] == int.MaxValue)
                {
                    q.Enqueue(new Node1(n.r, n.c - 1, n.distance + 1));
                }

                if (n.c + 1 < col && rooms[n.r, n.c + 1] == int.MaxValue)
                {
                    q.Enqueue(new Node1(n.r, n.c + 1, n.distance + 1));
                }
            }
        }

        public class Node1
        {
            public int r;
            public int c;
            public int distance;

            public Node1(int r, int c, int d)
            {
                this.r = r;
                this.c = c;
                this.distance = d;
            }
        }
    }
}