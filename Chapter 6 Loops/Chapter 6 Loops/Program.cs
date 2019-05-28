using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Chapter_6_Loops
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exo1.Execute();
            //Exo2.Execute();
            //Exo3.Execute();
            Exo4.Execute();
            //Exo5.Execute();
            //Exo6.Execute();
            //Exo7.Execute();
            //Exo8.Execute();
            //Exo9.Execute();
            //Exo10.Execute();
            //Exo11.Execute();
            //Exo12.Execute();
            //Exo13.Execute();
            //Exo14.Execute();
            //Exo15.Execute();
            //Exo16.Execute();
            //Exo17.Execute();
            //Exo18.Execute();
        }

        public static BigInteger Factorial(int n)
        {
            if (n < 0)
                return -1;
            BigInteger N = 1;
            for (int i = 1; i <= n; i++)
            {
                N *= i;
            }
            return N;
        }

        public static int CheckLastZeros(BigInteger value)
        {
            int number = 0;
            for (int i = 10; value % i == 0; i *= 10)
            {
                number++;
            }
            return number;
        }
    }

    /// <summary>
    /// Write a program that prints on the console the numbers from 1 to N. 
    /// The number N should be read from the standard input.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            Console.Write("Write an integer n = ");
            int n = 0;
            if(int.TryParse(Console.ReadLine(),out n))
            {
                PrintIntFrom1ToN(n);
            }
        }

        /// <summary>
        /// Print all integers from 1 to <paramref name="n"/>.
        /// </summary>
        /// <param name="n">The limit for the loop.</param>
        private static void PrintIntFrom1ToN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    /// <summary>
    /// Write a program that prints on the console the numbers from 1 to N, which are not divisible by 3 and 7 simultaneously. 
    /// The number N should be read from the standard input.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Console.Write("Write an integer n = ");
            int n = 0;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                PrintIntDivisibleBy3And7From1ToN(n);
            }
        }

        /// <summary>
        /// Print all the integers that's divisible by 3 and 7 from 1 to <paramref name="n"/>.
        /// </summary>
        /// <param name="n">The limit for the loop.</param>
        private static void PrintIntDivisibleBy3And7From1ToN(int n)
        {
            int modulo = 3 * 7;
            for (int i = 1; i <= n; i++)
            {
                if (i % modulo == 0)
                    Console.WriteLine(i);
            }
        }
    }

    /// <summary>
    /// Write a program that reads from the console a series of integers and prints the smallest and largest of them.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            int[] numbers = new int[20];
            Console.WriteLine("Write 20 integers : ");
            for (int i = 0; i < numbers.Length; i++)
            {
                bool nextIteration = true;
                do
                {
                    Console.WriteLine("Numbers : "+ i + " / 20");
                    Console.Write("Write an integer : ");
                    nextIteration = !int.TryParse(Console.ReadLine(), out numbers[i]);
                    Console.Clear();
                } while (nextIteration);
            }
            IEnumerable<int> query = numbers.OrderBy((number) => number);
            Console.WriteLine("min = {0} / max = {1}", query.First(), query.Last());
        }
    }

    /// <summary>
    /// Write a program that prints all possible cards from a standard deck of cards, without jokers (there are 52 cards: 4 suits of 13 cards).
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            string[] cards = new string[13] { "As", "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept", "Huit", "Neuf", "Dix", "Valet", "Dame", "Roi" };
            string[] forms = new string[4] { "Coeur", "Pique", "Carreaux", "Trefle" };
            foreach (string form in forms)
            {
                foreach (string card in cards)
                {
                    Console.WriteLine($"{card} de {form}");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that reads from the console number N and print the sum of the first N members of the Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            int value = int.Parse(Console.ReadLine());
            BigInteger i = 0;
            Console.WriteLine(i);
            BigInteger j = 1;
            Console.WriteLine(j);
            BigInteger temp;
            for (int index = 0; index < value; index++)
            {
                temp = i + j;
                i = j;
                j = temp;
                Console.WriteLine(j);
            }
        }
    }

    /// <summary>
    /// Write a program that calculates N!/K! for given N and K (1<K<N).
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            if (K > N)
            {
                K ^= N;
                N ^= K;
                K ^= N;
            }
            BigInteger NFactorial = 1;
            BigInteger KFactorial = 1;
            for (int i = 1, j = 1; i <= N; i++, j++)
            {
                NFactorial *= i;
                if (j < K)
                {
                    KFactorial *= j;
                }
            }
            Console.WriteLine("The result is {0}", NFactorial / KFactorial);
        }
    }

    /// <summary>
    /// Write a program that calculates N!*K!/(N-K)! for given N and K (1<K<(>)N).
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            if (K > N)
            {
                K ^= N;
                N ^= K;
                K ^= N;
            }
            int M = N - K;
            BigInteger NFactorial = 1;
            BigInteger KFactorial = 1;
            BigInteger MFactorial = 1;
            for (int i = 1, j = 1; i <= N; i++, j++)
            {
                NFactorial *= i;
                if (j < K)
                {
                    KFactorial *= j;
                }
                if (i < M)
                {
                    MFactorial *= i;
                }
            }
            Console.WriteLine("The result is {0}", (NFactorial * KFactorial) / MFactorial);
        }
    }

    /// <summary>
    /// In combinatorics, the Catalan numbers are calculated by the following formula : ..., for n ≥ 0. 
    /// Write a program that calculates the nth Catalan number by given n.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            if (n >= 0)
            {

                BigInteger catalanNumber = ((Program.Factorial(2 * n) / (Program.Factorial(n + 1) * Program.Factorial(n))));
                Console.WriteLine($"The Catalan Number is {catalanNumber}");
            }
            for (int i = 0; i < 20; i++)
            {
                BigInteger catalanNumber = ((Program.Factorial(2 * i) / ((Program.Factorial(i + 1)) * Program.Factorial(i))));
                Console.WriteLine($"The Catalan Number is {catalanNumber}");
            }
        }
    }

    /// <summary>
    /// Write a program that for a given integers n and x, calculates the sum: S
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());
            BigInteger sum = 1;
            for (int i = 1; i < n; i++)
            {
                sum += Program.Factorial(i) / BigInteger.Pow(x, n);
            }
            Console.WriteLine($"The sum is {sum}");
        }

    }

    /// <summary>
    /// Write a program that reads from the console a positive integer number N(N<(>) 20) and prints a matrix of numbers as on the figures below:
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            if (n > 20)
                n = 20;
            else if (n < 0)
                n = 1;
            int value = 1;
            for (int x = 0; x < n; x++)
            {
                int tempValue = value;
                for (int y = 0; y < n; y++)
                {
                    if (tempValue < 10)
                        Console.Write(" ");
                    Console.Write(tempValue + " ");
                    tempValue++;
                }
                value++;
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// Write a program that calculates with how many zeroes the factorial of a given number ends.
    /// Examples:
    /// N = 10->N! = 3628800 -> 2
    /// N = 20->N! = 2432902008176640000 -> 4
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            BigInteger N = Program.Factorial(n);
            int number = Program.CheckLastZeros(N);
            Console.WriteLine("There is {0} 0 at the end of the factorial {1}", number, N);
        }
    }

    /// <summary>
    /// Write a program that converts a given number from decimal to binary notation(numeral system).
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            string binary = IntegerToBinary(n);
            Console.WriteLine($"Integer : {n} | Binary : {binary}");
        }

        public static string IntegerToBinary(int value)
        {
            string tempBinary = "";
            string binary = "";

            do
            {
                tempBinary += (value % 2).ToString();
                value /= 2;
            } while (value != 0);
            for (int i = tempBinary.Length - 1; i >= 0; i--)
            {
                binary += tempBinary[i];
            }
            return binary;
        }
    }

    /// <summary>
    /// Write a program that converts a given number from binary to decimal notation.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {
            Console.Write("n = ");
            string n = Console.ReadLine();
            int value = BinaryToInt(n);
            Console.WriteLine($"Binary : {n} | Integer : {value}");
        }

        static int BinaryToInt(string value)
        {
            string integerTemp = "";
            int integer = 0;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                integerTemp += value[i];
            }
            for (int i = 0; i < integerTemp.Length; i++)
            {
                integer += (integerTemp[i] == '1') ? (int)Math.Pow(2, i) : 0;
            }
            return integer;
        }
    }

    /// <summary>
    /// Write a program that converts a given number from decimal to hexadecimal notation.
    /// </summary>
    public static class Exo14
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            string value = DecToHexadec(n);
            Console.WriteLine($"Decimal : {n} | Hexadecimal : {value}");
        }

        public static string DecToHexadec(int value)
        {
            string tempHexa = "";
            string hexa = "";

            do
            {
                int tempValue = value % 16;
                if (tempValue < 10)
                {
                    tempHexa += tempValue.ToString();
                }
                else
                {
                    switch (tempValue)
                    {
                        case 10:
                            tempHexa = "A";
                            break;
                        case 11:
                            tempHexa = "B";
                            break;
                        case 12:
                            tempHexa = "C";
                            break;
                        case 13:
                            tempHexa = "D";
                            break;
                        case 14:
                            tempHexa = "E";
                            break;
                        case 15:
                            tempHexa = "F";
                            break;
                        default:
                            break;
                    }
                }
                value /= 16;
            } while (value != 0);
            for (int i = tempHexa.Length - 1; i >= 0; i--)
            {
                hexa += tempHexa[i];
            }
            return hexa;
        }
    }

    /// <summary>
    /// Write a program that converts a given number from hexadecimal to decimal notation.
    /// </summary>
    public static class Exo15
    {
        public static void Execute()
        {
            Console.Write("n = ");
            string n = Console.ReadLine();
            int value = HexadecToDec(n);
            Console.WriteLine($"Hexadecimal : {n} | Decimal : {value}");
        }

        public static int HexadecToDec(string value)
        {
            string integerTemp = "";
            int integer = 0;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                integerTemp += value[i];
            }
            for (int i = 0; i < integerTemp.Length; i++)
            {
                int HDecValue;
                if (!int.TryParse(integerTemp[i].ToString(), out HDecValue))
                {
                    switch (integerTemp[i])
                    {
                        case 'A':
                            HDecValue = 10;
                            break;
                        case 'B':
                            HDecValue = 11;
                            break;
                        case 'C':
                            HDecValue = 12;
                            break;
                        case 'D':
                            HDecValue = 13;
                            break;
                        case 'E':
                            HDecValue = 14;
                            break;
                        case 'F':
                            HDecValue = 15;
                            break;
                        default:
                            break;
                    }
                }
                integer += HDecValue * (int)Math.Pow(16, i);
            }
            return integer;
        }
    }

    /// <summary>
    /// Write a program that by a given integer N prints the numbers from 1 to N in random order.
    /// </summary>
    public static class Exo16
    {
        public static void Execute()
        {
            Random random = new Random();
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            List<int> integers = new List<int>(n + 1);
            for (int i = 0; i < integers.Capacity; i++)
            {
                integers.Add(i);
            }
            List<int> randomIntegers = new List<int>(n + 1);
            for (int i = 0; i < integers.Capacity; i++)
            {
                int randomNumber = random.Next(0, integers.Count);
                randomIntegers.Add(integers[randomNumber]);
                integers.RemoveAt(randomNumber);
            }
            foreach (int number in randomIntegers)
            {
                Console.WriteLine(number);
            }
        }
    }

    /// <summary>
    /// Write a program that given two numbers finds their greatest common divisor(GCD) and their least common multiple(LCM). 
    /// You may use the formula LCM(a, b) = |a* b| / GCD(a, b).
    /// </summary>
    public static class Exo17
    {
        public static void Execute()
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            int result = GCD(a, b);
            int lcm = (Math.Abs(a * b)) / result;
            Console.WriteLine($"There GCD is : {result}");
            Console.WriteLine($"There LCM is : {lcm}");
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }
    }

    /// <summary>
    /// Write a program that for a given number n, outputs a matrix in the form of a spiral.
    /// </summary>
    public static class Exo18
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int value = 0;
            int[,] array = new int[n, n];
            int colomn = 0, row = 0;
            while (value < n * n)
            {
                for (int i = 0; i < n; i++)
                {

                }

            }
        }
    } //TODO, Already done in another chapter
}
