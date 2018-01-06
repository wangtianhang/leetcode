using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _16_3Sum_Closest
    {
        /*static void Main(string[] args)
        {
            _163Sum_Closest test = new _163Sum_Closest();
            int[] nums = new int []{ -1 , 2 ,1 ,-4};
            int target = 1;
            int ret = test.ThreeSumClosest(nums, target);

            Console.WriteLine(ret);

            Console.Read();
        }*/

        //int m_nearest = 0;
        public int ThreeSumClosest(int[] nums, int target)
        {
            //if (nums == null || nums.Length < 3)
            //    return m_ret.ToArray();

            int nearest = 0;
            bool hasInit = false;

            Array.Sort(nums);

            int len = nums.Length;
            for (int i = 0; i < len - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) 
                    continue;
                int ret = find(nums, i + 1, len - 1, nums[i], target); //寻找两个数与num[i]的和为0
                if(ret == target)
                {
                    nearest = ret;
                    return nearest;
                }
                else
                {
                    if(!hasInit)
                    {
                        hasInit = true;
                        nearest = ret;
                    }
                    if(Math.Abs(ret - target) < Math.Abs(nearest - target))
                    {
                        nearest = ret;
                    }
                }
            }

            return nearest;
        }

        public int find(int[] nums, int begin, int end, int target, int targetSum)
        {
            int nearest = nums[begin] + nums[end] + target;
            int l = begin, r = end;
            while (l < r)
            {
                int sum = nums[l] + nums[r] + target;
                if (sum == targetSum)
                {
                    //while (l < r && nums[l] == nums[l + 1]) l++;
                    //while (l < r && nums[r] == nums[r - 1]) r--;
                    //l++;
                    //r--;
                    return targetSum;
                }
                else if (sum < targetSum)
                {
                    if (Math.Abs(sum - targetSum) < Math.Abs(nearest - targetSum))
                    {
                        nearest = sum;
                    }
                    l++;
                }
                else
                {
                    if (Math.Abs(sum - targetSum) < Math.Abs(nearest - targetSum))
                    {
                        nearest = sum;
                    }
                    r--;
                }
            }

            return nearest;
        }  
    }
}
