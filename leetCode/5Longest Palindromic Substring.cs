using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace leetCode
{
    class _5Longest_Palindromic_Substring
    {
        /*static void Main(string[] args)
        {
            _5Longest_Palindromic_Substring test = new _5Longest_Palindromic_Substring();
            string s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            DateTime time1 = DateTime.Now;
            string ret = test.LongestPalindrome(s);

            DateTime time2 = DateTime.Now;

            TimeSpan span = time2 - time1;
            Console.WriteLine("delta ms " + span.Milliseconds);

            Console.WriteLine(ret);

            Console.Read();
        }*/

        /*int m_i = 0;
        int m_j = 0;
        //Dictionary<int, bool> m_dynamicDic = new Dictionary<int, bool>();
        int[] m_dynamicList = null;
        public string LongestPalindrome(string s)
        {
            m_dynamicList = new int[s.Length * s.Length];
            for (int i = 0; i < s.Length; ++i )
            {
                for (int j = i; j < s.Length; ++j )
                {
                    bool ret = IsPalindromic(s, i, j);
                    if(ret)
                    {
                        if(j - i > m_j - m_i)
                        {
                            m_j = j;
                            m_i = i;
                        }
                    }
                }
            }

            return s.Substring(m_i, m_j - m_i + 1);
        }

        bool IsPalindromic(string s, int i, int j)
        {
            int key = i * s.Length + j;
            int cacheRet = m_dynamicList[key];
            if (cacheRet != 0)
            {
                return cacheRet == 1 ? true : false;
            }

            if(i == j)
            {
                //key = i * 1000 + j;
                m_dynamicList[key] = 1;
                return true;
            }
            else if(j == i + 1)
            {
                //key = i * 1000 + j;
                bool tmp = s[i] == s[j];
                if(tmp)
                {
                    m_dynamicList[key] = 1;
                }
                else
                {
                    m_dynamicList[key] = -1;
                }
                return tmp;
            }
            else
            {
                bool ret1 = s[i] == s[j];
                if(!ret1)
                {
                    //key = i * 1000 + j;
                    m_dynamicList[key] = -1;
                    return ret1;
                }
                else
                {
                    bool ret2 = IsPalindromic(s, i + 1, j - 1);
                    if (ret2)
                    {
                        m_dynamicList[key] = 1;
                    }
                    else
                    {
                        m_dynamicList[key] = -1;
                    }
                    return ret2;
                }
            }
        }*/

        //从中间向两边展开  
        string expandAroundCenter(string s, int c1, int c2)
        {
            int l = c1, r = c2;
            int n = s.Length;
            while (l >= 0 && r <= n - 1 && s[l] == s[r])
            {
                l--;
                r++;
            }
            return s.Substring(l + 1, r - l - 1);
        }

        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            if (n == 0) return "";
            string longest = s.Substring(0, 1);  // a single char itself is a palindrome  
            for (int i = 0; i < n - 1; i++)
            {
                string p1 = expandAroundCenter(s, i, i); //长度为奇数的候选回文字符串  
                if (p1.Length > longest.Length)
                    longest = p1;

                string p2 = expandAroundCenter(s, i, i + 1);//长度为偶数的候选回文字符串  
                if (p2.Length > longest.Length)
                    longest = p2;
            }
            return longest;
        }  
    }
}
