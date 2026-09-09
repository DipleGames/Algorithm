using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int[] topping)
    {
        HashSet<int> leftKinds = new HashSet<int>();
        Dictionary<int, int> rightCounts = new Dictionary<int, int>();

        foreach (int current in topping)
        {
            if (!rightCounts.ContainsKey(current))
            {
                rightCounts[current] = 0;
            }

            rightCounts[current]++;
        }

        int answer = 0;

        for (int i = 0; i < topping.Length - 1; i++)
        {
            int current = topping[i];

            leftKinds.Add(current);

            rightCounts[current]--;

            if (rightCounts[current] == 0)
                rightCounts.Remove(current);

            if (leftKinds.Count == rightCounts.Count)
                answer++;
        }

        return answer;
    }
}