using System.Collections.Generic;

public class Solution
{
    public double[] solution(int k, int[,] ranges)
    {
        List<double> prefix = new List<double> { 0 };
        long current = k;

        // 우박수열을 만들면서 넓이의 누적 합 저장
        while (current != 1)
        {
            long next = current % 2 == 0 ? current / 2 : current * 3 + 1;
            double area = (current + next) / 2.0;

            prefix.Add(prefix[prefix.Count - 1] + area);
            current = next;
        }

        int n = prefix.Count - 1;
        double[] answer = new double[ranges.GetLength(0)];

        for (int i = 0; i < answer.Length; i++)
        {
            int start = ranges[i, 0];
            int end = n + ranges[i, 1];

            if (start > end)
            {
                answer[i] = -1;
            }
            else
            {
                answer[i] = prefix[end] - prefix[start];
            }
        }

        return answer;
    }
}