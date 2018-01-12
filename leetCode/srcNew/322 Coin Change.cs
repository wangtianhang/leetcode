using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class _322_Coin_Change
{
    public static void Test()
    {
        _322_Coin_Change test = new _322_Coin_Change();
        Console.WriteLine(test.CoinChange(new int[] { 2 }, 2));
        Console.WriteLine(test.CoinChange(new int[] { 1 }, 2));
        Console.WriteLine(test.CoinChange(new int[] {2, 3, 4}, 5));
        Console.WriteLine(test.CoinChange(new int[] { 1, 2, 5 }, 11));
        Console.WriteLine(test.CoinChange(new int[] { 2 }, 3));
    }

    class CoinData
    {
        public int m_data = 0;
        public bool m_isValid = false;
    }

    public int CoinChange(int[] coins, int amount)
    {
        //int[] r = new int[amount + 1];
        List<CoinData> amountList = new List<CoinData>();
        for (int i = 0; i <= amount; ++i )
        {
            amountList.Add(new CoinData());
        }
        amountList[0].m_isValid = true;
        for (int i = 1; i <= amount; ++i )
        {
            int min = int.MaxValue;
            bool hasMin = false;
            for (int j = 0; j < coins.Length; ++j )
            {
                int index = i - coins[j];
                if (index >= 0)
                {
                    if (amountList[index].m_isValid)
                    {
                        min = Math.Min(min, 1 + amountList[index].m_data);
                        hasMin = true;
                    }
                }
            }
            if(hasMin)
            {
                amountList[i].m_data = min;
                amountList[i].m_isValid = true;
            }
        }

        if (amountList[amount].m_isValid)
        {
            return amountList[amount].m_data;
        }
        else
        {
            return -1;
        }
    }

    public int CoinChange2(int[] coins, int amount)
    {
        int sum = 0;
        if (CoinChangeRecursion(coins, amount, out sum))
        {
            return sum;
        }
        else
        {
            return -1;
        }
    }

    bool CoinChangeRecursion(int[] coins, int amount, out int sumOut)
    {
        if(amount == 0)
        {
            sumOut = 0;
            return true;
        }
        if(amount < 0)
        {
            sumOut = -1;
            return false;
        }
        int q = int.MaxValue;
        bool ret = false;
        for (int i = 0; i < coins.Length; ++i)
        {
            int sum = 0;
            if (CoinChangeRecursion(coins, amount - coins[i], out sum))
            {
                q = Math.Min(q, 1 + sum);
                ret = true;
            }
        }
        sumOut = q;
        return ret;
    }
}

