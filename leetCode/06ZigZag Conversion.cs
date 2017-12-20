using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class _06ZigZag_Conversion
{
    public static void Test()
    {
        _06ZigZag_Conversion test = new _06ZigZag_Conversion();
        string ret = test.Convert("AB", 1);
        Console.WriteLine(ret);
        ret = test.Convert("ABC", 2);
        Console.WriteLine(ret);
    }

    public string Convert(string s, int numRows)
    {
        if(numRows == 1)
        {
            return s;
        }

        StringBuilder[] test = new StringBuilder[numRows];
        for (int i = 0; i < numRows; ++i )
        {
            test[i] = new StringBuilder();
        }
        bool isDown = true;
        int curRow = 0;
        for (int i = 0; i < s.Length; ++i )
        {
            if(isDown)
            {
                test[curRow].Append(s[i]);
                if (curRow == numRows - 1)
                {
                    isDown = false;
                    curRow--;
                }
                else
                {
                    curRow++;
                }
            }
            else
            {
                test[curRow].Append(s[i]);
                if (curRow == 0)
                {
                    isDown = true;
                    curRow++;
                }
                else
                {
                    curRow--;
                }
            }
        }

        StringBuilder ret = new StringBuilder();
        foreach(var iter in test)
        {
            ret.Append(iter);
        }
        return ret.ToString();
    }
}

