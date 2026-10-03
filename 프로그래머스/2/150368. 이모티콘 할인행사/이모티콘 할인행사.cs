using System;

public class Solution 
{
    int[] discounts = { 10, 20, 30, 40 };
    int[] selected;

    int maxPlus = 0;
    int maxSales = 0;

    public int[] solution(int[,] users, int[] emoticons) 
    {
        selected = new int[emoticons.Length];

        DFS(users, emoticons, 0);

        return new int[] { maxPlus, maxSales };
    }

    void DFS(int[,] users, int[] emoticons, int depth)
    {
        // 모든 이모티콘의 할인율을 결정했다면
        if(depth == emoticons.Length)
        {
            int plusCount = 0;
            int sales = 0;

            // 모든 사용자 확인
            for(int i = 0; i < users.GetLength(0); i++)
            {
                int userDiscount = users[i, 0];
                int userLimit = users[i, 1];

                int sum = 0;

                // 사용자가 구매할 이모티콘 확인
                for(int j = 0; j < emoticons.Length; j++)
                {
                    // 사용자가 원하는 할인율 이상이면 구매
                    if(selected[j] >= userDiscount)
                    {
                        sum += emoticons[j] * (100 - selected[j]) / 100;
                    }
                }

                // 기준 금액 이상 구매하게 된다면 플러스 가입
                if(sum >= userLimit)
                {
                    plusCount++;
                }
                else
                {
                    sales += sum;
                }
            }

            // 1순위 : 플러스 가입자 수
            if(plusCount > maxPlus)
            {
                maxPlus = plusCount;
                maxSales = sales;
            }
            // 2순위 : 판매액
            else if(plusCount == maxPlus && sales > maxSales)
            {
                maxSales = sales;
            }

            return;
        }

        // 현재 이모티콘의 할인율을 10, 20, 30, 40으로 설정
        for(int i = 0; i < discounts.Length; i++)
        {
            selected[depth] = discounts[i];

            DFS(users, emoticons, depth + 1);
        }
    }
}