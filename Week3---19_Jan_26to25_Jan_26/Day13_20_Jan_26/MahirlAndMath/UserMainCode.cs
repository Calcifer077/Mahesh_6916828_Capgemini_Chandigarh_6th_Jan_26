using System;
using System.Collections.Generic;
using System.Text;

namespace MahirlAndMath
{
    internal class UserMainCode
    {
        public int helper(int n, int curr)
        {
            if (n == curr) return 0;

        // Queue stores an array: [current_value, steps_taken]
        Queue<int[]> queue = new Queue<int[]>();
        // HashSet to track visited nodes to avoid cycles
        HashSet<int> visited = new HashSet<int>();

        queue.Enqueue(new int[] { curr, 0 });
        visited.Add(curr);

        while (queue.Count > 0)
        {
            int[] current = queue.Dequeue();
            int val = current[0];
            int dist = current[1];

            
            int[] nextMoves = { val * 3, val + 2, val - 1 };

            foreach (int next in nextMoves)
            {
                if (next == n) return dist + 1;

                if (!visited.Contains(next) && next > -1000 && next < n + 1000)
                {
                    visited.Add(next);
                    queue.Enqueue(new int[] { next, dist + 1 });
                }
            }
        }
        return -1;
        }

        public static void solve(int n) {
            UserMainCode obj = new UserMainCode();

            Console.WriteLine(obj.helper(n, 10));
        }
    }
}
