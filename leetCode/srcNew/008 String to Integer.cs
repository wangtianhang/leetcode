using System;
using System.Collections.Generic;

using System.Text;



class _8String_to_Integer
{
    public static void Test()
    {
        _8String_to_Integer test = new _8String_to_Integer();
        Console.WriteLine(test.MyAtoi(" b11228552307"));
    }

    public int MyAtoi(string str)
    {
        str = str.Trim();
        bool begin = false;
        bool isPositive = true;
        int length = 0;
        for (int i = 0; i < str.Length; ++i )
        {
            if(!begin)
            {
                if (char.IsDigit(str[i]))
                {
                    begin = true;
                    length++;
                }
                else if (str[i] == '+')
                {
                    begin = true;
                }
                else if(str[i] == '-')
                {
                    begin = true;
                    isPositive = false;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (!char.IsDigit(str[i]))
                {
                    str = str.Remove(i);
                }
                else
                {
                    length++;
                }
            }
        }
        int ret = 0;
        if(int.TryParse(str, out ret))
        {
            return ret;
        }
        else
        {
            if (length > 0)
            {
                if(isPositive)
                {
                    return int.MaxValue;
                }
                else
                {
                    return int.MinValue;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}

