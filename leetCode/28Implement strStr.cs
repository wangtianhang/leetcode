using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
