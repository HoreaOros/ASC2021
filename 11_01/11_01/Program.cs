using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_01
{
    class Program
    {
        // minime, maxime.
        static void Main(string[] args)
        {
            // P1();
            // P2();
            // P3();
            // P4();
        }


        /// <summary>
        /// Se dau n numere naturale.Determinaţi cele mai mici trei numere dintre cele date.
        /// n >= 3;
        /// </summary>
        /// <example>
        /// n = 5, 1017 48 310 5710 162 se va afisa 310 162 48
        /// </example>
        private static void P4()
        {
            int n;

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            if (n < 3)
            {
                Console.WriteLine("numar este prea mic");
                return;
            }
            int minim1 = int.MaxValue, minim2 = int.MaxValue, minim3 = int.MaxValue;

            int numar;
            for (int i = 0; i < n; i++)
            {
                numar = int.Parse(Console.ReadLine());

                if (numar <= minim1)
                {
                    minim3 = minim2;
                    minim2 = minim1;
                    minim1 = numar;
                }
                else if (numar <= minim2)
                {
                    minim3 = minim2;
                    minim2 = numar;
                }
                else if (numar < minim3)
                {
                    minim3 = numar;
                }
            }

            Console.WriteLine($"Cele mai mici 3 numere sunt {minim3} {minim2} {minim1}");

        }


        /// <summary>
        /// Să se scrie un program care citește un șir de n numere naturale 
        /// şi determină valoarea maximă din șir și de câte ori apare.
        /// </summary>
        /// <example>
        /// n = 5
        /// 1,3,5,4,5 => val maxima este 5 iar numarul de aparitii este 2;
        /// </example>
        private static void P3()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Introduceti {n} numere, cate unul pe o linie");
            int numar;

            int maxim = int.MinValue;
            int numar_aparitii = 0;

            for (int i = 0; i < n; i++)
            {
                numar = int.Parse(Console.ReadLine());


                if (numar > maxim)
                {
                    maxim = numar;
                    numar_aparitii = 1;
                }
                else if (numar == maxim)
                {
                    numar_aparitii++;
                }
            }

            Console.WriteLine($"Cel mai mare numar introdus este {maxim} si apare de {numar_aparitii} ori");
        }

        /// <summary>
        /// Se citesc numere de la tastatură până la apariția lui zero. Să se determine maximul lor.
        /// </summary>
        /// <example>
        /// 3,4,5,-1, 0 ==> 5;
        /// -1, -2, -3, 0 ==> -1
        /// 0 == > empty list;
        /// </example>
        private static void P2()
        {
            int numar;
            int maxim = int.MinValue;
            bool 

            result = int.TryParse(Console.ReadLine(), out numar);
            if (result == false)
            {
                Console.WriteLine("Ceea ce ati introdus nu se poate converti in numar intreg");
                //return;
            }

            if (result == true && numar == 0)
            {
                Console.WriteLine("<empty list>");
                return;
            }

            while (result == false || numar != 0)
            {
                if (numar > maxim)
                {
                    maxim = numar;
                }

                result = int.TryParse(Console.ReadLine(), out numar);
                if (result == false)
                {
                    Console.WriteLine("Ceea ce ati introdus nu se poate converti in numar intreg");
                    // return;

                }
            }

            Console.WriteLine($"Cel mai mare numar introdus este: {maxim}");

        }

        /// <summary>
        /// Se dau n numere întregi. Calculaţi cel mai mare dintre cele n numere date.
        /// </summary>
        private static void P1()
        {
            int n = 0;
            bool result;
            Console.Write("n = ");
            result = int.TryParse(Console.ReadLine(), out n);

            if (result == false)
            {
                Console.WriteLine("Ceea ce ati introdus nu se poate converti in numar intreg");
                return;
            }


            int numar;
            int maxim = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                result = int.TryParse(Console.ReadLine(), out numar);
                if (result == false)
                {
                    Console.WriteLine("Ceea ce ati introdus nu se poate converti in numar intreg");
                    return;
                }

                if (numar > maxim)
                {
                    maxim = numar;
                }
            }


            Console.WriteLine($"Cel mai mare numar introdus este: {maxim}");
        }
    }
}
