using System;
using System.Collections.Generic;

using System.Text;


public class Palindrome_Number
{
    public bool IsPalindrome(int x)
    {
        string str = x.ToString();
        if(str.Length % 2 == 1)
        {
            for (int i = 0; i < (str.Length - 1) / 2; ++i )
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false; 
                }
            }
        }
        else
        {
            for (int i = 0; i < str.Length / 2; ++i)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
