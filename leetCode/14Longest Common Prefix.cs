using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _14Longest_Common_Prefix
    {
        /*static void Main(string[] args)
        {
            _14Longest_Common_Prefix test = new _14Longest_Common_Prefix();
            List<string> strsList = new List<string>();
            strsList.Add("1");
            strsList.Add("12");
            string ret = test.LongestCommonPrefix(strsList.ToArray());
            Console.WriteLine("result " + ret);

            Console.Read();
        }*/

        public string LongestCommonPrefix(string[] strs)
        {
            if(strs.Length == 0)
            {
                return "";
            }

            string prefix = "";
            int index = 0;
            
            for (; ; )
            {
                char commonChar = char.MinValue;
                bool hasAssign = false;
                bool isEnd = false;
                for (int i = 0; i < strs.Length; ++i)
                {
                    string iter = strs[i];
                    if(index >= iter.Length)
                    {
                        isEnd = true;
                        break;
                    }
                    else
                    {
                        char tmp = iter[index];
                        if(hasAssign)
                        {
                            if(commonChar == tmp)
                            {
                                continue;
                            }
                            else
                            {
                                isEnd = true;
                                break;
                            }
                        }
                        else
                        {
                            hasAssign = true;
                            commonChar = tmp;
                        }
                    }
                }

                if(isEnd)
                {
                    break;
                }
                else
                {
                    index++;
                    prefix += commonChar;
                }
            }

            return prefix;
        }
    }
}
