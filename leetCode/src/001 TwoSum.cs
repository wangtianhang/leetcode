using System.Collections.Generic;
using System;

public class _001_TwoSum
{
    /*static void Main(string[] args)
    {
        Solution test = new Solution();
        int[] nums = new int[] { 3, 2, 4 };
        int target = 6;
        int[] ret = test.TwoSum(nums, target);
        for (int i = 0; i < ret.Length; ++i)
        {
            Console.WriteLine(ret[i]);
        }

        Console.Read();
    }*/

    public int[] TwoSum(int[] nums, int target)
    {
        int[] ret = new int[2];
        Dictionary<int, int> numMap = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; ++i )
        {
            if(!numMap.ContainsKey(nums[i]))
            {
                numMap.Add(nums[i], i + 1);
            }
        }

        for (int i = 0; i < nums.Length; ++i )
        {
            int delta = target - nums[i];
            int index2 = 0;
            if(numMap.TryGetValue(delta, out index2))
            {
                int index1 = i + 1;
                if(index1 == index2)
                {
                    continue;
                }
                int minIndex = Math.Min(index1, index2);
                int maxIndex = Math.Max(index1, index2);
                ret[0] = minIndex;
                ret[1] = maxIndex;
                break;
            }
        }

        return ret;
    }
}
