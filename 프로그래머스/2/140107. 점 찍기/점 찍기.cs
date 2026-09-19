using System;

public class Solution 
{
    public long solution(int k, int d) 
    {
        long count = 0;
        long distanceSquare = (long)d * d;

        for (long x = 0; x <= d; x += k)
        {
            long maxY = (long)Math.Sqrt(distanceSquare - x * x);

            // 0, k, 2k, ... maxY
            count += maxY / k + 1;
        }

        return count;
    }
}