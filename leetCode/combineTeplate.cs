using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class combineTeplate
    {
        /*static void Main(string[] args)
        {
            Tuple<int, int> test1 = new Tuple<int, int>(1, 2);
            Console.WriteLine(test1.GetHashCode());
            Tuple<int, int> test2 = new Tuple<int, int>(1, 2);
            Console.WriteLine(test2.GetHashCode());

            Console.Read();
        }*/
        void combine( int [] a, int n, int m,  int [] b, int M )
        {
          for(int i=n; i>=m; i--)   // 注意这里的循环范围
          {
            b[m-1] = i - 1;
            if (m > 1)
            {
                combine(a, i - 1, m - 1, b, M);
            }
            else                     // m == 1, 输出一个组合
            {
              for(int j=M-1; j>=0; j--)
              {
                  Console.Write(a[b[j]]);
              }

              Console.WriteLine();
            }
 
          }
        }
    }


}
