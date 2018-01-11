using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{
    class _20Valid_Parentheses
    {
        /*static void Main(string[] args)
        {
            _20Valid_Parentheses test = new _20Valid_Parentheses();
            string s = "]";
            bool ret = test.IsValid(s);

            Console.WriteLine(ret);

            Console.Read();
        }*/

        public bool IsValid(string s)
        {
            Stack<char> cacheStack = new Stack<char>();
            for (int i = 0; i < s.Length; ++i )
            {
                char iter = s[i];
                if(iter == '('
                    || iter == '['
                    || iter == '{')
                {
                    cacheStack.Push(iter);
                }
                else if(iter == ')')
                {
                    if(cacheStack.Count != 0)
                    {
                        char popChar = cacheStack.Pop();
                        if (popChar != '(')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(iter == ']')
                {
                    if(cacheStack.Count != 0)
                    {
                        char popChar = cacheStack.Pop();
                        if (popChar != '[')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else if(iter == '}')
                {
                    if(cacheStack.Count != 0)
                    {
                        char popChar = cacheStack.Pop();
                        if (popChar != '{')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if(cacheStack.Count == 0)
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
