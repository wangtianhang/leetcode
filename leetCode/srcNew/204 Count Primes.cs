using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.srcNew
{
    class _204_Count_Primes
    {
        //厄拉多塞筛法,小于n的质数的个数
        public int CountPrimes(int n)
        {
            if (n <= 2)
            {
                return 0;
            }
            if (n == 3)
            {
                // 小于3只有2一个质数
                return 1;
            }
            bool[] del = new bool[n];
            del[2] = false;
            for (int i = 3; i < n; ++i)
            {
                if (i % 2 == 0)
                {
                    del[i] = true;
                }
                else
                {
                    del[i] = false;
                }
            }

            for (int i = 3; i < n; i += 2)
            {
                if (!del[i])// 之后第一个未被划去
                {
                    if (i * i > n)
                    {
                        // 当前素数的平方大于n，跳出循环
                        break;
                    }
                    for (int j = 2; i * j < n; ++j)
                    {
                        del[i * j] = true;
                    }
                }
            }

            int count = 0;
            for (int i = 2; i < n; ++i)
            {
                if (!del[i])
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
