using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int solution(int[,] data, int col, int row_begin, int row_end) 
    {
        int rowCount = data.GetLength(0);
        int colCount = data.GetLength(1);
        List<int[]> rows = new List<int[]>();
        
        for(int r=0; r<rowCount; r++)
        {
            int[] row = new int[colCount];
            for(int c=0; c<colCount; c++)
            {
                row[c] = data[r,c];
            }
            rows.Add(row);
        }
        
        rows = rows.OrderBy(x => x[col - 1])
                   .ThenByDescending(x => x[0])
                   .ToList();
        
        int answer = 0;

        for (int i = row_begin; i <= row_end; i++)
        {
            int sum = 0;

            foreach (int value in rows[i - 1])
            {
                sum += value % i;
            }

            answer ^= sum;
        }

        return answer;
    }
}