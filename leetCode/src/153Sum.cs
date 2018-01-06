using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _153Sum
    {
        /*static void Main(string[] args)
        {
            _153Sum test = new _153Sum();

            int[] nums = new int[] { 0, 0, 0};

            Console.WriteLine(nums.Length);

            DateTime time1 = DateTime.Now;
            
            IList<IList<int>> ret = test.ThreeSum(nums);

            DateTime time2 = DateTime.Now;

            TimeSpan span = time2 - time1;
            Console.WriteLine("delta ms " + span.Milliseconds);

            Console.WriteLine("count " + ret.Count);
            
            for (int i = 0; i < ret.Count; ++i )
            {
                IList<int> iter = ret[i];
                string str = "";
                for (int j = 0; j < iter.Count; ++j )
                {
                    str += " " + iter[j];
                }
                Console.WriteLine(str);
            }

            Console.Read();
        }*/

        /*public IList<IList<int>> ThreeSum(int[] nums)
        {
            Dictionary<int, int> numCountMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i )
            {
                if(!numCountMap.ContainsKey(nums[i]))
                {
                    numCountMap.Add(nums[i], 1);
                }
                else
                {
                    numCountMap[nums[i]]++;
                }
            }

            //Tuple<int, int, int>
            Dictionary<Tuple<int, int, int>, int> tupleTable = new Dictionary<Tuple<int, int, int>, int>();
            List<int> tmpList = new List<int>();
            for (int i = 0; i < nums.Length; ++i )
            {
                for (int j = i; j < nums.Length; ++j )
                {
                    int needNum = -(nums[i] + nums[j]);
                    if(numCountMap.ContainsKey(needNum))
                    {
                        tmpList.Clear();
                        tmpList.Add(nums[i]);
                        tmpList.Add(nums[j]);
                        tmpList.Add(needNum);
                        tmpList.Sort();

                        if (IsValid(tmpList, numCountMap))
                        {
                            Tuple<int, int, int> tmp = new Tuple<int, int, int>(tmpList[0], tmpList[1], tmpList[2]);
                            if (!tupleTable.ContainsKey(tmp))
                            {
                                tupleTable.Add(tmp, 1);
                            }
                        }
                    }
                }
            }

            List<List<int>> retListList = new List<List<int>>();
            foreach(var iter in tupleTable)
            {
                List<int> retList = new List<int>();
                retList.Add(iter.Key.Item1);
                retList.Add(iter.Key.Item2);
                retList.Add(iter.Key.Item3);
                retListList.Add(retList);
            }

            return retListList.ToArray();
        }

        bool IsValid(List<int> sortedList, Dictionary<int, int> numConntMap)
        {
            if(sortedList[0] == sortedList[1] && sortedList[1] == sortedList[2])
            {
                return numConntMap[sortedList[0]] >= 3;
            }
            else if (sortedList[0] == sortedList[1])
            {
                return numConntMap[sortedList[0]] >= 2;
            }
            else if (sortedList[1] == sortedList[2])
            {
                return numConntMap[sortedList[1]] >= 2;
            }
            else
            {
                return true;
            }
        }*/

        List<List<int>> m_ret = new List<List<int>>();

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length < 3) 
                return m_ret.ToArray();

            Array.Sort(nums);

            int len = nums.Length;
            for (int i = 0; i < len - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                find(nums, i + 1, len - 1, nums[i]); //寻找两个数与num[i]的和为0  
            }

            return m_ret.ToArray();
        }

        public void find(int[] nums, int begin, int end, int target)
        {
            int l = begin, r = end;
            while (l < r)
            {
                if (nums[l] + nums[r] + target == 0)
                {
                    List<int> ans = new List<int>();
                    ans.Add(target);
                    ans.Add(nums[l]);
                    ans.Add(nums[r]);
                    m_ret.Add(ans); //放入结果集中  
                    while (l < r && nums[l] == nums[l + 1]) l++;
                    while (l < r && nums[r] == nums[r - 1]) r--;
                    l++;
                    r--;
                }
                else if (nums[l] + nums[r] + target < 0)
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
