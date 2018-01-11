using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{
    class _29Divide_Two_Integers
    {
        public int Divide(int dividend, int divisor)
        {
            if(divisor == 0)
            {
                return int.MaxValue;
            }

            int dividendIter = dividend;
            int ret = 0;
            while(dividendIter > divisor)
            {
                dividendIter -= divisor;
                ret += 1;
            }

            return ret;
        }
    }
}
