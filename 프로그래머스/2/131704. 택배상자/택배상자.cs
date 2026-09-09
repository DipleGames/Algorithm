using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int[] order)
    {
        Stack<int> sub = new Stack<int>();
        int count = 0;

        for (int box = 1; box <= order.Length; box++)
        {
            sub.Push(box);

            while (sub.Count > 0 && count < order.Length && sub.Peek() == order[count])
            {
                sub.Pop();
                count++;
            }
        }

        return count;
    }
}