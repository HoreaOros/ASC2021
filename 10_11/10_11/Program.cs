using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_11
{
    class Program
    {
        static void Main(string[] args)
        {

            // Structurile pentru controlul executiei unui program 
            // 1. secventa = executarea unor instructiuni una dupa alta
            int n = 42;
            int m = 56;
            int suma, diferenta, cat, rest;

            bool bv = false; // valorile pe care le poate o variabila de tip bool sunt {false, true}

            suma = n + m;
            diferenta = n - m;
            cat = n / m;
            rest = n % m; // % operatorul pentru aflarea restului impartirii a 2 nr. intregi



            int a = n & m;
            int b = n | m;
            int c = n ^ m; // caret
            int d = n << 3;
            int e = n >> 4;
            int f = ~n;




            // 2. selectia = ramificarea executiei unui program in functie de o conditie
            // in C# exista 2 instructiuni pentru selectie: if, switch
            
            if (suma % 2 == 0) // == operator de egalitate
            {
                Console.WriteLine("Suma celor doua numere este numar par");
            }
            else
            {
                Console.WriteLine("Suma celor doua numere este numar impar");
            }


            // 3. iteratia/repetitie = executarea uneia (sau a mai multor) instructiuni
            // de mai multe ori atata timp cat o conditie este adevarata.
            // in C# exista 4 instructiuni repetitive: for, while, do-while, foreach

            suma = 0;
            int i = 1;
            while (i <= 10)
            {
                suma = suma + i;
                i = i + 1;
            }
            Console.WriteLine($"Suma numerelor de la 1 la 10 este: {suma}");

        }
    }
}
