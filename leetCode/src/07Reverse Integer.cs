using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace leetCode
{
    class _7Reverse_Integer
    {
        /*static void Main(string[] args)
        {
            int a = 1534236469;
            _7Reverse_Integer test = new _7Reverse_Integer();
            int ret = test.Reverse(a);
            Console.WriteLine(ret);

            Console.Read();
        }*/

        public int Reverse(int x)
        {
            /*int x2 = 0;
            if(x > 0)
            {
                x2 = x;
            }
            else if(x == 0)
            {
                return 0;
            }
            else
            {
                x2 = -x;
            }*/

            bool isNagetive = false;
            if(x < 0)
            {
                isNagetive = true;
                x = -x;
            }

            string strX = x.ToString();
            string strReverseX = "";
            for (int i = strX.Length - 1; i >= 0; --i )
            {
                strReverseX += strX[i];
            }

            int reverseX = 0;
            int.TryParse(strReverseX, out reverseX);
            if(isNagetive)
            {
                reverseX = -reverseX;
            }

            return reverseX;
        }
    }
}
