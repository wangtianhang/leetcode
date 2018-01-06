using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _22Generate_Parentheses
    {
        /*static void Main(string[] args)
        {
            _22Generate_Parentheses test = new _22Generate_Parentheses();
            IList<string> ret = test.GenerateParenthesis(4);
            for (int i = 0; i < ret.Count; ++i )
            {
                Console.WriteLine(ret[i]);
            }

            Console.Read();
        }*/

        
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> ret = new List<string>();
            generate(n, n, "", ret);
            return ret;
        }

        void generate(int leftNum,int rightNum,string s, List<string> result)  
        {  
            if(leftNum==0&&rightNum==0)  
            {  
                result.Add(s);  
            }  
            if(leftNum>0)  
            {  
                generate(leftNum-1,rightNum,s+'(',result);  
            }  
            if(rightNum>0&&leftNum<rightNum)  
            {  
                generate(leftNum,rightNum-1,s+')',result);  
            }  
        }  

        //List<string> m_ret = new List<string>();
        /*public IList<string> GenerateParenthesis(int n)
        {
           IList<string> tmp = GenerateParenthesisRecur(n);
           Dictionary<string, int> distinctMap = new Dictionary<string,int>();
           List<string> ret = new List<string>();
           for (int i = 0; i < tmp.Count; ++i )
           {
               if (!distinctMap.ContainsKey(tmp[i]))
               {
                   distinctMap.Add(tmp[i], 1);
                   ret.Add(tmp[i]);
               }
           }

           return ret;
        }

        public IList<string> GenerateParenthesisRecur(int n)
        {
            if (n == 0)
            {
                return new List<string>();
            }
            if (n == 1)
            {
                List<string> ret = new List<string>();
                ret.Add("()");
                return ret;
            }
            IList<string> tmp = GenerateParenthesisRecur(n - 1);
            List<string> ret2 = new List<string>();
            for (int i = 0; i < tmp.Count; ++i)
            {
                string iter = tmp[i];
                ret2.Add("()" + iter);
                ret2.Add("(" + iter + ")");
                ret2.Add(iter + "()");
            }
            return ret2;
        }*/
    }
}
