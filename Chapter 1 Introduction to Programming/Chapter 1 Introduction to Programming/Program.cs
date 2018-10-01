using System;

namespace Chapter_1_Introduction_to_Programming
{
    public class Program
    {
        static void Main(string[] args)
        {
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
    /// Compile and execute the sample program from this chapter using the command prompt(the console) and Visual Studio.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            Console.WriteLine("Hello World !");
        }
    }

    /// <summary>
    /// Modify the sample program to print a different greeting, for example "Good Day!"
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            Console.WriteLine("Good Day!");
        }
    }

    /// <summary>
    /// Write a console application that prints your first and last name on the console.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Console.WriteLine("Benjamin Peter");
        }
    }

    /// <summary>
    /// Write a program that prints the following numbers on the console 1, 101, 1001, each on a new line
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            Console.WriteLine("1");
            Console.WriteLine("101");
            Console.WriteLine("1001");
        }
    }

    /// <summary>
    /// Write a program that prints on the console the current date and time.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            Console.WriteLine(DateTime.Now);
        }
    }

    /// <summary>
    /// Write a program that prints the square root of 12345.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Console.WriteLine(Math.Sqrt(12345));
        }
    }

    /// <summary>
    /// Write a program that prints the first 100 members of the sequence 2, -3, 4, -5, 6, -7, 8.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            for(int i = 2; i < 102;i++)
            {
                Console.WriteLine((i * ((i%2 == 0)?1:-1)));
            }
        }
    }

    /// <summary>
    /// Write a program that reads your age from the console and prints your age after 10 years.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            Console.WriteLine("Write your age : ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine((age + 10));
        }
    }
}
