using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _367_Valid_Perfect_Square
    {
        public bool IsPerfectSquare(int num)
        {
            if (num <= 0)
            {
                return false;
            }
            else
            {
                double sqrtD = Math.Sqrt(num);
                int sqrt = (int)(sqrtD + 0.5);
                return sqrt * sqrt == num;
            }
        }
    }
}
