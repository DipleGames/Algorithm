using System;
using System.Collections.Generic;
using System.Linq;

public class Solution  
{ 
    public int solution(int k, int[] tangerine)  
    { 
        int max = tangerine.Max();

        int[] arr = new int[max + 1];

        foreach (int size in tangerine)
        {
            arr[size]++;
        }

        // 존재하는 귤 종류의 개수만 저장
        List<int> counts = new List<int>();

        foreach (int count in arr)
        {
            if (count > 0)
                counts.Add(count);
        }

        // 적게 존재하는 종류부터 제거하기 위해 오름차순 정렬
        counts.Sort();

        int removeCount = tangerine.Length - k;
        int typeCount = counts.Count;

        foreach (int count in counts)
        {
            // 해당 종류를 전부 제거할 수 있는 경우
            if (removeCount >= count)
            {
                removeCount -= count;
                typeCount--;
            }
            else
            {
                break;
            }
        }

        return typeCount;
    }
}