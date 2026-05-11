using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int[] solution(string[] wallpaper) 
    {
        int n = wallpaper.Length;
        int m = wallpaper[0].Length;
        
        int[] upPos = new int[2];// 가장 위에있는 놈
        int[] leftPos = new int[2];// 가장 왼쪽에있는 놈
        int[] rightPos = new int[2];// 가장 오른쪽에 있는 놈
        int[] downPos = new int[2];// 가장 아래에 있는 놈
        
        List<(int,int)> sharpPosList = new List<(int,int)>();
        for(int i=0; i<n; i++)
        {
            for(int j=0; j<m; j++)
            {
                if(wallpaper[i][j] == '#')
                {
                    sharpPosList.Add((i,j));
                }
            }
        }
        
  
        int minRow = sharpPosList.Min(x => x.Item1);
        int minCol = sharpPosList.Min(x => x.Item2);

        int maxRow = sharpPosList.Max(x => x.Item1);
        int maxCol = sharpPosList.Max(x => x.Item2);

        
        
        return new int[] {minRow,minCol,maxRow + 1,maxCol + 1};
    }
}