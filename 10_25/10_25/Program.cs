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
            P1();
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
