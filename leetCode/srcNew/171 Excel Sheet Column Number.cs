using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class _171_Excel_Sheet_Column_Number
{
    public static void Test()
    {
        _171_Excel_Sheet_Column_Number test = new _171_Excel_Sheet_Column_Number();
        Console.WriteLine(test.TitleToNumber("AB"));
    }

    public int TitleToNumber(string s)
    {
        s = s.Trim();
        int n = 0;
        int product = 1;
        for (int i = s.Length - 1; i >= 0; --i)
        {
            int num = s[i] - 64;
            n += num * product;
            product *= 26;
        }
        return n;
    }
}

