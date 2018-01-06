using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _27Remove_Element
    {
        /*static void Main(string[] args)
        {
            _27Remove_Element test = new _27Remove_Element();
            int[] nums = new int[] { 1, 2, 2, 3};
            int ret = test.RemoveElement(nums, 2);
            for (int i = 0; i < ret; ++i )
            {
                Console.WriteLine(nums[i]);
            }

            Console.Read();
        }*/

        public int RemoveElement(int[] nums, int val)
        {
            Array.Sort(nums);

            int length = nums.Length;
            for (int i = 0; i < nums.Length; ++i )
            {
                if(nums[i] == val)
                {
                    int nextNumIndex = i + 1;
                    while (nextNumIndex < length)
                    {
                        if (nums[nextNumIndex] == val)
                        {
                            nextNumIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Array.Copy(nums, nextNumIndex, nums, i, length - nextNumIndex);
                    length = length - (nextNumIndex - i);
                    break;
                }
            }

            return length;
        }
    }
}
