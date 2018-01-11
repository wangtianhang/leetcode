using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _224_Basic_Calculator
    {
        public static void Test()
        {
            _224_Basic_Calculator test = new _224_Basic_Calculator();
            Console.WriteLine(test.Calculate("(1+(4+5+2)-3)+(6+8)"));
        }

        public int Calculate(string s)
        {
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
                return 0;

            //求出所给表达式的长度
            int len = s.Length;

            //操作符栈
            Stack<char> op_stack = new Stack<char>();

            //操作数栈
            Stack<int> num_stack = new Stack<int>();
            for (int i = 0; i < len; ++i)
            {
                //(1) 跳过空格
                if (s[i] == ' ')
                    continue;

                //(2) 操作符入栈
                else if (s[i] == '(' || s[i] == '+' || s[i] == '-')
                {
                    op_stack.Push(s[i]);
                    continue;
                }//elif

                //(3) 右括号
                else if (s[i] == ')')
                {
                    while (op_stack.Peek() != '(')
                    {
                        //从数据栈弹出两个操作数
                        int num2 = num_stack.Peek();
                        num_stack.Pop();
                        int num1 = num_stack.Peek();
                        num_stack.Pop();

                        //从符号栈，弹出操作符
                        char op = op_stack.Peek();
                        op_stack.Pop();

                        if (op == '+')
                            num_stack.Push(num1 + num2);
                        else if (op == '-')
                            num_stack.Push(num1 - num2);
                    }//while

                    //弹出左括号
                    op_stack.Pop();

                    //此时查看操作数和操作符栈
                    while (op_stack.Count != 0 && op_stack.Peek() != '(')
                    {
                        //从数据栈弹出两个操作数
                        int num2 = num_stack.Peek();
                        num_stack.Pop();
                        int num1 = num_stack.Peek();
                        num_stack.Pop();

                        //从符号栈，弹出操作符
                        char op = op_stack.Peek();
                        op_stack.Pop();

                        if (op == '+')
                            num_stack.Push(num1 + num2);
                        else if (op == '-')
                            num_stack.Push(num1 - num2);
                    }//while
                }//elif
                else
                {
                    int num = 0;
                    while (i < len && isDigit(s[i]))
                    {
                        num = num * 10 + (s[i] - '0');
                        i++;
                    }//while
                    //回退一个字符
                    --i;
                    num_stack.Push(num);

                    //此时查看操作数和操作符栈
                    while (op_stack.Count != 0 && op_stack.Peek() != '(')
                    {
                        //从数据栈弹出两个操作数
                        int num2 = num_stack.Peek();
                        num_stack.Pop();
                        int num1 = num_stack.Peek();
                        num_stack.Pop();

                        //从符号栈，弹出操作符
                        char op = op_stack.Peek();
                        op_stack.Pop();

                        if (op == '+')
                            num_stack.Push(num1 + num2);
                        else if (op == '-')
                            num_stack.Push(num1 - num2);
                    }//while
                }
            }//for
            return num_stack.Peek();
        }

        bool isDigit(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            else
                return false;
        }
    }
}
