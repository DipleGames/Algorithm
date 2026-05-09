using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int m, int n, int startX, int startY, int[,] balls)
    {
        int ballCount = balls.GetLength(0);
        int[] answer = new int[ballCount];

        for (int i = 0; i < ballCount; i++)
        {
            int targetX = balls[i, 0];
            int targetY = balls[i, 1];

            int minDist = int.MaxValue;

            // 1. 위쪽 벽에 맞는 경우
            // 목표 공을 위쪽으로 대칭 이동
            if (!(startX == targetX && startY < targetY))
            {
                int mirrorX = targetX;
                int mirrorY = 2 * n - targetY;

                minDist = Math.Min(minDist, GetDistance(startX, startY, mirrorX, mirrorY));
            }

            // 2. 아래쪽 벽에 맞는 경우
            // 목표 공을 아래쪽으로 대칭 이동
            if (!(startX == targetX && startY > targetY))
            {
                int mirrorX = targetX;
                int mirrorY = -targetY;

                minDist = Math.Min(minDist, GetDistance(startX, startY, mirrorX, mirrorY));
            }

            // 3. 오른쪽 벽에 맞는 경우
            // 목표 공을 오른쪽으로 대칭 이동
            if (!(startY == targetY && startX < targetX))
            {
                int mirrorX = 2 * m - targetX;
                int mirrorY = targetY;

                minDist = Math.Min(minDist, GetDistance(startX, startY, mirrorX, mirrorY));
            }

            // 4. 왼쪽 벽에 맞는 경우
            // 목표 공을 왼쪽으로 대칭 이동
            if (!(startY == targetY && startX > targetX))
            {
                int mirrorX = -targetX;
                int mirrorY = targetY;

                minDist = Math.Min(minDist, GetDistance(startX, startY, mirrorX, mirrorY));
            }

            answer[i] = minDist;
        }

        return answer;
    }

    private int GetDistance(int x1, int y1, int x2, int y2)
    {
        int dx = x1 - x2;
        int dy = y1 - y2;

        return dx * dx + dy * dy;
    }
}