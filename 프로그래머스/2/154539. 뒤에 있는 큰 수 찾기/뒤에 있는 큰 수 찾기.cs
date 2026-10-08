using System;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(int[] numbers) 
    {
        int[] result = new int[numbers.Length];
        Array.Fill(result, -1);
        Stack<int> s = new Stack<int>();
        s.Push(0);
        for(int i=0; i<numbers.Length; i++)
        {
            int num = numbers[i];
            
            while(s.Count > 0 && num > numbers[s.Peek()])
            {
                int idx = s.Pop();
                result[idx] = num;
            }
            s.Push(i);
        }
        return result;
    }
}