using System;

public class Solution 
{
    public int solution(int[] arrayA, int[] arrayB) 
    {
        int result = 0;
        if(ArrayGCD(arrayA) != 0)
        {
            int a1 = ArrayGCD(arrayA);
            int idx = 0;
            bool check = false;
            while(idx < arrayB.Length)
            {
                if(arrayB[idx] % a1 == 0)
                {
                    check = true;
                    break;
                }
                idx++;
            }
            
            if(!check)
            {
                result = a1;
            }
        }
        
        if(ArrayGCD(arrayB) != 0)
        {
            int a2 = ArrayGCD(arrayB);
            int idx = 0;
            bool check = false;
            while(idx < arrayA.Length)
            {
                if(arrayA[idx] % a2 == 0)
                {
                    check = true;
                    break;
                }
                idx++;
            }
            
            if(!check)
            {
                if(result < a2)
                {
                    result = a2;
                }
            }
        }
        return result;
    }
    
    int GCD(int a, int b)
    {
        if(b == 0)
        {
            return a; 
        }
        return GCD(b, a % b);
    }
    
    int ArrayGCD(int[] numbers)
    {
        int gcd = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            gcd = GCD(gcd, numbers[i]);

            if (gcd == 1) // 최대공약수가 1이면 더 계산해도 바뀌지 않음
                return 0;
        }

        return gcd;
    }
}