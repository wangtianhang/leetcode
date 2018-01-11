using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{
    class _8String_to_Integer
    {
        public int MyAtoi(string str)
        {
            int ret = 0;
            int.TryParse(str, out ret);

            return ret;
        }
    }
}
