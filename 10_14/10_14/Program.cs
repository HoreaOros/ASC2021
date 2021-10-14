using System;
using System.Collections.Generic;
using System.Text;

namespace _10_14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mijloc();

            Conversie();
        }

        /// <summary>
        /// Converteste un numar in virgula fixa dintr-o baza b1 in baza b2. 
        /// Unde 2 <= b1, b2 <= 16
        /// Input: 
        /// numarul care e o secventa de caractere din multimea {0-9A-F.}
        /// va trebui sa faceti si validare pe input. 
        /// b1, b2, unde b1 este baza sursa si b2 este baza tinta. 
        /// Output: numarul in baza b2 sau "Date de intrare incorecte"
        /// Observatii:
        /// Trebuie sa tinteti cont de posibilitatea ca numarul in baza b2 sa nu poata fi reprezentat pe un numar finit de cifre
        /// </summary>
        private static void Conversie()
        {
            int n = 47;
            int b = 16;
            string result = ConvertFromBase10(n, b);
            Console.WriteLine($"{n} from base 10 = {result} in base {b}");
        }

        private static string ConvertFromBase10(int n, int b)
        {
            Stack<int> resturi = new Stack<int>();

            while (n > 0)
            {
                resturi.Push(n % b);
                n = n / b;
            }

            StringBuilder sb = new StringBuilder();
            int c;
            while (resturi.Count > 0)
            {
                c = resturi.Pop();
                if (c < 10)
                    sb.Append((char)('0' + c));
                else
                    sb.Append((char)('A' + c - 10));

            }
            return sb.ToString();
        }

        private static void Mijloc()
        {
            int st = 1234567890, dr = 1568123456;
            int mij = (st + dr) / 2;

            mij = st + (dr - st) / 2;

            Console.WriteLine($"Mijlocul intervalului [{st}, {dr}] este {mij}");
        }
    }
}
