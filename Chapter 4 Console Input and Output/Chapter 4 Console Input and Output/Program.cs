using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4_Console_Input_and_Output
{
    class Program
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
            Exo12.Execute();
        }
    }

    /// <summary>
    /// Write a program that reads from the console three numbers of type int and prints their sum.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            Console.WriteLine("Indiquer 3 int : ");
            int a, b, c;
            string outPut = Console.ReadLine();
            a = int.Parse(outPut);
            string outPut2 = Console.ReadLine();
            b = int.Parse(outPut2);
            string outPut3 = Console.ReadLine();
            c = int.Parse(outPut3);
            Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
        }
    }

    /// <summary>
    /// Write a program that reads from the console the radius "r" of a circle and prints its perimeter and area
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Console.Write("Write the radius of a circle : ");
            int radius = int.Parse(Console.ReadLine());
            Console.WriteLine("With a radius r = {0}, the perimeter is {1} and the area is {2}", radius, 2f * (float)Math.PI * radius, radius * radius * (float)Math.PI);
        }
    }

    /// <summary>
    /// A given company has name, address, phone number, fax number, web site and manager.
    /// The manager has name, surname and phone number. 
    /// Write a program that reads information about the company and its manager and then prints it on the console.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            string name, address, phoneNumber, faxNumber, webSite, managerName, managerSurname, managerPhoneNumber;
            Console.Write("What is your company name : ");
            name = Console.ReadLine();
            Console.Write("What is your company address : ");
            address = Console.ReadLine();
            Console.Write("What is your company phone number : ");
            phoneNumber = Console.ReadLine();
            Console.Write("What is your company fax number : ");
            faxNumber = Console.ReadLine();
            Console.Write("What is your company web site : ");
            webSite = Console.ReadLine();
            Console.Write("What is your company manager name : ");
            managerName = Console.ReadLine();
            Console.Write("What is your company manager surname : ");
            managerSurname = Console.ReadLine();
            Console.Write("What is your company manager phone number : ");
            managerPhoneNumber = Console.ReadLine();

            Console.WriteLine("Your company {0} is at the adress {1}. \r\n" +
                "You can their phone at {2} or their fax {3}, or on their web site {4}. \r\n" +
                "The manager is {5} {6}, you can contact it at {7}.", name, address, phoneNumber, faxNumber, webSite, managerName, managerSurname, managerPhoneNumber);

        }
    }

    /// <summary>
    /// Write a program that prints three numbers in three virtual columns on the console.
    /// Each column should have a width of 10 characters and the numbers should be left aligned.
    /// The first number should be an integer in hexadecimal; the second should be fractional positive; and the third – a negative fraction.
    /// The last two numbers have to be rounded to the second decimal place.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            int firstNumber = 25;
            float fractionalPos = 2.165554f;
            float fractionNeg1 = -54154.2684f;
            float fractionNeg2 = 455784.846f;
            Console.WriteLine($"{firstNumber,-10:X} | {fractionalPos,-10:C2} | {fractionNeg1:.00/}{fractionNeg2,-5:.00}");
        }
    }

    /// <summary>
    /// Write a program that reads from the console two integer numbers (int) and prints how many numbers between them exist, such that the remainder of their division by 5 is 0. 
    /// Example: in the range(14, 25) there are 3 such numbers: 15, 20 and 25.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            int number1, number2;
            Console.Write("Write an integer : ");
            string firstInt = Console.ReadLine();
            number1 = int.Parse(firstInt);
            Console.Write("Write an integer : ");
            firstInt = Console.ReadLine();
            number2 = int.Parse(firstInt);

            int minNumber = (number1 <= number2) ? number1 : number2;
            int maxNumber = (minNumber == number2) ? number1 : number2;

            for (int index = minNumber; index < maxNumber; index++)
            {
                if (index % 5 == 0)
                {
                    Console.WriteLine(index);
                }
            }
        }
    }

    /// <summary>
    /// Write a program that reads two numbers from the console and prints the greater of them.
    /// Solve the problem without using conditional statements.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            int number1, number2;
            Console.Write("Write an integer : ");
            string firstInt = Console.ReadLine();
            number1 = int.Parse(firstInt);
            Console.Write("Write an integer : ");
            firstInt = Console.ReadLine();
            number2 = int.Parse(firstInt);
            Console.WriteLine($"The biggest number is : {Math.Max(number1, number2)}");
        }
    }

    /// <summary>
    /// Write a program that reads five integer numbers and prints their sum.
    /// If an invalid number is entered the program should prompt the user to enter another number.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            int number;
            long sum = 0L;
            string text;
            bool varIsInt = false;
            for (int index = 1; index <= 5; index++)
            {
                do
                {
                    Console.Write("Write an integer : ");
                    text = Console.ReadLine();
                    varIsInt = int.TryParse(text, out number);
                    if (!varIsInt)
                        Console.WriteLine("Please, enter an integer !!!");
                } while (!varIsInt);
                sum += number;
                number = 0;
                varIsInt = false;
            }
            Console.WriteLine($"The sum is : {sum}");
        }
    }

    /// <summary>
    /// Write a program that reads five numbers from the console and prints the greatest of them.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            int number1, number2, number3, number4, number5;
            number1 = number2 = number3 = number4 = number5 = 0;
            int biggest;
            string text;
            bool varIsInt = false;
            for (int index = 1; index <= 5; index++)
            {
                do
                {
                    Console.Write("Write an integer : ");
                    text = Console.ReadLine();
                    if (index == 1)
                        varIsInt = int.TryParse(text, out number1);
                    else if (index == 2)
                        varIsInt = int.TryParse(text, out number2);
                    else if (index == 3)
                        varIsInt = int.TryParse(text, out number3);
                    else if (index == 4)
                        varIsInt = int.TryParse(text, out number4);
                    else if (index == 5)
                        varIsInt = int.TryParse(text, out number5);
                    if (!varIsInt)
                        Console.WriteLine("Please, enter an integer !!!");
                } while (!varIsInt);
                varIsInt = false;
            }

            biggest = Math.Max(number1, number2);
            biggest = Math.Max(biggest, number3);
            biggest = Math.Max(biggest, number4);
            biggest = Math.Max(biggest, number5);

            Console.WriteLine($"The biggest numebr is : {biggest}");
        }
    }

    /// <summary>
    /// Write a program that reads an integer number n from the console.     /// After that reads n numbers from the console and prints their sum.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            int number;
            long sum = 0L;
            string text;
            bool varIsInt = false;
            int n = 0;
            Console.Write("How many numbers ?");
            text = Console.ReadLine();
            n = int.Parse(text);
            for (int index = 0; index < n; index++)
            {
                do
                {
                    Console.Write("Write an integer : ");
                    text = Console.ReadLine();
                    varIsInt = int.TryParse(text, out number);
                    if (!varIsInt)
                        Console.WriteLine("Please, enter an integer !!!");
                } while (!varIsInt);
                sum += number;
                number = 0;
                varIsInt = false;
            }
            Console.WriteLine($"The sum is : {sum}");
        }
    }

    /// <summary>
    /// Write a program that reads an integer number n from the console and prints all numbers in the range[1…n], each on a separate line.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            int number = 0;
            string text = "";
            Console.WriteLine("Write an integer : ");
            text = Console.ReadLine();
            number = int.Parse(text);
            for (int index = 1; index <= number; index++)
            {
                Console.WriteLine(index);
            }
        }
    }

    /// <summary>
    /// Write a program that prints on the console the first 100 numbers in the Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            ulong firstNumber = 0;
            ulong secondNumber = 1;
            ulong nextNumber;
            int i = 0;
            Console.WriteLine(firstNumber + " " + i++);
            Console.WriteLine(secondNumber + " " + i++);
            for (int index = 0; index < 98; index++)
            {
                nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
                Console.WriteLine(nextNumber + " " + i++);
            }
        }
    }

    /// <summary>
    /// Write a program that calculates the sum (with precision of 0.001) of the following sequence: 1 + 1/2 - 1/3 + 1/4 - 1/5 + …
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {
            int number = 1;
            float sum = 0;
            do
            {
                if (number % 2 == 0 || number == 1)
                    sum += (1f / (float)number);
                else
                    sum -= (1f / (float)number);
                number++;
            } while (Math.Abs((1f / (float)number) - (1f / ((float)number - 1f))) > 0.001);
            Console.WriteLine($"The sum with a 0.001 precision is : {sum:C3}");
        }
    }
}
