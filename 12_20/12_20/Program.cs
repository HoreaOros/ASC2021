using System;
using System.Collections.Generic;
using System.Text;


namespace _12_20
{
    class Program
    {
        static void Main(string[] args)
        {
            // P1();
            P2();
        }

        private static void P2()
        {
            int n;
            n = int.Parse(Console.ReadLine());

            //Console.WriteLine(Convert.ToString(n, 16).ToUpper());


            Console.WriteLine(MyBase16Converter(n));
        }

        private static string MyBase16Converter(int n)
        {
            int cifra;
            Stack<int> digits = new Stack<int>();
            while (n > 0)
            {
                cifra = n % 16;
                digits.Push(cifra);
                n /= 16;
            }
            StringBuilder sb = new StringBuilder();
            string map = "0123456789ABCDEF";
            while (digits.Count > 0)
            {
                cifra = digits.Pop();
                sb.Append(map[cifra]);
            }


            return sb.ToString();
        }

        private static void P1()
        {
            int b, n, p;

            string line;
            line = Console.ReadLine();
            string[] token = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bool result;
            result = int.TryParse(token[0], out b);
            if (result == false)
            {
                Console.WriteLine("Nu s-a reusit conversia.");
                return;
            }

            result = int.TryParse(token[1], out n);
            if (result == false)
            {
                Console.WriteLine("Nu s-a reusit conversia.");
                return;
            }

            result = int.TryParse(token[2], out p);
            if (result == false)
            {
                Console.WriteLine("Nu s-a reusit conversia.");
                return;
            }




            // Console.WriteLine("{0}", P1v1(b, n, p));

            Console.WriteLine("{0}", P1v2(b, n, p));
        }

        private static ulong P1v2(int b, int n, int p)
        {
            int M; // M = 10 ^ p
            M = MyPow(10, p);

            // (x * y) mod M = ((x mod M) * (y mod M)) mod M
            return MyPowModular((ulong)b, (ulong)n, (ulong)M);
        }

        private static ulong MyPowModular(ulong b, ulong n, ulong M)
        {
            if (n == 0)
            {
                return 1;
            }
            else if(n % 2 == 1)
            {
                return (b * MyPowModular(b, n - 1, M)) % M;
            }
            else
            {
                ulong r = MyPowModular(b, n / 2, M);
                return (r * r) % M;
            }
        }

        private static int MyPow(int v, int p)
        {
            if (p == 0)
            {
                return 1;
            }
            else if (p % 2 == 1)
            {
                return v * MyPow(v, p - 1);
            }
            else
            {
                int r = MyPow(v, p / 2);
                return r * r;
            }
        }

        /// <summary>
        /// Calculeaza numarul format din  ultimele p cifre ale lui b^n
        /// </summary>
        /// <param name="b">baza</param>
        /// <param name="n">exponentul</param>
        /// <param name="p">numarul de cifre de la final (p <= 9)</param>
        /// <returns></returns>
        private static ulong P1v1(int b, int n, int p)
        {
            return (ulong)(Math.Pow(b, n)) % (ulong)(Math.Pow(10, p));
        }
    }
}
