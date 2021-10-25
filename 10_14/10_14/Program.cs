using System;
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
}
