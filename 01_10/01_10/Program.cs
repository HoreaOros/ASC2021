using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_10
{
    class Program
    {
        // TODO: tratarea situatiile exceptionale date de expresii eronate.
        // TODO: adaugarea posibilitatii de a evalua expresii care contin apeluri de functii matematice definite de tipul Math (sin, cos, abs etc.)
        // TODO: adaugarea posibilitatii de accepta expresii sub orice forma. Implementarea Parsing-ului intr-un mod mai general.
        // TODO: operatorii pot fi numere reale (numere in virgula fixa, de ex. 3.14)
        // TODO: operatorii pot fi si variabile a caror valoare se va lua dintr-o tabela de simboluri. 

        
        static void Main(string[] args)
        {
            // preconditii:
            // operanzii ii vom considera numere naturale
            // atomii lexicali vom considera ca sunt separati prin spatiu (pentru a putea folosi functia Split). 
            string input = "101 + ( 22  - 3 ) * 4";

            
            // parsing
            input = "( " + input + " )";
            string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            // partea 1 - transformarea expresiei din notatie infix in notatie postfix.
            List<string> rpn = RPN(tokens);
            
            foreach (var item in rpn)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();


            // partea 2 - evaluarea epxresiei. 
            Console.WriteLine($"Valoarea expresiei este {EvaluateRPN(rpn)}");

        }

        private static int EvaluateRPN(List<string> rpn)
        {
            Stack<int> stack = new Stack<int>();

            foreach (var item in rpn)
            {
                if (IsOperator(item))
                {
                    int op1, op2;
                    op2 = stack.Pop();
                    op1 = stack.Pop();
                    stack.Push(Operate(op1, op2, item));
                }
                else
                {
                    stack.Push(int.Parse(item));
                }
            }

            return stack.Pop();
        }

        private static int Operate(int op1, int op2, string item)
        {
            int retValue;
            switch (item)
            {
                case "+":
                    retValue = op1 + op2;
                    break;
                case "-":
                    retValue = op1 - op2;
                    break;
                case "*":
                    retValue = op1 * op2;
                    break;
                case "/":
                    retValue = op1 / op2;
                    break;
                case "%":
                    retValue = op1 + op2;
                    break;
                default:
                    retValue = 0;
                    break;
            }
            return retValue;
        }

        private static bool IsOperator(string item)
        {
            switch (item)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                    return true;
                default:
                    return false;
            }
        }

        private static List<string> RPN(string[] tokens)
        {
            Stack<string> stack = new Stack<string>();
            List<string> rpn = new List<string>();

            foreach (var token in tokens)
            {
                if (token == "(")
                {
                    stack.Push(token);
                }
                else if(IsOperator(token))
                {
                    string op;
                    while (stack.Peek() != "(" && Priority(stack.Peek()) >= Priority(token))
                    {
                        op = stack.Pop();
                        rpn.Add(op);
                    }
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    string op;
                    op = stack.Pop();
                    while (op != "(")
                    {
                        rpn.Add(op);
                        op = stack.Pop();
                    }
                }
                else // operand
                {
                    rpn.Add(token);
                }
            }
            return rpn;
        }

        private static int Priority(string op)
        {
            int retValue;
            switch (op)
            {
                case "+":
                case "-":
                    retValue = 1;
                    break;
                case "*":
                case "/":
                case "%":
                    retValue = 2;
                    break;
                default:
                    retValue = 0;
                    break;
            }
            return retValue;
        }
    }
}
