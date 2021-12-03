using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_02
{
    class Program
    {
        static void Main(string[] args)
        {
                                                             //7654_3210   
            uint instruction = 0b0010_0110_0000_0011_0010_0110_0000_0011;

            Console.WriteLine(Convert.ToString(instruction, 2));

            int pos = 7;
            instruction = SetBit(instruction, pos);
            Console.WriteLine(Convert.ToString(instruction, 2));

            instruction = ResetBit(instruction, pos);
            Console.WriteLine(Convert.ToString(instruction, 2));

            
            Console.WriteLine($"Bitul de pe pozitia {pos} are valoarea {GetBit(instruction, pos)}"); 
        }

        /// <summary>
        /// Determina valoarea bitului de pozitia pos din numar
        /// </summary>
        /// <param name="numar"></param>
        /// <param name="pos"></param>
        /// <returns>0 sau 1</returns>
        private static uint GetBit(uint numar, int pos) 
        {
            // 00011100 >> 2 ====> 00000111 & 00000001 ====> 00000001
            return (numar >> pos) & 1u;
        }

        /// <summary>
        /// Seteaza bitul de pe pozitia pos la valoarea 1
        /// </summary>
        /// <param name="numar"></param>
        /// <param name="pos">pozitia</param>
        /// <returns></returns>
        private static uint SetBit(uint numar, int pos)
        {
            // 00011100
            // 01000000 (trebuie sa creez aceasta masca de biti). 
            // ------------- (aplic operatorul | )
            // 01011100

            return numar | (1u << pos);

        }

        /// <summary>
        /// Seteaza bitul de pe pozitia pos la valoarea 0
        /// </summary>
        /// <param name="numar"></param>
        /// <param name="pos">pozitia</param>
        private static uint ResetBit(uint numar, int pos)
        {
            // 01011100
            // 10111111    (trebuie sa creez aceasta masca de biti). 
            // ------------- (aplic operatorul &)
            // 00011100

            return numar & ~(1u << pos);
        }
    }
}
