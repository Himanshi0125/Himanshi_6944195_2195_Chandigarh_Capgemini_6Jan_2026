using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        Queue<int> q = new Queue<int>();
        bool[] visited = new bool[100001]; // to avoid repeating numbers

        q.Enqueue(10);
        visited[10] = true;

        int steps = 0;

        while (q.Count > 0)
        {
            int size = q.Count;

            for (int i = 0; i < size; i++)
            {
                int curr = q.Dequeue();

                if (curr == N)
                {
                    Console.WriteLine(steps);
                    return;
                }

                int a = curr + 2;
                int b = curr - 1;
                int c = curr * 3;

                if (a >= 0 && a <= 100000 && !visited[a])
                {
                    visited[a] = true;
                    q.Enqueue(a);
                }

                if (b >= 0 && b <= 100000 && !visited[b])
                {
                    visited[b] = true;
                    q.Enqueue(b);
                }

                if (c >= 0 && c <= 100000 && !visited[c])
                {
                    visited[c] = true;
                    q.Enqueue(c);
                }
            }

            steps++; // one operation level completed
        }
    }
}
