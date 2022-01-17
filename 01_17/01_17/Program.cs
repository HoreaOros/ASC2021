using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // P1();
            // P2();
            P3();
        }

        private static void P3()
        {
            int n, T;
            string line;
            
            // Citesc de pe prima linie n si T
            line = Console.ReadLine();
            char[] sep = { ' ' };
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(tokens[0]);
            T = int.Parse(tokens[1]);

            // Citesc de pe a doua linie cele n elemente ale vectorului a
            int[] a = new int[n];
            line = Console.ReadLine();
            tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(tokens[i]);
            }

            Array.Sort(a);

            int x, y;
            for (int i = 0; i < T; i++)
            {
                line = Console.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                x = int.Parse(tokens[0]);
                y = int.Parse(tokens[1]);

                Console.WriteLine("{0}", binary_search_leftmost(a, y + 1) - binary_search_leftmost(a, x));
            }


        }

        /// <summary>
        /// Determina cate elemente din vectorul a sunt mai mici decat T
        /// </summary>
        /// <param name="A"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int Rank(int[] A, int T)
        {
            return binary_search_leftmost(A, T);
        }

        private static int binary_search_rightmost(int[] A, int T)
        {
            int left = 0;
            int right = A.Length;
            int mid;
            while (left < right)
            {
                mid = (left + right) / 2;
                if (A[mid] > T)
                    right = mid;
                else
                    left = mid + 1;
            }
            return right - 1;
        }
        private static int binary_search_leftmost(int[] A, int T)
        {
            int left = 0;
            int right = A.Length;
            int mid;
            while (left < right)
            {
                mid = (left + right) / 2;
                if (A[mid] < T)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }
        /// <summary>
        /// 508 pbinfo
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void P2()
        {
            int n;
            n = int.Parse(Console.ReadLine());
            string line;
            line = Console.ReadLine();
            char[] sep = {' '};
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int[] x = new int[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = int.Parse(tokens[i]);
            }


            int m;
            line = Console.ReadLine();
            m = int.Parse(line);

            line = Console.ReadLine();
            tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int y;
            foreach (string item in tokens)
            {
                y = int.Parse(item);
                int pos; 
                pos = MyBinarySearch(x, y);
                if (pos == -1)
                    Console.Write("{0} ", 0);
                else
                    Console.Write("{0} ", 1);
            }
        }

        private static int MyBinarySearch(int[] A, int T)
        {
            int left = 0, right = A.Length - 1;
            int mid;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (A[mid] < T)
                {
                    left = mid + 1;
                }
                else if (A[mid] > T)
                {
                    right = mid - 1;
                }
                else
                    return mid;
            }
            return -1;
        }

        /// <summary>
        /// TODO 4025 pbinfo
        /// </summary>
        private static void P1()
        {
            int k;
            k = int.Parse(Console.ReadLine());
        }
    }
}
