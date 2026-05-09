using System;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(int[] numbers) 
    {
        int n = numbers.Length;
        int[] answer = new int[n];

        // 기본값을 -1로 초기화
        for (int i = 0; i < n; i++)
        {
            answer[i] = -1;
        }

        // 아직 뒤에 큰 수를 못 찾은 인덱스 저장
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            // 현재 숫자가 stack 맨 위 인덱스의 숫자보다 크면
            // 그 인덱스의 "뒤에 있는 큰 수"는 현재 숫자
            while (stack.Count > 0 && numbers[stack.Peek()] < numbers[i])
            {
                int index = stack.Pop();
                answer[index] = numbers[i];
            }

            // 현재 인덱스도 아직 뒤에 큰 수를 못 찾았으니 stack에 저장
            stack.Push(i);
        }

        return answer;
    }
}