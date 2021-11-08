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
            Conversie();
        }

        private static void Conversie()
        {
            string n = Console.ReadLine();
            int b1, b2;
            b1 = int.Parse(Console.ReadLine());
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

            return sb.ToString() + sb2.ToString();
        }
    }
}
