using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class _168_Excel_Sheet_Column_Title
{
    public static void Test()
    {
        _168_Excel_Sheet_Column_Title test = new _168_Excel_Sheet_Column_Title();
        Console.WriteLine(test.ConvertToTitle(27));
    }

    public string ConvertToTitle(int n)
    {
        List<char> str = new List<char>();
        while (n != 0)
        {
            n -= 1;
            int last = n % 26;
            str.Add((char)(last + 65));
            n /= 26;
        }

        StringBuilder ret = new StringBuilder();
        for (int i = str.Count - 1; i >= 0; --i)
        {
            ret.Append(str[i]);
        }
        return ret.ToString();
    }
}

