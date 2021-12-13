using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _12_13
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
            ulong a, b;
            string line;
            line = Console.ReadLine();
            string[] tokens = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            a = ulong.Parse(tokens[0]);
            b = ulong.Parse(tokens[1]);
            if (a > b)
            {
                Swap(ref a, ref b);
            }

            int cifreb2;
            ulong x = 0;


            


            for (ulong nr = a; nr <= b; nr++)
            {
                cifreb2 = Cifreb2(nr);
                if (IsPrime(cifreb2))
                {
                    x++;
                }
            }
            Console.WriteLine(x);
        }

        private static bool IsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            if (n == 2)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }
            for (int d = 3; d * d <= n; d = d + 2)
            {
                if (n % d == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static int Cifreb2(ulong nr)
        {
            int result = 0;
            while (nr != 0)
            {
                result++;
                nr /= 2;
            }
            return result;
        }

        private static void Swap(ref ulong a, ref ulong b)
        {
            ulong aux;
            aux = a;
            a = b;
            b = aux;
        }

        private static void P1()
        {
            int n, b, c;

            string line = Console.ReadLine();

            string[] tokens = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                n = int.Parse(tokens[0]);
                b = int.Parse(tokens[1]);
                c = int.Parse(tokens[2]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }



            int n10 = Convert_to_10(n, b);
            //Debug.WriteLine(n10);

            //long n_c = Convert_to_Base(n10, c);
            //Console.WriteLine(n_c);

            Console.WriteLine(Convert_To_Base_Reloaded(n10, c));

        }

        private static string Convert_To_Base_Reloaded(int n10, int c)
        {
            int cifra;
            string result = "";
            while (n10 != 0)
            {
                cifra = n10 % c;
                n10 = n10 / c;

                result = cifra.ToString() + result;
            }
            return result;
        }

        /// <summary>
        /// Converteste un numar din baza 10 in baza c
        /// </summary>
        /// <param name="n10">Numarul in baza 10</param>
        /// <param name="c">Baza tinta. <= 10</param>
        /// <returns>Reprezentarea numarului in baza c</returns>
        private static long Convert_to_Base(int n10, int c)
        {
            // 135 : 7 = 19 rest 2
            // 19 : 7 = 2 rest 5
            // 2 : 7 = 0 rest 2
            int p = 1;
            long result = 0;
            int cifra;
            while (n10 != 0)
            {
                cifra = n10 % c;
                n10 = n10 / c;

                result = result + cifra * p;
                p = p * 10;
            }
            return result;

        }

        /// <summary>
        /// Converteste un numar din baza b in baza 10
        /// </summary>
        /// <param name="n"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int Convert_to_10(int n, int b)
        {
            // 2013 = 3 + 1 * 4 + 0 * 4^2 + 2 * 4^3
            int c;
            int result = 0;
            int p = 1;

            while (n != 0)
            {
                c = n % 10;
                n = n / 10;
                result = result + c * p;
                p *= b;
            }
            return result;
        }
    }
}
