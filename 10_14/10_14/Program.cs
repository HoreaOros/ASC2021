using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mijloc();

            //Conversie();
            Conversii.Conversie();
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
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
            Console.Write("Baza initiala a numarului: ");
            var baza = int.Parse(Console.ReadLine());
            
            Console.Write("Numarul care va fi transformat: ");
            var numar = Console.ReadLine();
            
            Console.Write("Baza in care va fi scris numarul: ");
            var bazaNoua = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Numarul {numar}, transformat din baza {baza} in {bazaNoua} este: {ConvertFromBase10(ConvertToBase10D(numar, baza), bazaNoua)}");
        }

        /// <summary>
        /// Converteste un numar real dat ca si string in baza 10.
        /// </summary>
        /// <param name="val">string-ul care defineste numarul.</param>
        /// <param name="baza">baza in care este scris numarul.</param>
        /// <returns>numarul rezultat, sub forma de double.</returns>
        private static double ConvertToBase10D(string val, int baza)
        {
            if (baza == 10)
                return double.Parse(val.Replace(',', '.'));

            string[] split = val.Replace(',', '.').Split('.');
            
            return double.Parse($@"{ConvertToBase10(split[0], baza)}{
                (split.Length > 1 ? $".{ConvertToBase10(split[1], baza)}" : string.Empty)}");
        }
        
        /// <summary>
        /// Converteste un numar dat ca si string din baza mentionata in baza 10.
        /// </summary>
        /// <param name="val">string-ul care defineste numarul</param>
        /// <param name="baza">baza in care este scris numarul</param>
        /// <returns>numarul rezultat, sub forma de int</returns>
        private static int ConvertToBase10(string val, int baza)
        {
            if (baza == 10)
                return int.Parse(val);

            int valoareFinala = 0;
            int index = val.Length - 1;
            foreach (var x in val)
            {
                valoareFinala += Convert.ToInt32(Math.Pow(baza, index) * (('0' <= x && '9' >= x) ? x - '0' : x - 'A'));
                index -= 1;
            }

            return valoareFinala;
        }

        /// <summary>
        /// Converteste o valoare reala intr-un string in baza ceruta.
        /// </summary>
        /// <param name="numar">numarul real care va fi convertit.</param>
        /// <param name="baza">baza in care va fi convertit.</param>
        /// <returns>numarul in baza ceruta sub forma de string</returns>
        private static string ConvertFromBase10(double numar, int baza)
        {
            StringBuilder sb = new StringBuilder();
            int numarIntreg = (int) numar;

            while (numarIntreg != 0)
            {
                int x = numarIntreg % baza;
                sb.Insert(0, (x < 10 ? (char) ('0' + x) : (char) ('A' + (x - 10))));
                numarIntreg /= baza;
            }

            //Daca valoarea are zecimale.
            if (Math.Abs(numar % 1) > (Double.Epsilon * 100))
            {
                sb.Append('.');
                int index = sb.Length;
                double parteFractionara = numar - (int) numar;

                while (parteFractionara > Double.Epsilon * 100)
                {
                    parteFractionara *= baza;
                    int parteIntreaga = Convert.ToInt32(Math.Floor(parteFractionara));
                    sb.Insert(index,
                        (parteIntreaga < 10 ? (char) ('0' + parteIntreaga) : (char) ('A' + (parteIntreaga - 10))));

                    parteFractionara -= parteIntreaga;
                }
            }
            
            return sb.ToString();
        }
        
        /*private static string ConvertFromBase10(int n, int b)
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
        }*/

        private static void Mijloc()
        {
            int st = 1234567890, dr = 1568123456;
            int mij = (st + dr) / 2;

            mij = st + (dr - st) / 2;

            Console.WriteLine($"Mijlocul intervalului [{st}, {dr}] este {mij}");
        }
    }

    class Conversii
    {
        public static void Conversie()
        {
            Console.Write("Introduceti numarul: ");
            string n = Console.ReadLine();
            int b1, b2;
            Console.Write("Baza sursa = ");
            b1 = int.Parse(Console.ReadLine());
            Console.Write("Baza tinta = ");
            b2 = int.Parse(Console.ReadLine());
            if (b1 < 2 && b1 > 16 || b2 < 2 && b2 > 16)
            {
                Console.WriteLine("Date de intrare incorecte. Baza sursa si baza tinta trebuie sa fie in intervalul {2, 16}");
                return;
            }
            double nBase10 = ConvertToBase10(n, b1);
            string result = ConvertFromBase10(nBase10, b2);
            Console.WriteLine($"{n} from base {b1} = {result} in base {b2}");
        }
        private static double ConvertToBase10(string n, int b1)
        {
            double s = 0;
            int length = n.Length;
            int pozPunct = n.IndexOf('.');
            int exponent = length - 1;
            if (pozPunct != -1)
            {
                exponent = pozPunct - 1;
            }

            for (int i = 0; i < length; i++)
            {
                if (n[i] == '.')
                {
                    exponent += 1;
                    continue;
                }
                int cifra = n[i] - '0';
                if (n[i] == 'a' || n[i] == 'A')
                {
                    cifra = 10;
                }
                if (n[i] == 'b' || n[i] == 'B')
                {
                    cifra = 11;
                }
                if (n[i] == 'c' || n[i] == 'C')
                {
                    cifra = 12;
                }
                if (n[i] == 'd' || n[i] == 'D')
                {
                    cifra = 13;
                }
                if (n[i] == 'e' || n[i] == 'E')
                {
                    cifra = 14;
                }
                if (n[i] == 'f' || n[i] == 'F')
                {
                    cifra = 15;
                }
                s = s + cifra * Math.Pow(b1, exponent - i);
            }
            return s;
        }

        private static string ConvertFromBase10(double n, int b2)
        {
            int pIntreaga = (int)Math.Floor(n);
            double pFractionara = n - pIntreaga;

            int pIntreagaCopy = pIntreaga;

            Stack<int> resturi = new Stack<int>();
            while (pIntreagaCopy > 0)
            {
                resturi.Push(pIntreagaCopy % b2);
                pIntreagaCopy /= b2;
            }
            StringBuilder sb = new StringBuilder();
            int c;
            while (resturi.Count > 0)
            {
                c = resturi.Pop();
                if (c < 10)
                {
                    sb.Append((char)('0' + c));
                }
                else
                {
                    sb.Append((char)('A' + c - 10));
                }
            }

            StringBuilder sb2 = new StringBuilder();
            Queue<int> pIntregi = new Queue<int>();
            double pFractionaraCopy = pFractionara;
            while (pFractionaraCopy != 0)
            {
                double temp = pFractionaraCopy * b2;
                c = (int)Math.Floor(temp);
                pIntregi.Enqueue(c);
                pFractionaraCopy = temp - c;
            }
            sb2.Append('.');
            while (pIntregi.Count > 0)
            {
                c = pIntregi.Dequeue();
                if (c < 10)
                {
                    sb2.Append((char)('0' + c));
                }
                else
                {
                    sb2.Append((char)('A' + c - 10));
                }
            }

            if(sb2.ToString() == ".")
            {
                return sb.ToString();
            }
            return sb.ToString() + sb2.ToString();
        }
    }
}
