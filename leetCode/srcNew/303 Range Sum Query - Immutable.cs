using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NumArray
{
    int[] m_sums = null;
    public NumArray(int[] nums)
    {
        if(nums.Length == 0)
        {
            return;
        }
        m_sums = new int[nums.Length];
        m_sums[0] = nums[0];
        for (int i = 1; i < nums.Length; ++i )
        {
            m_sums[i] = nums[i] + m_sums[i - 1];
        }
    }

    public int SumRange(int i, int j)
    {
        int lowSum = 0;
        if(i - 1 >= 0)
        {
            lowSum = m_sums[i - 1];
        }
        return m_sums[j] - lowSum;
    }
}
