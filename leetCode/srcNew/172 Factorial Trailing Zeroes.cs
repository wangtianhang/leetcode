using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _172_Factorial_Trailing_Zeroes
    {
        public static void Test()
        {
            _172_Factorial_Trailing_Zeroes test = new _172_Factorial_Trailing_Zeroes();
            Console.WriteLine(test.TrailingZeroes(1808548329));
        }

        public int TrailingZeroes(int n)
        {
            if (n / 5 < 5)
            {
                return n / 5;
            }
            else
            {
                return n / 5 + TrailingZeroes(n / 5);
            }
        }
    }
}
