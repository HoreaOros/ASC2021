using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_06
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            //Console.WriteLine($"4! = {factorial(4)}");


            // 2.
            //int n = 4, f;
            //factorial(n, out f);
            //Console.WriteLine($"4! = {f}");


            // 3.
            //Console.WriteLine($"cmmdc(18, 24) = {cmmdc(18, 24)}");


            // 4.
            //int a = 18, b = 24, r;
            //cmmdc(a, b, out r);
            //Console.WriteLine($"cmmdc({a}, {b}) = {r}");

            // 5. 
            int n = 12504;
            Console.WriteLine($"Suma cifrelor numarului {n} este {sumcif(n)}");
        }

        private static int sumcif(int n)
        {
            if (n == 0)
                return 0;
            else
                return n % 10 + sumcif(n / 10);
        }

        private static void cmmdc(int a, int b, out int r)
        {
            if (b == 0)
            {
                r = a;
            }
            else
            {
                cmmdc(b, a % b, out r);
            }
        }

        private static int cmmdc(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return cmmdc(b, a % b); 
        }

        private static void factorial(int n, out int f)
        {
            if (n == 0)
                f = 1;
            else
            {
                factorial(n - 1, out f);
                f *= n;
            }
        }

        private static int factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * factorial(n - 1);
        }
    }
}
