using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int n, int k, int[] enemy)
    {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        for (int i = 0; i < enemy.Length; i++)
        {
            pq.Enqueue(enemy[i], enemy[i]);

            // 무적권 횟수를 초과하면
            // 지금까지의 라운드 중 가장 적은 적을 병사로 처리
            if (pq.Count > k)
            {
                n -= pq.Dequeue();
            }

            // 현재 라운드를 막지 못함
            if (n < 0)
            {
                return i;
            }
        }

        return enemy.Length;
    }
}