using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{
    class _28Implement_strStr
    {
        public int StrStr(string haystack, string needle)
        {
            int ret = haystack.IndexOf(needle);
            return ret;
        }
    }
}
