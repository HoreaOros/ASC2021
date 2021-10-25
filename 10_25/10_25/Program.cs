using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_25
{
    class Program
    {
        static void Main(string[] args)
        {
            //P1();
            //P2();

            P3();
        }


        /// <summary>
        /// Să se scrie o functie care citește un șir de n numere naturale şi 
        /// determină numărul din șir care are prima cifră minimă. 
        /// Dacă există mai multe numere cu prima cifră minimă, se va determina cel mai mare dintre acestea.
        /// </summary>
        /// <example>
        /// daca n este 5
        /// si numerele sunt 72 30 12 165 725
        /// atuni se va afisa 165
        /// </example>
        private static void P3()
        {
            int n;

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());



            int numar;
            int primaCifra;
            int cifraMinima = 10;
            int rezultat = 0;
            for (int i = 0; i < n; i++)
            {
                numar = int.Parse(Console.ReadLine());

                primaCifra = PrimaCifra(numar);

                if (primaCifra < cifraMinima)
                {
                    cifraMinima = primaCifra;
                    rezultat = numar;
                }
                else if (primaCifra == cifraMinima)
                {
                    if (numar > rezultat)
                    {
                        rezultat = numar;
                    }
                }
            }
            Console.WriteLine($"Cel mai mare numar cu prima cifra minima este: {rezultat}");

        }

        /// <summary>
        /// Determina prima cifra a numarului
        /// </summary>
        /// <param name="numar"></param>
        /// <returns></returns>
        private static int PrimaCifra(int numar)
        {
            while (numar > 9)
            {
                numar = numar / 10;
            }
            return numar;
        }

        /// <summary>
        /// Să se scrie o functie care citește numărul natural n 
        /// și determină suma S=1*n+2*(n-1)+3*(n-2)+...+n*1.
        /// </summary>
        /// <example>
        /// Daca n = 3 atunci S = 1*3 + 2*2 + 3*1 = 10
        /// </example>
        private static void P2()
        {
            int n, suma = 0;

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());


            for (int i = 1, j = n; i <= n; i++, j--)
            {
                suma = suma + i * j;
            }

            Console.WriteLine($"Suma 1*n+2*(n-1)+3*(n-2)+...+n*1 este: {suma}");

            Console.WriteLine();
        }

        /// <summary>
        /// Să se scrie o functie care citește numărul natural n 
        /// și determină suma S=1*2+2*3+3*4+...+n*(n+1).
        /// </summary>
        /// <example>
        /// Daca n = 3 atunci S = 1 * 2 + 2 * 3 + 3 * 4  = 20
        /// </example>
        private static void P1()
        {
            int n = 0, S = 0;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                S = S + i * (i + 1);
            }

            Console.WriteLine($"Suma 1*2+2*3+...+{n}*{n+1} este: {S}");

            Console.WriteLine();


        }
    }
}
