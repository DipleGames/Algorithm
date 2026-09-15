using System;
using System.Collections.Generic;

public class Solution 
{
    public double[] solution(int k, int[,] ranges) 
    {
        List<double> graph = new List<double>();
        double y = (double)k;
        graph.Add(y);
        
        while(y != 1)
        {
            if(y % 2 == 0)
            {
                y /= 2;
            }
            else
            {
                y *= 3;
                y += 1;
            }
            graph.Add(y);
        }

        int n = graph.Count - 1;
        List<double> areaList = new List<double>();
        for(int i=0; i<ranges.GetLength(0); i++)
        {
            int a = ranges[i,0];
            int b = n + ranges[i,1];
            
            double area = 0;
            if(a > b)
            {
                area = - 1;
            }
            else
            {
                for(int x=a; x<b; x++)
                {
                    double area1 = (graph[x] + graph[x + 1]) / 2;
                    area += area1;
                }
            }
            areaList.Add(area);
        }
        return areaList.ToArray();
    }
    
}