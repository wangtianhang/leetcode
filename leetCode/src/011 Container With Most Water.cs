using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{
    class _11Container_With_Most_Water
    {
        public int MaxArea(int[] height)
        {
            int capability = 0;
            int left = 0, right = height.Length - 1;

            while (left < right)
            {
                int water =
                    Math.Min(height[left], height[right]) * (right - left);

                if (water > capability) capability = water;

                if (height[left] < height[right])
                {
                    ++left;
                }
                else
                {
                    --right;
                }
            }

            return capability;
        }
    }
}
