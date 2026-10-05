using System;
using System.Collections.Generic;

public class Solution 
{
    // 트럭 하나로 모든 배달과 수거를 마치고 물류창고까지 돌아올 수 있는 최소 이동 거리를 구하려 합니다. 
    // 각 집에 배달 및 수거할 때, 원하는 개수만큼 택배를 배달 및 수거할 수 있습니다.
    public long solution(int cap, int n, int[] deliveries, int[] pickups)
    {
        long answer = 0;

        int d = n - 1; // 가장 먼 배달 위치
        int p = n - 1; // 가장 먼 수거 위치

        while (d >= 0 || p >= 0)
        {
            // 뒤에서부터 이미 처리된 집 건너뛰기
            while (d >= 0 && deliveries[d] == 0)
                d--;

            while (p >= 0 && pickups[p] == 0)
                p--;

            if (d < 0 && p < 0)
                break;

            int far = Math.Max(d, p);

            answer += (long)(far + 1) * 2;

            // 배달 cap만큼 처리
            int box = cap;

            while (d >= 0 && box > 0)
            {
                if (deliveries[d] <= box)
                {
                    box -= deliveries[d];
                    deliveries[d] = 0;
                    d--;
                }
                else
                {
                    deliveries[d] -= box;
                    box = 0;
                }
            }

            // 수거 cap만큼 처리
            // 수거 cap만큼 처리
            box = cap;

            while (p >= 0 && box > 0)
            {
                if (pickups[p] <= box)
                {
                    box -= pickups[p];
                    pickups[p] = 0;
                    p--;
                }
                else
                {
                    pickups[p] -= box;
                    box = 0;
                }
            }
            
        }
        return answer;
    }  
}