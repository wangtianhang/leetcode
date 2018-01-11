using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _053_Maximum_Subarray
    {
        public int MaxSubArray(int[] nums)
        {
            int maxsum, maxhere;
            maxsum = maxhere = nums[0];   //初始化最大和为a【0】  
            for (int i = 1; i < nums.Length; i++)
            {
                if (maxhere <= 0)
                    maxhere = nums[i];  //如果前面位置最大连续子序列和小于等于0，则以当前位置i结尾的最大连续子序列和为a[i]  
                else
                    maxhere += nums[i]; //如果前面位置最大连续子序列和大于0，则以当前位置i结尾的最大连续子序列和为它们两者之和  
                if (maxhere > maxsum)
                {
                    maxsum = maxhere;  //更新最大连续子序列和  
                }
            }
            return maxsum;  
        }
    }
}
