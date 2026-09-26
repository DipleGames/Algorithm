using System;

public class Solution
{
    public int solution(int storey)
    {
        char[] charNums = storey.ToString().ToCharArray();
        int[] nums = new int[charNums.Length + 1]; // 맨 앞에 올림용 0 추가

        for (int i = 0; i < charNums.Length; i++)
            nums[i + 1] = charNums[i] - '0';

        int count = 0;

        for (int i = nums.Length - 1; i > 0; i--)
        {
            int n = nums[i];

            if (n < 5 || (n == 5 && nums[i - 1] < 5))
            {
                count += n; // 아래로 내려서 현재 자리를 0으로
            }
            else
            {
                count += 10 - n; // 위로 올려서 현재 자리를 0으로
                nums[i - 1]++;   // 올림은 다음 반복에서 처리
            }
        }

        return count + nums[0];
    }
}