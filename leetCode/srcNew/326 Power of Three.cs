using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _326_Power_of_Three
    {
        public bool IsPowerOfThree(int n)
        {
            if (n <= 0)
            {
                return false;
            }
            else
            {
                //任何一个3的x次方一定能对int型里最大的3的x次方求模
                if (1162261467 % n == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
