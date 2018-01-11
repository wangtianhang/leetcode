using System;
using System.Collections.Generic;
//
//using System.Text;
//

namespace leetCode
{
    class _4Median_of_Two_Sorted_Arrays
    {
        /*static void Main(string[] args)
        {
            _4Median_of_Two_Sorted_Arrays test = new _4Median_of_Two_Sorted_Arrays();
            int[] nums1 = new[] { 1, 1 };
            int[] nums2 = new[] { 1, 2 };
            double ret = test.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine(ret);

            Console.ReadLine();
        }*/

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] totalNums = CombineNums(nums1, nums2);

            if(totalNums.Length % 2 == 1)
            {
                int index = totalNums.Length / 2;
                return totalNums[index];
            }
            else
            {
                int index1 = totalNums.Length / 2 - 1;
                int index2 = totalNums.Length / 2;
                return (totalNums[index1] + totalNums[index2]) / 2.0f;
            }
        }

        int[] CombineNums(int[] nums1, int[] nums2)
        {
            int totalLength = nums1.Length + nums2.Length;
            int[] totalNums = new int [totalLength];

            if(nums1.Length == 0)
            {
                return nums2;
            }
            if(nums2.Length == 0)
            {
                return nums1;
            }

            bool isAscedingOrder = true;
            if(nums1[0] != nums1[nums1.Length - 1])
            {
                if (nums1[0] > nums1[nums1.Length - 1])
                {
                    isAscedingOrder = false;
                }
            }
            if (nums2[0] != nums2[nums2.Length - 1])
            {
                if (nums2[0] > nums2[nums2.Length - 1])
                {
                    isAscedingOrder = false;
                }
            }

            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < totalNums.Length; ++i)
            {
                bool num1HasElem = true;
                int num1Elem = 0;
                if(index1 == nums1.Length)
                {
                    num1HasElem = false;
                }
                else
                {
                    num1Elem = nums1[index1];
                }

                bool num2HasElem = true;
                int num2Elem = 0;
                if(index2 == nums2.Length)
                {
                    num2HasElem = false;
                }
                else
                {
                    num2Elem = nums2[index2];
                }

                int elem = GetElem(num1Elem, num1HasElem, num2Elem, num2HasElem, isAscedingOrder, ref index1, ref index2);
                totalNums[i] = elem;
            }

            return totalNums;
        }

        int GetElem(int elem1, bool num1HasElem, int elem2, bool num2HasElem, bool isAscedingOrder, ref int index1, ref int index2)
        {
            if(!num1HasElem)
            {
                index2++;
                return elem2;
            }
            if(!num2HasElem)
            {
                index1++;
                return elem1;
            }

            if(isAscedingOrder)
            {
                if(elem1 < elem2)
                {
                    index1++;
                    return elem1;
                }
                else
                {
                    index2++;
                    return elem2;
                }
            }
            else
            {
                if (elem1 > elem2)
                {
                    index1++;
                    return elem1;
                }
                else
                {
                    index2++;
                    return elem2;
                }
            }
        }
    }
}
