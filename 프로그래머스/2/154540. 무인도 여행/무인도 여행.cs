using System;
using System.Collections.Generic;

public class Solution 
{
    int[] dx = { -1, 1, 0, 0 };
    int[] dy = { 0, 0, -1, 1 };

    bool[,] visited;

    public int[] solution(string[] maps) 
    {
        int n = maps.Length;
        int m = maps[0].Length;

        visited = new bool[n, m];

        List<int> result = new List<int>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (maps[i][j] != 'X' && !visited[i, j])
                {
                    int sum = DFS(maps, i, j, n, m);
                    result.Add(sum);
                }
            }
        }

        if (result.Count == 0)
            return new int[] { -1 };

        result.Sort();
        return result.ToArray();
    }

    int DFS(string[] maps, int x, int y, int n, int m)
    {
        visited[x, y] = true;

        int sum = maps[x][y] - '0';

        for (int k = 0; k < 4; k++)
        {
            int nx = x + dx[k];
            int ny = y + dy[k];

            if (nx < 0 || ny < 0 || nx >= n || ny >= m)
                continue;

            if (maps[nx][ny] == 'X')
                continue;

            if (visited[nx, ny])
                continue;

            sum += DFS(maps, nx, ny, n, m);
        }

        return sum;
    }
}