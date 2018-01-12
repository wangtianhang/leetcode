using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{
    class _18_4Sum
    {
        /*static void Main(string[] args)
        {
            _184Sum test = new _184Sum();
            int[] nums = new int[] { -1,-5,-5,-3,2,5,0,4};
            int target = -7;
            IList<IList<int>> ret = test.FourSum(nums, target);

             Console.WriteLine("count " + ret.Count);

             for (int i = 0; i < ret.Count; ++i)
             {
                 IList<int> iter = ret[i];
                 string str = "";
                 for (int j = 0; j < iter.Count; ++j)
                 {
                     str += " " + iter[j];
                 }
                 Console.WriteLine(str);
             }

             Console.Read();
        }*/

        List<List<int>> m_ret = new List<List<int>>();
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 4)
                return m_ret.ToArray();

            Array.Sort(nums);

            int len = nums.Length;
            for (int i = 0; i < len - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                find3(nums, i + 1, len - 1, target - nums[i], nums[i]);  
            }

            return m_ret.ToArray();
        }

        public void find3(int[] nums, int begin, int end, int target, int a)
        {
            //int len = end - begin;
            for (int i = begin; i < end - 1; i++)
            {
                if (i > begin && nums[i] == nums[i - 1]) continue;
                find2(nums, i + 1, end, nums[i], target, a);
            }
        }

        public void find2(int[] nums, int begin, int end, int b, int target, int a)
        {
            int l = begin, r = end;
            while (l < r)
            {
                if (b + nums[l] + nums[r] == target)
                {
                    List<int> ans = new List<int>();
                    ans.Add(a);
                    ans.Add(b);
                    ans.Add(nums[l]);
                    ans.Add(nums[r]);
                    m_ret.Add(ans); //放入结果集中  
                    while (l < r && nums[l] == nums[l + 1]) l++;
                    while (l < r && nums[r] == nums[r - 1]) r--;
                    l++;
                    r--;
                }
                else if (b + nums[l] + nums[r] < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
        }
    }
}
