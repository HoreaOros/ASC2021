using System;
using System.Collections.Generic;
using System.IO;

namespace _11_22
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //P1();
            //P2();
            P3();
        }

        /// <summary>
        /// Sa se transforme un numar din baza 2 in baza 16
        /// Numarul se citeste din fisierul hex.in
        /// Rezultatul se scrie in fisierul hex.out
        /// </summary>
        public static void P3()
        {
            string numar;
            string result = "";
            Dictionary<string, string> cifre2_16 = new Dictionary<string, string>();
            cifre2_16.Add("0000", "0");
            cifre2_16.Add("0001", "1");
            cifre2_16.Add("0010", "2");
            cifre2_16.Add("0011", "3");
            cifre2_16.Add("0100", "4");
            cifre2_16.Add("0101", "5");
            cifre2_16.Add("0110", "6");
            cifre2_16.Add("0111", "7");
            cifre2_16.Add("1000", "8");
            cifre2_16.Add("1001", "9");
            cifre2_16.Add("1010", "A");
            cifre2_16.Add("1011", "B");
            cifre2_16.Add("1100", "C");
            cifre2_16.Add("1101", "D");
            cifre2_16.Add("1110", "E");
            cifre2_16.Add("1111", "F");

            // INPUT
            StreamReader sr = new StreamReader("hex.in");
            numar = sr.ReadLine();
            sr.Close();

            // CALCULE
            int pad = numar.Length % 4;
            if (numar.Length % 4 > 0)
            {
                numar = numar.PadLeft(4 - pad + numar.Length, '0');
            }
            string cifra;
            for (int i = 0; i < numar.Length / 4; i++)
            {
                cifra = numar.Substring(i * 4, 4);
                result += cifre2_16[cifra];
            }

            // OUTPUT
            StreamWriter sw = new StreamWriter("hex.out");
            sw.WriteLine(result);
            sw.Close();
        }


        /// <summary>
        /// #3348 pbinfo.ro
        /// Se dă un număr natural n. 
        /// Descompuneți numărul n ca sumă de puteri ale lui 2.
        /// </summary>
        /// <example>
        /// 43 = 101011 ==> 1 2 8 32
        /// </example>
        public static void P2()
        {
            uint n;

            n = uint.Parse(Console.ReadLine());

            Stack<uint> st = new Stack<uint>();

            uint p = 1;

            while (n > 0)
            {
                p = 1;
                while (p <= n)
                {
                    p = p * 2;
                }
                p = p / 2; // p este cea mai mare putere al lui 2 mai mica sau egala decat n

                st.Push(p);
                n -= p;
            }

            while (st.Count > 0)
            {
                Console.Write("{0} ", st.Pop());
            }
        }


        /// <summary>
        /// #946 pbinfo.ro
        /// Se dă un număr n scris în baza 2. 
        /// Să se afișeze valoarea acestuia în baza 4.
        /// </summary>
        public static void P1()
        {
            string numar;
            string result = "";
            Dictionary<string, string> cifre24 = new Dictionary<string, string>();
            cifre24.Add("00", "0");
            cifre24.Add("01", "1");
            cifre24.Add("10", "2");
            cifre24.Add("11", "3");
            // INPUT
            numar = Console.ReadLine();


            // CALCULE
            if (numar.Length % 2 == 1)
            {
                numar = "0" + numar;
                //numar = numar.PadLeft(1 + numar.Length, '0');
            }
            string cifra;
            for (int i = 0; i < numar.Length / 2; i++)
            {
                cifra = numar.Substring(i * 2, 2);
                result += cifre24[cifra];
            }

            // OUTPUT
            Console.WriteLine(result);

        }
    }
}
