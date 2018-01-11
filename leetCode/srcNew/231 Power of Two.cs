using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _231_Power_of_Two
    {
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0)
            {
                return false;
            }
            else
            {
                return (n & (n - 1)) == 0;
            }
        }
    }
}
