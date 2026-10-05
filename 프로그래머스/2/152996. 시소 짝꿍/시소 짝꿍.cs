using System;
using System.Collections.Generic;

public class Solution 
{
    public long solution(int[] weights) 
    {
        long answer = 0;

        // 중요: 작은 몸무게부터 처리
        Array.Sort(weights);

        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach (int w in weights)
        {
            // 1 : 1
            if (dict.ContainsKey(w))
                answer += dict[w];

            // 2 : 3
            if (w % 3 == 0)
            {
                int target = w * 2 / 3;

                if (dict.ContainsKey(target))
                    answer += dict[target];
            }

            // 1 : 2
            if (w % 2 == 0)
            {
                int target = w / 2;

                if (dict.ContainsKey(target))
                    answer += dict[target];
            }

            // 3 : 4
            if (w % 4 == 0)
            {
                int target = w * 3 / 4;

                if (dict.ContainsKey(target))
                    answer += dict[target];
            }

            // 현재 몸무게 등록
            if (!dict.ContainsKey(w))
                dict[w] = 0;

            dict[w]++;
        }

        return answer;
    }
}