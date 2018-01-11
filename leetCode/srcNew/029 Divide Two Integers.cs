using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{
    class _29Divide_Two_Integers
    {
        public int Divide(int dividend, int divisor)
        {
            try
            {
                int ret = 0;
                checked
                {
                    ret = dividend / divisor;
                }
                return ret;
            }
            catch (System.Exception ex)
            {
                return int.MaxValue;
            }
        }
    }
}
