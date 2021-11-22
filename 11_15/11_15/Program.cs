using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics;

namespace _11_15
{
    class Program
    {
        static void Main(string[] args)
        {
            // P1();
            // P2();
            // P3();
            // P4();
            // P5();
            //P6();
            P7();
        }

        private static void P7()
        {

            int n;
            n = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();
            char[] sep = { ' ', '\n', '\t', '\r' };
            string[] t = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            int numar;
            //Debug.Assert(n == t.Length);
            int maximGlobal = 0;
            int maximLocal = 0;
            for (int i = 0; i < n; i++)
            {
                numar = int.Parse(t[i]);
                maximLocal = CifraMaxima(numar);
                if (maximLocal > maximGlobal)
                {
                    maximGlobal = maximLocal;
                }
            }
            Console.WriteLine(maximGlobal + 1);
        }

        /// <summary>
        /// Functia calculeaza si returneaza cea mai mare 
        /// cifra a unui numar
        /// </summary>
        /// <param name="numar">Numarul pentru care se calculeaza cea mai mare cifra</param>
        /// <returns>Cea mai mare cifra a lui numar</returns>
        private static int CifraMaxima(int numar)
        {
            int cifraMaxima = 0;
            int ultimaCifra;

            while (numar > 0)
            {
                ultimaCifra = numar % 10;
                if (ultimaCifra > cifraMaxima)
                {
                    cifraMaxima = ultimaCifra;
                }
                numar /= 10;
            }

            return cifraMaxima;
        }

        /// <summary>
        /// Functia determina numarul de cifre egale cu 1
        /// in reprezentarea in baza 2 a numarului n
        /// </summary>
        /// <param name="n">Numar</param>
        private static int Cifra1B2(int n)
        {
            int contor = 0;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    contor++;
                }
                n /= 2; // echivalent cu n = n / 2;
            }
            return contor;
        }

        /// <summary>
        /// Se citesc două numere naturale. 
        /// Să se afişeze numărul care are mai multe cifre 
        /// egale cu 1 în reprezentarea în baza 2.
        /// </summary>
        private static void P6()
        {
            int n1, n2;

            string line = Console.ReadLine();
            char[] sep = {' ', '\n', '\t', '\r'};
            string[] t = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            n1 = int.Parse(t[0]);
            n2 = int.Parse(t[1]);

            int c1, c2;

            c1 = Cifra1B2(n1);
            c2 = Cifra1B2(n2);

            if (c1 > c2)
            {
                Console.WriteLine(n1);
            }
            else if (c1 < c2)
            {
                Console.WriteLine(n2);
            }
            else if (n1 < n2)
            {
                Console.WriteLine(n1);
            }
            else
            {
                Console.WriteLine(n2);
            }

        }

        /// <summary>
        /// Se citește un număr natural n. 
        /// Să se determine câte cifre 0 și câte cifre 1 
        /// are reprezentarea în baza 2 a acestui număr.
        /// </summary>
        private static void P5()
        {
            int n;
            n = int.Parse(Console.ReadLine());


            int Z = 0, U = 0;
            while (n > 0)
            {
                if (n % 2 == 0)
                {
                    Z++;
                }
                else
                {
                    U++;
                }
                n /= 2;
            }
            Console.WriteLine("{0} {1}", Z, U);
        }

        private static void P4()
        {
            int n;
            n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            sb.Append("1");
            for (int i = 0; i < n; i++)
            {
                sb.Append("0");
            }
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Se dă numărul natural n. Calculați 2^n, 
        /// apoi afișați rezultatul în baza 2.
        /// </summary>
        /// <example>
        /// n = 2 -> 100
        /// n = 10 -> 10000000000
        /// </example>
        private static void P3()
        {
            int n;
            n = int.Parse(Console.ReadLine());
            Console.Write(1);
            for (int i = 0; i < n; i++)
            {
                Console.Write(0);
            }
        }

        /// <summary>
        /// Se dă numărul natural n. 
        /// Calculați 2^n, apoi afișați rezultatul în baza 10.
        /// </summary>
        private static void P2()
        {
            int n;
            n = int.Parse(Console.ReadLine());

            BigInteger p = new BigInteger(1);
            while (n > 0)
            {
                p = p * 2;
                n--; // echivalent cu n = n - 1;
            }
            Console.WriteLine(p);
        }

        /// <summary>
        /// Se dă numărul natural n. 
        /// Calculați 2^n, apoi afișați rezultatul în baza 10.
        /// </summary>
        private static void P1()
        {
            int n;
            n = int.Parse(Console.ReadLine());

            int p = 1;
            while (n > 0)
            {
                p = p * 2;
                n--; // echivalent cu n = n - 1;
            }
            Console.WriteLine(p);
        }
    }
}
