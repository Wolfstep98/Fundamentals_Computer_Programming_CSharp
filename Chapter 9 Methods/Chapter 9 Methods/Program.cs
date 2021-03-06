﻿using System;
using System.Numerics;

namespace Chapter_9_Methods
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exo1.Execute();
            //Exo2.Execute();
            //Exo3.Execute();
            //Exo4.Execute();
            //Exo5.Execute();
            //Exo6.Execute();
            //Exo7.Execute();
            //Exo8.Execute();
            //Exo9.Execute();
            //Exo10.Execute();
            //Exo11.Execute();
            //Exo12.Execute();
            Exo13.Execute();
        }
    }

    /// <summary>
    /// Write a code that by given name prints on the console "Hello, <name>!". 
    /// Example: "Hello, Peter!".
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            Console.Write("What's your name ? ");
            string name = Console.ReadLine();
            PrintName(name);
        }

        /// <summary>
        /// Print <paramref name="name"/> on console.
        /// </summary>
        /// <param name="name">Name.</param>
        private static void PrintName(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }

    /// <summary>
    /// Create a method GetMax() with two integer (int) parameters, that returns maximal of the two numbers. 
    /// Write a program that reads three numbers from the console and prints the biggest of them. 
    /// Use the GetMax() method you just created. 
    /// Write a test program that validates that the methods works correctly.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Console.WriteLine("Write 3 numbers :");
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            //int result = Math.Max(Math.Max(number1, number2), number3);
            int biggestNumber = GetMax(number1, number2, number3);
            Console.WriteLine($"The biggest number is {biggestNumber}");
        }

        // Return larger value between a and b.
        static int GetMax(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Return larger value between a, b and c.
        static int GetMax(int a, int b, int c)
        {
            return GetMax(GetMax(a, b), c);
        }
    }

    /// <summary>
    /// Write a method that returns the English name of the last digit of a given number. 
    /// Example: for 512 prints "two"; for 1024 => "four".
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            Random random = new Random();
            int number = random.Next();
            string englishName = GetEnglishNameOfLastDigit(number);
            Console.WriteLine($"The english name of the last digit of the number {number} is : {englishName}");
        }

        static string GetEnglishNameOfLastDigit(int number)
        {
            string digits = number.ToString();
            string digitName = GetEnglishName(digits[digits.Length - 1] - '0');
            return digitName;
        }

        static string GetEnglishName(int digit)
        {
            string result = "";
            switch (digit)
            {
                case 0:
                    result = "Zero";
                    break;
                case 1:
                    result = "One";
                    break;
                case 2:
                    result = "Two";
                    break;
                case 3:
                    result = "Three";
                    break;
                case 4:
                    result = "Four";
                    break;
                case 5:
                    result = "Five";
                    break;
                case 6:
                    result = "Six";
                    break;
                case 7:
                    result = "Seven";
                    break;
                case 8:
                    result = "Eight";
                    break;
                case 9:
                    result = "Nine";
                    break;
                default:
                    Console.WriteLine("The last digit is not a number");
                    break;
            }
            return result;
        }
    }

    /// <summary>
    /// Write a method that finds how many times certain number can be found in a given array. 
    /// Write a program to test that the method works correctly.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            Random random = new Random();
            Console.Write("Write a number : ");
            int numberToFind = int.Parse(Console.ReadLine());
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 10);
                Console.Write(numbers[i] + "|");
            }
            Console.WriteLine();
            int nbrOfTime = Contains(numberToFind, numbers);
            Console.WriteLine($"The number {numberToFind} is in the array {nbrOfTime} times");
        }

        static int Contains(int number, params int[] numbers)
        {
            int numberOfTime = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (number == numbers[i])
                    numberOfTime++;
            }
            return numberOfTime;
        }
    }

    /// <summary>
    /// Write a method that checks whether an element, from a certain position in an array is greater than its two neighbors. 
    /// Test whether the method works correctly.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            Random random = new Random();

            Console.Write("Write a index between 0 and 19: ");
            int index = int.Parse(Console.ReadLine());
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 20);
                Console.Write(numbers[i] + "|");
            }
            Console.WriteLine();
            bool greaterThanNeighbors = GreaterThanNeighbors(index, numbers);
            Console.WriteLine($"The number at the index {index} is greater than his neighbors ? {greaterThanNeighbors}");
        }

        public static bool GreaterThanNeighbors(int position, params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine("The array is empty");
                return false;
            }
            if (numbers.Length == 1)
                return true;
            if (position < 0 || position >= numbers.Length)
            {
                Console.WriteLine("Write a correct position");
                return false;
            }
            if (position == 0)
            {
                if (numbers[position] > numbers[position + 1])
                    return true;
                else
                    return false;
            }
            else if (position == numbers.Length - 1)
            {

                if (numbers[position] > numbers[position - 1])
                    return true;
                else
                    return false;
            }
            else
            {
                if (numbers[position] > numbers[position - 1] && numbers[position] > numbers[position + 1])
                    return true;
                else
                    return false;
            }
        }
    }

    /// <summary>
    /// Write a method that returns the position of the first occurrence of an element from an array, such that it is greater than its two neighbors simultaneously. 
    /// Otherwise the result must be -1.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Random random = new Random();

            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 20);
                Console.Write(numbers[i] + "|");
            }
            Console.WriteLine();
            int index = FirstIndexWithElementsGreaterThanNeighbors(numbers);
            Console.WriteLine($"The first index is {index}");
        }

        static int FirstIndexWithElementsGreaterThanNeighbors(params int[] numbers)
        {
            int result = -1;
            for (int index = 0; index < numbers.Length; index++)
            {
                if (Exo5.GreaterThanNeighbors(index, numbers))
                {
                    result = index;
                    break;
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Write a method that prints the digits of a given decimal number in a reversed order. 
    /// For example 256, must be printed as 652.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            Console.Write("Write a number : ");
            int number = int.Parse(Console.ReadLine());
            PrintReverseNumber(number);
        }

        static void PrintReverseNumber(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                Console.Write(digit);
                number /= 10;
            }
            Console.WriteLine();

        }
    }

    /// <summary>
    /// Write a method that calculates the sum of two very long positive integer numbers. 
    /// The numbers are represented as array digits and the last digit (the ones) is stored in the array at index 0. 
    /// Make the method work for all numbers with length up to 10,000 digits.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            Random random = new Random();

            int[] a = new int[random.Next(0, 100)];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(0, 9);
                Console.Write(a[i]);
                if (i % 3 == 0)
                    Console.Write(" ");
            }
            int[] b = new int[random.Next(0, 100)];
            Console.WriteLine();
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = random.Next(0, 9);
                Console.Write(b[i]);
                if (i % 3 == 0)
                    Console.Write(" ");
            }
            Console.WriteLine();

            int[] sum = Add(a, b);
            Console.WriteLine("The result is : ");
            for (int i = 0; i < sum.Length; i++)
            {
                Console.Write(sum[i]);
                if (i % 3 == 0)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }

        static int[] Add(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                if (a.Length > b.Length)
                {
                    int[] bTemp = new int[a.Length];
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (i < b.Length)
                            bTemp[i] = b[i];
                        else
                            bTemp[i] = 0;
                    }
                    b = bTemp;
                }
                else
                {
                    int[] aTemp = new int[b.Length];
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (i < a.Length)
                            aTemp[i] = a[i];
                        else
                            aTemp[i] = 0;
                    }
                    a = aTemp;
                }
            }
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (i > 0)
                    result[i] = (a[i] + b[i]) % 10 + (a[i - 1] + b[i - 1]) / 10;
                else
                    result[i] = (a[i] + b[i]) % 10;
            }
            return result;
        }
    }

    /// <summary>
    /// Write a method that finds the biggest element of an array. 
    /// Use that method to implement sorting in descending order.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Random random = new Random();

            int[] a = new int[random.Next(0, 100)];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(0, 50);
                Console.Write(a[i] + "|");
            }
            Console.WriteLine();
            SortDescendingOrder(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + "|");
            }
            Console.WriteLine();
        }

        static int BiggestNumber(int index, int[] numbers)
        {
            int max = index;
            for (int i = index + 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[max])
                    max = i;
            }
            return max;
        }

        static int BiggestNumber(int[] numbers)
        {
            int result = BiggestNumber(0, numbers);
            return result;
        }

        static void SortDescendingOrder(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int indexBiggestNumber = BiggestNumber(i, numbers);
                if (indexBiggestNumber != i)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[indexBiggestNumber];
                    numbers[indexBiggestNumber] = temp;
                }
            }
        }
    }

    /// <summary>
    /// Write a program that calculates and prints the n! for any n in the range [1…100].
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            Console.Write("Write an integer in the range 1 to 100 : ");
            int n = int.Parse(Console.ReadLine());
            BigInteger result = NFactorial(n);
            Console.WriteLine($"{n}! = {result}");
        }

        static BigInteger NFactorial(int n)
        {
            BigInteger result = 1;
            for (int i = n; i > 1; i--)
            {
                result *= i;
            }
            return result;
        }
    }

    /// <summary>
    /// Write a program that solves the following tasks:
    /// - Put the digits from an integer number into a reversed order.
    /// - Calculate the average of given sequence of numbers.
    /// - Solve the linear equation a* x + b = 0.
    /// Create appropriate methods for each of the above tasks.
    /// Make the program show a text menu to the user. 
    /// By choosing an option of that menu, the user will be able to choose which task to be invoked.
    /// Perform validation of the input data:
    /// - The integer number must be a positive in the range [1…50,000,000].
    /// - The sequence of numbers cannot be empty.
    /// - The coefficient a must be non-zero.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            Console.WriteLine("Choose a following tasks : ");
            Console.WriteLine("1 - Put the digits from an integer number into a reversed order.");
            Console.WriteLine("2 - Calculate the average of given sequence of numbers.");
            Console.WriteLine("3 - Solve the linear equation a * x + b = 0.");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Write a positive integer : ");
                    int number = int.Parse(Console.ReadLine());
                    int result = ReverseInteger(number);
                    Console.WriteLine($"The number {number} => {result} is reversed");
                    break;
                case 2:
                    Console.Write("How many numbers do you want to write ? ");
                    int lenght = int.Parse(Console.ReadLine());
                    float[] numbers = new float[lenght];
                    for (int i = 0; i < lenght; i++)
                    {
                        Console.Write($"Number n°{i + 1}/{lenght} : ");
                        numbers[i] = float.Parse(Console.ReadLine());
                    }
                    float average = Average(numbers);
                    Console.WriteLine("The average is {0}", average);
                    break;
                case 3:
                    Console.WriteLine("Write a linear equation like : a * x + b");
                    Console.Write("Write a = ");
                    float a = float.Parse(Console.ReadLine());
                    Console.Write("Write b = ");
                    float b = float.Parse(Console.ReadLine());
                    float x = FindXEqual0(a, b);
                    Console.WriteLine($"The equation {a}x + {b} is equal to 0 at x = {x}");
                    break;
                default:
                    Console.WriteLine("Please, enter a correct number");
                    break;
            }
        }

        static int ReverseInteger(int number)
        {
            if (number < 1)
            {
                Console.WriteLine("Error, write a positive number in range 1...50,000,000");
                return -1;
            }
            int reversedNumber = 0;
            int temp = number;
            int multiple = 1;
            while (temp > 9)
            {
                temp /= 10;
                multiple *= 10;
            }
            while (number > 0)
            {
                reversedNumber += (number % 10) * multiple;
                number /= 10;
                multiple /= 10;
            }
            return reversedNumber;
        }

        static float Average(params float[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine("Error, the array is empty");
                return 0;
            }
            int lenght = numbers.Length;
            float sum = 0;
            float result = 0;
            for (int i = 0; i < lenght; i++)
            {
                sum += numbers[i];
            }
            result = sum / lenght;
            return result;
        }

        static float FindXEqual0(float a, float b = 0)
        {
            if (a == 0)
            {
                Console.WriteLine("Error, write a different than zero");
                return 0;
            }
            float result = 0;
            if (b != 0)
            {
                result = -b / a;
            }
            return result;
        }
    }

    /// <summary>
    /// Write a method that calculates the sum of two polynomials with integer coefficients, for example (3x² + x - 3) + (x - 1) = (3x² + 2x - 4).
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {
            Console.WriteLine("Write 2 polynomials :");
            Console.WriteLine("ax² + bx + c :");
            Console.Write("a = ");
            int a1 = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b1 = int.Parse(Console.ReadLine());
            Console.Write("c = ");
            int c1 = int.Parse(Console.ReadLine());

            int[] polynomial1 = new int[3]
            {
                a1,
                b1,
                c1
            };

            Console.WriteLine("ax² + bx + c :");
            Console.Write("a = ");
            int a2 = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b2 = int.Parse(Console.ReadLine());
            Console.Write("c = ");
            int c2 = int.Parse(Console.ReadLine());
            int[] polynomial2 = new int[3]
            {
                a2,
                b2,
                c2
            };

            int[] result = AddPolynomials(polynomial1, polynomial2);
            Console.WriteLine($"({polynomial1[0]}x² + {polynomial1[1]}x + {polynomial1[2]}) +({polynomial2[0]}x² + {polynomial2[1]}x + {polynomial2[2]}) = {result[0]}x² + {result[1]}x + {result[2]}");
        }

        static int[] AddPolynomials(int[] a, int[] b)
        {
            int[] result = new int[3] { 0, 0, 0 };
            result[0] = a[0] + b[0];
            result[1] = a[1] + b[1];
            result[2] = a[2] + b[2];
            return result;
        }
    }

    /// <summary>
    /// Write a method that calculates the product of two polynomials with integer coefficients, for example (3x² + x - 3) * (x - 1) = (3x^3 - 2x² - 4x + 3).
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {

        }
    } //TODO
}
