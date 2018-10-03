using System;
using System.Collections.Generic;
using Chapter_11_Creating_Using_Object.CreatingAndUsingObjects;

namespace Chapter_11_Creating_Using_Object
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
            Exo12.Execute();
        }
    }

    /// <summary>
    /// Write a program, which reads from the console a year and checks if it is a leap year.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            Console.Write("Write a year : ");
            int year = int.Parse(Console.ReadLine());
            if (year % 4 != 0)
                Console.WriteLine("The year " + year + " is a common year");
            else if (year % 100 != 0)
                Console.WriteLine("The year " + year + " is a leap year");
            else if (year % 400 != 0)
                Console.WriteLine("The year " + year + " is a common year");
            else
                Console.WriteLine("The year " + year + " is a leap year");
            bool isLeapYear = DateTime.IsLeapYear(year);
            if (isLeapYear)
                Console.WriteLine("The year " + year + " is a leap year");
            else
                Console.WriteLine("The year " + year + " is a common year");
        }
    }

    /// <summary>
    /// Write a program, which generates and prints on the console 10 random numbers in the range [100, 200].
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int number = random.Next(100, 201);
                Console.WriteLine("Number " + i + " : " + number);
            }
        }
    }

    /// <summary>
    /// Write a program, which prints, on the console which day of the week is today.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            string today = DateTime.Now.DayOfWeek.ToString();
            Console.WriteLine("Today is " + today);
        }
    }

    /// <summary>
    /// Write a program, which prints on the standard output the count of days, hours, and minutes, which have passes since the computer is started until the moment of the program execution.
    /// For the implementation use the class Environment.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            float tickCount = Environment.TickCount;
            float seconds = tickCount / 1000f;
            float minutes = seconds / 60f;
            float hours = minutes / 60f;
            int days = (int)Math.Floor(hours / 24f);

            Console.WriteLine("The PC is started until " + days + " day(s) " + (int)Math.Floor(hours % 24) + " hour(s) " + (int)Math.Floor(minutes % 60) + " minute(s) ");
        }
    }

    /// <summary>
    /// Write a program which by given two sides finds the hypotenuse of a right triangle. 
    /// Implement entering of the lengths of the sides from the standard input, and for the calculation of the hypotenuse use methods of the class Math.
    /// </summary>
    public static class Exo5
    { 
        public static void Execute()
        {
            Console.WriteLine("Give two sides of a right triangle : ");
            Console.Write("Side A = ");
            float sideA = float.Parse(Console.ReadLine());
            Console.Write("Side B = ");
            float sideB = float.Parse(Console.ReadLine());
            double hypotenuse = Math.Sqrt((sideA * sideA) + (sideB * sideB));
            Console.WriteLine("The hypotenuse is : " + hypotenuse);
        }
    }

    /// <summary>
    /// Write a program which calculates the area of a triangle with the following given:
    ///- three sides;
    ///- side and the altitude to it;
    ///- two sides and the angle between them in degrees.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            float result1 = TriangleArea(3, 4);
            float result2 = TriangleArea(3, 4, 5);
            float result3 = TriangleAreaWithAngle(3, 4, 90);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }

        static float TriangleArea(float sideA, float sideB, float sideC)
        {
            float perimiter = sideA + sideB + sideC;
            float semiPerimiter = perimiter / 2f;
            float sum = semiPerimiter * (semiPerimiter - sideA) * (semiPerimiter - sideB) * (semiPerimiter - sideC);
            float result = (float)Math.Sqrt(sum);
            return result;
        }
        static float TriangleAreaWithAngle(float sideA, float sideB, float angle)
        {
            float result = ((sideA * sideB) / 2f) * (float)Math.Sin(angle * (Math.PI / 180f));
            return result;
        }
        static float TriangleArea(float side, float hauteur)
        {
            float result = side * hauteur;
            result /= 2f;
            return result;
        }
    }

    /// <summary>
    /// Define your own namespace CreatingAndUsingObjects and place in it two classes Cat and Sequence, which we used in the examples of the current chapter. 
    /// Define one more namespace and make a class, which calls the classes Cat and Sequence, in it.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            Cat catou = new Cat();
            Sequence.NextValue();
        }
    }

    namespace CreatingAndUsingObjects
    {
        public class Cat
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string color;
            public string Color
            {
                get { return color; }
                set { color = value; }
            }

            public Cat()
            {
                name = "Unnamed";
                color = "gray";
            }
            public Cat(string name, string color)
            {
                this.name = name;
                this.color = color;
            }

            public void SayMiau()
            {
                Console.WriteLine("Cat {0} said : Miauuuuuu!", name);
            }
        }

        public class Sequence
        {
            private static int currentValue = 0;

            private Sequence()
            {

            }

            public static int NextValue()
            {
                currentValue++;
                return currentValue;
            }
        }
    }

    /// <summary>
    /// Write a program which creates 10 objects of type Cat, gives them names CatN, where N is a unique serial number of the object, and in the end call the method SayMiau() for each of them. 
    /// For the implementation use the namespace CreatingAndUsingObjects.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            for (int i = 0; i < 10; i++)
            {
                Cat catou = new Cat("Cat" + Sequence.NextValue(), "Noir");
                catou.SayMiau();
            }
        }
    }

    /// <summary>
    /// Write a program, which calculates the count of workdays between the current date and another given date after the current (inclusive). 
    /// Consider that workdays are all days from Monday to Friday, which are not public holidays, except when Saturday is a working day. 
    /// The program should keep a list of predefined public holidays, as well as a list of predefined working Saturdays.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Console.WriteLine("Write a day : ");
            Console.Write("Year : ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Month : ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Day : ");
            int day = int.Parse(Console.ReadLine());

            bool skip = false;
            int workdays = 0;
            DateTime date = new DateTime(year, month, day);
            DateTime currentDate = DateTime.Today;

            DateTime[] holidays = new DateTime[1]
                {
                    new DateTime(0,7,7)
                };
            DateTime[] workingSaturdays = new DateTime[0];

            while (currentDate != date)
            {
                skip = false;
                foreach (DateTime holiday in holidays)
                {
                    if (currentDate.Day == holiday.Day && currentDate.Month == holiday.Month)
                    {
                        skip = true;
                        break;
                    }
                }
                if (!skip)
                {
                    currentDate.AddDays(1);
                    continue;
                }
                foreach (DateTime workingSaturday in workingSaturdays)
                {
                    if (currentDate.Day == workingSaturday.Day && currentDate.Month == workingSaturday.Month)
                    {
                        skip = true;
                        workdays++;
                        break;
                    }
                }
                if (!skip)
                {
                    currentDate.AddDays(1);
                    continue;
                }

                switch (currentDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        workdays++;
                        break;
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                    default:
                        break;
                }
                currentDate.AddDays(1);
            }
        }
    }

    /// <summary>
    /// You are given a sequence of positive integer numbers given as string of numbers separated by a space. 
    /// Write a program, which calculates their sum. 
    /// Example: "43 68 9 23 318" => 461.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            Console.WriteLine("Write a sequence of integers");
            string sequences = Console.ReadLine();
            List<int> numbers = new List<int>();
            string currentNumber = "";
            for (int i = 0; i < sequences.Length; i++)
            {
                if (sequences[i] != ' ')
                {
                    currentNumber += sequences[i];
                }
                else if (currentNumber != "")
                {
                    numbers.Add(int.Parse(currentNumber));
                    currentNumber = "";
                }
                if (i == sequences.Length - 1 && currentNumber != "")
                {
                    numbers.Add(int.Parse(currentNumber));
                }
            }
            int result = 0;
            foreach (int number in numbers)
            {
                result += number;
            }
            Console.WriteLine("The result is : " + result);
        }
    }

    /// <summary>
    /// Write a program, which generates a random advertising message for some product. 
    /// The message has to consist of laudatory phrase, followed by a laudatory story, followed by author (first and last name) and city, which are selected from predefined lists. 
    /// For example, let’s have the following lists:
    /// - Laudatory phrases: {"The product is excellent.", "This is a great product.", "I use this product constantly.", "This is the best product from this category."}.
    /// - Laudatory stories: {"Now I feel better.", "I managed to change.", "It made some miracle.", "I can’t believe it, but now I am feeling great.", "You should try it, too. I am very satisfied."}.
    /// - First name of the author: {"Dayan", "Stella", "Hellen", "Kate"}.
    /// - Last name of the author: {"Johnson", "Peterson", "Charls"}.
    /// - Cities: {"London", "Paris", "Berlin", "New York", "Madrid"}
    /// Then the program would print randomly generated advertising message.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            string[] phrases = new string[4]
            {
                "The product is excellent.",
                "This is a great product.",
                "I use this product constantly.",
                "This is the best product from this category."
            };
            string[] stories = new string[5]
            {
                "Now I feel better.",
                "I managed to change.",
                "It made some miracle.",
                "I can’t believe it, but now I am feeling great.",
                "You should try it, too. I am very satisfied."
            };
            string[] firstNames = new string[4]
            {
                "Dayan",
                "Stella",
                "Hellen",
                "Kate"
            };
            string[] lastNames = new string[3]
            {
                "Johnson",
                "Peterson",
                "Charls"
            };
            string[] cities = new string[5]
            {
                "London",
                "Paris",
                "Berlin",
                "New York",
                "Madrid"
            };
            for (int i = 0; i < 20; i++)
                PrintRandomAdvertising(phrases, stories, firstNames, lastNames, cities);
        }

        static void PrintRandomAdvertising(string[] phrases, string[] stories, string[] firstName, string[] lastNames, string[] cities)
        {
            string advertisingMessage = "";
            int randomIndex = 0;

            //Add phrases
            randomIndex = random.Next(0, phrases.Length);
            advertisingMessage += phrases[randomIndex] + " ";

            //Add stories
            randomIndex = random.Next(0, stories.Length);
            advertisingMessage += stories[randomIndex] + "\n -- ";

            //Add firstName
            randomIndex = random.Next(0, firstName.Length);
            advertisingMessage += firstName[randomIndex] + " ";

            //Add lastName
            randomIndex = random.Next(0, lastNames.Length);
            advertisingMessage += lastNames[randomIndex] + ", ";

            //Add city
            randomIndex = random.Next(0, cities.Length);
            advertisingMessage += cities[randomIndex] + " ";

            Console.WriteLine(advertisingMessage);
        }
    }

    /// <summary>
    /// Write a program, which calculates the value of a given numeral expression given as a string. 
    /// The numeral expression consists of:
    /// - real numbers, for example 5, 18.33, 3.14159, 12.6;
    /// - arithmetic operations: +, -, *, / (with their standard priorities);
    /// - mathematical functions: ln(x), sqrt(x), pow(x, y);
    /// - brackets for changing the priorities of the operations: (and ).
    /// Note that the numeral expressions have priorities, for example the expression -1 + 2 + 3 * 4 - 0.5 = (-1) + 2 + (3 * 4) - 0.5 = 12.5.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {

        }
    } //TODO
}
