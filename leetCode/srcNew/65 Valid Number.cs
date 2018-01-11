using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _65_Valid_Number
    {
        public bool IsNumber(string s)
        {
            s = s.Trim().Replace(" ", "_");
            if (s.Contains("e"))
            {
                string[] strs = s.Split('e');
                if (strs.Length != 2)
                {
                    return false;
                }
                else
                {
                    float a = 0;
                    long b = 0;
                    return float.TryParse(strs[0], out a) && long.TryParse(strs[1], out b);
                }
            }
            else
            {
                float a = 0;
                return float.TryParse(s, out a);
            }

        }
    }
}
