using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _26Remove_Duplicates_from_Sorted_Array
    {
        /*static void Main(string[] args)
        {
            _26Remove_Duplicates_from_Sorted_Array test = new _26Remove_Duplicates_from_Sorted_Array();

            int[] nums = new int[] { 1, 1, 2, 2};

            int ret = test.RemoveDuplicates(nums);

            for (int i = 0; i < ret; ++i )
            {
                Console.WriteLine(nums[i]);
            }

            Console.WriteLine("count " + ret);

            Console.Read();
        }*/

        public int RemoveDuplicates(int[] nums)
        {
            int length = nums.Length;
            for (int i = 0; i < length - 1; ++i )
            {
                if(nums[i] == nums[i + 1])
                {
                    int nextNumIndex = i + 1;
                    while(nextNumIndex < length)
                    {
                        if(nums[i] == nums[nextNumIndex])
                        {
                            nextNumIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Array.Copy(nums, nextNumIndex, nums, i + 1, length - nextNumIndex);
                    length = length - (nextNumIndex - i - 1);
                }
            }

            return length;
        }
    }
}
