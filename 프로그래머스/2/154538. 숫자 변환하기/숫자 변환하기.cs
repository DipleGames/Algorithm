using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int x, int y, int n) 
    {
        return BFS(x, y, n);
    }
    
    int BFS(int x, int y, int n)
    {
        Queue<int> q = new Queue<int>();
        int[] visited = new int[y + 1];
        
        Array.Fill(visited, -1);
        
        q.Enqueue(x);
        visited[x] = 0;
        
        while(q.Count > 0)
        {
            int tmp = q.Dequeue();
            
            if (tmp == y)
                return visited[tmp];
            
            for(int i=0; i<3; i++)
            {
                int next = tmp;
                
                if(i == 0)
                {
                    next += n;
                }
                
                if(i == 1)
                {
                    next *= 2;
                }
                
                if(i == 2)
                {
                    next *= 3;
                }
                
                if(next > y)
                    continue;
                
                if(visited[next] != -1)
                    continue;
                
                visited[next] = visited[tmp] + 1;
                q.Enqueue(next);
            }
        }
        return -1;
    }
}