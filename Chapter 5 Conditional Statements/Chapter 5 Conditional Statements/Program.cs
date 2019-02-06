using System;

namespace Chapter_5_Conditional_Statements
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exo1.Execute();
            Exo2.Execute();
            Exo3.Execute();
            Exo4.Execute();
            Exo5.Execute();
            Exo6.Execute();
            Exo7.Execute();
            Exo8.Execute();
            Exo9.Execute();
            Exo10.Execute();
            Exo11.Execute();
        }
    }

    /// <summary>
    /// Write an if-statement that takes two integer variables and exchanges their values if the first one is greater than the second one.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            int firstVar = 210;
            int secondVar = 55;
            if (firstVar > secondVar)
            {
                firstVar ^= secondVar;
                secondVar ^= firstVar;
                firstVar ^= secondVar;
            }

            Console.WriteLine(firstVar + " " + secondVar);
        }
    }

    /// <summary>
    /// Write a program that shows the sign (+ or -) of the product of three real numbers, without calculating it. 
    /// Use a sequence of if operators.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            int value1 = 486;
            int value2 = -5416;
            int value3 = 48;
            string sign = "";

            if (value1 == 0 || value2 == 0 || value3 == 0)
            {
                sign = "+";
            }
            else
            {
                if ((value1 > 0 && value2 > 0 && value3 > 0) || ((value2 < 0 && value1 < 0) && value3 > 0) || ((value3 < 0 && value1 < 0) && value2 > 0) || ((value2 < 0 && value3 < 0) && value1 > 0))
                {
                    sign = "+";
                }
                else if (((value2 > 0 && value1 > 0) && value3 < 0) || ((value3 > 0 && value1 > 0) && value2 < 0) || ((value2 > 0 && value3 > 0) && value1 < 0) || (value1 < 0 && value2 < 0 && value3 < 0))
                {
                    sign = "-";
                }
            }

            Console.WriteLine(sign);
        }
    }

    /// <summary>
    /// Write a program that finds the biggest of three integers, using nested if statements.
    /// </summary>
    public static class Exo3
    { 
        public static void Execute()
        {
            int value1 = 486;
            int value2 = -5416;
            int value3 = 48;
            int biggestValue = 0;

            if(value1 > value2)
            {
                if(value2 > value3)
                {
                    biggestValue = value1;
                }
                else
                {
                    if(value1 > value3)
                    {
                        biggestValue = value1;
                    }
                    else
                    {
                        biggestValue = value3;
                    }
                }
            }
            else
            {
                if(value1 > value3)
                {
                    biggestValue = value2;
                }
                else
                {
                    if (value2 > value3)
                    {
                        biggestValue = value2;
                    }
                    else
                    {
                        biggestValue = value3;
                    }
                }
            }

            //biggestValue = value1;
            //if (value2 > biggestValue)
            //    biggestValue = value2;
            //if (value3 > biggestValue)
            //    biggestValue = value3;

            Console.WriteLine(biggestValue);
        }
    }

    /// <summary>
    /// Sort 3 real numbers in descending order. 
    /// Use nested if statements.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            int value1 = -486;
            int value2 = -5;
            int value3 = -48;

            if (value2 < value3)
            {
                value2 ^= value3;
                value3 ^= value2;
                value2 ^= value3;
            }
            if (value1 < value2)
            {
                value1 ^= value2;
                value2 ^= value1;
                value1 ^= value2;
            }
            if (value2 < value3)
            {
                value2 ^= value3;
                value3 ^= value2;
                value2 ^= value3;
            }

            Console.WriteLine($"{value1} {value2} {value3}");
        }
    }

    /// <summary>
    /// Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English). 
    /// Use a switch statement.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            int number = -1;
            number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case -1:
                    Console.WriteLine("Write a correct integer pls");
                    break;
                case 0:
                    Console.WriteLine("Zero");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                case 3:
                    Console.WriteLine("Three");
                    break;
                case 4:
                    Console.WriteLine("Four");
                    break;
                case 5:
                    Console.WriteLine("Five");
                    break;
                case 6:
                    Console.WriteLine("Six");
                    break;
                case 7:
                    Console.WriteLine("Seven");
                    break;
                case 8:
                    Console.WriteLine("Eight");
                    break;
                case 9:
                    Console.WriteLine("Nine");
                    break;
                default:
                    Console.WriteLine("Write an smaller integer pls");
                    break;
            }
        }
    }

    /// <summary>
    /// Write a program that gets the coefficients a, b and c of a quadratic equation: ax2 + bx + c, calculates and prints its real roots (if they exist). 
    /// Quadratic equations may have 0, 1 or 2 real roots.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            float a = 4f;
            float b = 5f;
            float c = 0f;

            float discriminant = (b * b) - (4.0f * a * c);
            if (discriminant == 0)
            {
                float x = -b / (2f * a);
                Console.WriteLine($"There is one real roots, and it's on x = {x} !");
            }
            else if (discriminant > 0)
            {
                float x1 = (-b + (float)Math.Sqrt(discriminant)) / (2f * a);
                float x2 = (-b - (float)Math.Sqrt(discriminant)) / (2f * a);
                Console.WriteLine($"There is two real roots, and it's on x1 = {x1} and x2 = {x2} !");
            }
            else
            {
                Console.WriteLine("There is no real roots !");
            }
        }
    }

    /// <summary>
    /// Write a program that finds the greatest of given 5 numbers.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            float value1 = 2321f;
            float value2 = -231f;
            float value3 = 31f;
            float value4 = -231f;
            float value5 = 234541f;

            float maxValue = value1;
            maxValue = Math.Max(maxValue, value2);
            maxValue = Math.Max(maxValue, value3);
            maxValue = Math.Max(maxValue, value4);
            maxValue = Math.Max(maxValue, value5);

            Console.WriteLine($"The max value is {maxValue}");
        }
    }

    /// <summary>
    /// Write a program that, depending on the user’s choice, inputs int, double or string variable. 
    /// If the variable is int or double, the program increases it by 1. 
    /// If the variable is a string, the program appends "*" at the end. 
    /// Print the result at the console. 
    /// Use switch statement.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            Console.Write("Write something : ");
            string text = Console.ReadLine();
            int valueType = 0;
            int number = 0;
            float floatingNumber = 0f;
            if (int.TryParse(text, out number))
            {
                valueType = 1;
            }
            else if (float.TryParse(text, out floatingNumber))
            {
                valueType = 2;
            }
            else
            {
                valueType = 3;
            }
            switch (valueType)
            {
                case 1:
                    number++;
                    Console.WriteLine($"The value is {number}");
                    break;
                case 2:
                    floatingNumber += 1f;
                    Console.WriteLine($"The value is {floatingNumber}");
                    break;
                case 3:
                    text += "*";
                    Console.WriteLine($"The value is {text}");
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// We are given 5 integer numbers. Write a program that finds those subsets whose sum is 0. 
    /// Examples:
    /// - If we are given the numbers {3, -2, 1, 1, 8}, the sum of -2, 1 and 1 is 0.
    /// - If we are given the numbers {3, 1, -7, 35, 22}, there are no subsets with sum 0.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {

        }
    } //TODO

    /// <summary>
    /// Write a program that applies bonus points to given scores in the range [1…9] by the following rules:
    ///- If the score is between 1 and 3, the program multiplies it by 10.
    ///- If the score is between 4 and 6, the program multiplies it by 100.
    ///- If the score is between 7 and 9, the program multiplies it by 1000.
    ///- If the score is 0 or more than 9, the program prints an error message.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            Console.Write("Write an integer between 1 and 9 : ");
            int number = 0;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number > 0 && number <= 9)
                {
                    switch (number)
                    {
                        case 1:
                        case 2:
                        case 3:
                            number *= 10;
                            break;
                        case 4:
                        case 5:
                        case 6:
                            number *= 100;
                            break;
                        case 7:
                        case 8:
                        case 9:
                            number *= 1000;
                            break;

                    }
                    Console.WriteLine("The score is : {0}", number);
                }
                else
                {
                    Console.WriteLine("Error message !");
                }

            }
            else
            {
                Console.WriteLine("Please write an integer !");
            }
        }
    }

    /// <summary>
    /// Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation. Examples:
    ///- 0 --> "Zero"
    ///- 12 --> "Twelve"
    ///- 98 --> "Ninety eight"
    ///- 273 --> "Two hundred seventy three"
    ///- 400 --> "Four hundred"
    ///- 501 --> "Five hundred and one"
    ///- 711 --> "Seven hundred and eleven"
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {

        }
    } //TODO
}
