using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 蓄水池采样
/// </summary>
class _398_Random_Pick_Index
{
    public static void Test()
    {
        int[] nums = new int[] {1,2,3,3,3};
        _398_Random_Pick_Index test = new _398_Random_Pick_Index(nums);
        Dictionary<int, int> countDic = new Dictionary<int, int>();
        for (int i = 0; i < 1000000; ++i )
        {
            int index = test.pick(3);
            if(!countDic.ContainsKey(index))
            {
                countDic.Add(index, 1);
            }
            else
            {
                countDic[index] += 1;
            }
        }
        foreach(var iter in countDic)
        {
            Console.WriteLine(iter.Key + " " + iter.Value);
        }
    }

    int[] m_nums = null;
    System.Random m_ran = null;
    public _398_Random_Pick_Index(int[] nums) 
    {
        m_nums = nums;
        long tick = System.DateTime.Now.Ticks;
        m_ran = new System.Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
    }
    
    public int pick(int target) 
    {

        int count = 0;
        int index = -1;
        for (int i = 0; i < m_nums.Length; ++i )
        {
            if(m_nums[i] == target)
            {
                count += 1;
                if(count == 1)
                {
                    index = i;
                    continue;
                }
                else
                {
                    double p2 = 1 / (double)count;
                    double p1 = 1 - p2;
                    int next = m_ran.Next(0, 10000 * 10000 * 10);
                    double p = (double)next / (10000 * 10000 * 10);
                    if(p < p2)
                    {
                        index = i;
                    }
                }
            }
        }
        return index;
    }
}


