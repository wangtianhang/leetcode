using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


class _044_Wildcard_Matching
{
    public static void Test()
    {
        _044_Wildcard_Matching test = new _044_Wildcard_Matching();
        //Console.WriteLine(test.IsMatch("aaaabaaaabbbbaabbbaabbaababbabbaaaababaaabbbbbbaabbbabababbaaabaabaaaaaabbaabbbbaababbababaabbbaababbbba", 
        //    "*****b*aba***babaa*bbaba***a*aaba*b*aa**a*b**ba***a*a*"));
        Console.WriteLine(test.IsMatch("babbbbaabababaabbababaababaabbaabababbaaababbababaaaaaabbabaaaabababbabbababbbaaaababbbabbbbbbbbbbaabbb"
,"b**bb**a**bba*b**a*bbb**aba***babbb*aa****aabb*bbb***a"));
    }

    public bool IsMatch(string s, string p)
    {
        int is2 = 0;  
        int ip = 0;  
          
        int press = 0;  
        int presp = 0;  
          
        bool backstrack = false;  
        for( is2 = 0; is2 < s.Length; ){  
            if( ip == p.Length){  
                if(backstrack == false){  
                    return false;  
                }else if(p[p.Length-1] == '*'){  
                    return true;  
                }  
                else {  
                    ip = presp;  
                    is2 = ++press;  
                }  
            }  
            if(p[ip] == '?'){  
                is2++;  
                ip++;  
            }else if(p[ip] == '*'){  
                presp = ++ip;  
                press = is2;  
                backstrack = true;  
            }else{  
                if(p[ip] == s[is2]){  
                    is2++;  
                    ip++;  
                }else if(backstrack){  
                    ip = presp;  
                    is2 = ++press;  
                }else{  
                    return false;  
                }  
            }  
        }  
        while(ip <= p.Length - 1 && p[ip] == '*' ){  
            ip ++;  
            if( ip == p.Length){  
                break;  
            }  
        }  
        return ip == p.Length;  
    }

    public bool IsMatch2(string s, string p)
    {
        //StringBuilder p2 = new StringBuilder(p);
//         List<char> strList = new List<char>();
//         foreach(var iter in p)
//         {
//             strList.Add(iter);
//         }
//         for (int i = strList.Count; i >= 1; i--)
//         {
//             if (strList[i] == '*' && strList[i - 1] == '*')
//             {
//                 strList.RemoveAt(i);
//             }
//         }
        StringBuilder p2Builder = new StringBuilder(p);
        for (int i = p2Builder.Length - 1; i >= 1; i-- )
        {
            if(p2Builder[i] == '*' && p2Builder[i - 1] == '*')
            {
                p2Builder.Remove(i, 1);
            }
        }
        string p2 = p2Builder.ToString();
        string p3 = p2.Replace("*", ".*").Replace("?", ".");
        string p4 = "^" + p3 + "$";
        Match match = Regex.Match(s, p4);
        if (match.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

