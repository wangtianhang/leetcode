using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class _070_Climbing_Stairs
{
    public static void Test()
    {
        _070_Climbing_Stairs test = new _070_Climbing_Stairs();
        Console.WriteLine(test.ClimbStairs(3));
    }

    public int ClimbStairs(int n)
    {
        if(n == 1)
        {
            return 1;
        }
        if(n == 2)
        {
            return 2;
        }
        int[] cache = new int[n + 1];
        cache[1] = 1;
        cache[2] = 2;
        for (int i = 3; i <= n; ++i)
        {
            cache[i] = cache[i - 1] + cache[i - 2];
        }
        return cache[n];
    }

    public int ClimbStairs2(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        else if (n == 2)
        {
            return 2;
        }
        else
        {
            return ClimbStairs2(n - 1) + ClimbStairs2(n - 2);
        }
    }
}

