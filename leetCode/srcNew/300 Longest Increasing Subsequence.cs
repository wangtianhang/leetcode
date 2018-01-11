using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class _300_Longest_Increasing_Subsequence
{
    public static void Test()
    {
        _300_Longest_Increasing_Subsequence test = new _300_Longest_Increasing_Subsequence();
        //int[] array = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
        //int[] array = new int[] { 1, 2 };
        int[] array = new int[] { 1,3,6,7,9,4,10,5,6 };
        Console.WriteLine(test.LengthOfLIS(array));
    }

    public int LengthOfLIS(int[] nums)
    {
        if(nums.Length == 0)
        {
            return 0;
        }
        if(nums.Length == 1)
        {
            return 1;
        }
        int[] length = new int[nums.Length];
        length[0] = 1;
        int totalMax = 0;
        for (int i = 0; i < nums.Length; ++i )
        {
            int max = 1;
            for (int j = 0; j < i; ++j )
            {
                if(nums[i] > nums[j])
                {
                    int tmp = Math.Max(1, 1 + length[j]);
                    max = Math.Max(tmp, max);
                }
            }
            length[i] = max;
            if(max > totalMax)
            {
                totalMax = max;
            }
        }

        return totalMax;
    }
}

