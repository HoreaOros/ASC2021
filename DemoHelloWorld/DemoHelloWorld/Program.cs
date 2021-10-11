using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World of C#!");

            double c = 0.001;
            double suma = 0;
            double epsilon = 0.000001;
            for (int i = 0; i < 1000000; i++)
            {
                suma += c;
            }


            // aici suma nu va fi 1000 asa cum ne asteptam din cauza faptului ca
            // nu toate cele 1 milion de valori de la pasul precedent sunt rerezentabile exact. 

            if (Math.Abs(suma - 1000) < epsilon)
            {
                Console.WriteLine("Detonte bomb!");
            }
            else
            {
                Console.WriteLine("Phew!");
            }
        }
    }
}
