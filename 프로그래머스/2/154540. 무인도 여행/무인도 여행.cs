using System;
using System.Collections.Generic;

public class Solution 
{
    int h = 0;
    int w = 0;
    bool[][] visited;
    int[] dx;
    int[] dy;
    public int[] solution(string[] maps) 
    {
        h = maps.Length;
        w = maps[0].Length;
        visited = new bool[h][];
        dx = new int[] {-1, 1, 0, 0};
        dy = new int[] {0, 0, -1, 1};
        
        for(int i=0; i<h; i++)
        {
            visited[i] = new bool[w];
        }
        
        List<int> result = new List<int>();

        for(int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                if(maps[i][j] == 'X' || visited[i][j])
                    continue;

                int food = DFS(maps, i, j);
                result.Add(food);
            }
        }
        
        if(result.Count == 0)
            return new int[] {-1};

        result.Sort();
        return result.ToArray();
    }
    
    int DFS(string[] maps, int y, int x)
    {
        visited[y][x] = true;
        
        int food = maps[y][x] - '0';
        
        for(int i=0; i<4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            
            if(nx < 0 || nx > w - 1)
                continue;
            
            if(ny < 0 || ny > h - 1)
                continue;
            
            if(visited[ny][nx])
                continue;

            if(maps[ny][nx] == 'X')
                continue;
            
            food += DFS(maps, ny, nx);
        }
        return food;
    }
}