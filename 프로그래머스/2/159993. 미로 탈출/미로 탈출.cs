using System;
using System.Collections.Generic;

public class Solution
{
    int[] dx = { 1, -1, 0, 0 };
    int[] dy = { 0, 0, 1, -1 };

    public int solution(string[] maps)
    {
        int n = maps.Length;
        int m = maps[0].Length;

        int sx = 0, sy = 0;
        int lx = 0, ly = 0;
        int ex = 0, ey = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (maps[i][j] == 'S')
                {
                    sx = i;
                    sy = j;
                }
                else if (maps[i][j] == 'L')
                {
                    lx = i;
                    ly = j;
                }
                else if (maps[i][j] == 'E')
                {
                    ex = i;
                    ey = j;
                }
            }
        }

        int startToLever = BFS(maps, sx, sy, lx, ly);
        if (startToLever == -1) return -1;

        int leverToExit = BFS(maps, lx, ly, ex, ey);
        if (leverToExit == -1) return -1;

        return startToLever + leverToExit;
    }

    private int BFS(string[] maps, int startX, int startY, int targetX, int targetY)
    {
        int n = maps.Length;
        int m = maps[0].Length;

        bool[,] visited = new bool[n, m];

        Queue<(int x, int y, int dist)> queue = new Queue<(int, int, int)>();

        queue.Enqueue((startX, startY, 0));
        visited[startX, startY] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            int x = current.x;
            int y = current.y;
            int dist = current.dist;

            if (x == targetX && y == targetY)
                return dist;

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx < 0 || ny < 0 || nx >= n || ny >= m)
                    continue;

                if (visited[nx, ny])
                    continue;

                if (maps[nx][ny] == 'X')
                    continue;

                visited[nx, ny] = true;
                queue.Enqueue((nx, ny, dist + 1));
            }
        }

        return -1;
    }
}