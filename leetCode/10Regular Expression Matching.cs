using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text.RegularExpressions;
//using System.Threading.Tasks;

namespace leetCode
{
    class _10Regular_Expression_Matching
    {
        /*static void Main(string[] args)
        {
            _10Regular_Expression_Matching test = new _10Regular_Expression_Matching();
            string s = "aa";
            string p = "a";
            bool ret = test.IsMatch(s, p);
            Console.WriteLine(ret);

            Console.Read();
        }*/

        public bool IsMatch(string s, string p)
        {
            string p2 = "^" + p + "$";
            Match match = Regex.Match(s, p2);
            if(match.Success)
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
