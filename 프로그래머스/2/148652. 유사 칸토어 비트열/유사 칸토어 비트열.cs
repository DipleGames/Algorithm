using System;

public class Solution 
{
    public int solution(int n, long l, long r) 
    {
        int answer = 0;

        for (long i = l - 1; i <= r - 1; i++)
        {
            if (IsOne(i))
                answer++;
        }

        return answer;
    }

    private bool IsOne(long index)
    {
        while (index > 0)
        {
            if (index % 5 == 2)
                return false;

            index /= 5;
        }

        return true;
    }
}