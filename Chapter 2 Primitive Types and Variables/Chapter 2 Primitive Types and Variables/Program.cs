using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_2_Primitive_Types_and_Variables
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
            //Exo13.Execute();
        }
    }

    /// <summary>
    /// Declare several variables by selecting for each one of them the most appropriate of the types sbyte, byte, short, ushort, int, uint, long and ulong in order to assign them the following values: 
    /// 52,130; -115; 4825932; 97; -10000; 20000; 224; 970,700,000; 112; -44; -1,000,000; 1990; 123456789123456789.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            // Declare variables
            ushort unsignedShort = 52130;
            sbyte shortByte = -115;
            int integer = 4825932;
            byte _byte = 97;
            short _short = -10000;
            short _short1 = 20000;
            byte _byte1 = 224;
            int integer1 = 970700000;
            byte _byte2 = 112;
            sbyte shortByte1 = -44;
            int integer2 = -1000000;
            short _short2 = 1990;
            ulong unsignedLong = 123456789123456789;

            // Show variables in console
            Console.WriteLine(unsignedShort.GetType() + " : " + unsignedShort.ToString());
            Console.WriteLine(shortByte.GetType() + " : " + shortByte.ToString());
            Console.WriteLine(integer.GetType() + " : " + integer.ToString());
            Console.WriteLine(_byte.GetType() + " : " + _byte.ToString());
            Console.WriteLine(_short.GetType() + " : " + _short.ToString());
            Console.WriteLine(_short1.GetType() + " : " + _short1.ToString());
            Console.WriteLine(_byte1.GetType() + " : " + _byte1.ToString());
            Console.WriteLine(integer1.GetType() + " : " + integer1.ToString());
            Console.WriteLine(_byte2.GetType() + " : " + _byte2.ToString());
            Console.WriteLine(shortByte1.GetType() + " : " + shortByte1.ToString());
            Console.WriteLine(integer2.GetType() + " : " + integer2.ToString());
            Console.WriteLine(_short2.GetType() + " : " + _short2.ToString());
            Console.WriteLine(unsignedLong.GetType() + " : " + unsignedLong.ToString());
        }
    }

    /// <summary>
    /// Which of the following values can be assigned to variables of type float, double and decimal: 
    /// 5, -5.01, 34.567839023; 12.345; 8923.1234857; 3456.091124875956542151256683467?
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            // Declare variables
            float floatingPointValue = 5f;
            float floatingPointValue1 = -5.01f;
            double doubleValue = 34.567839023;
            float floatingPointValue2 = 12.345f;
            decimal decimalValue = 823.12345857m;
            decimal decimalValue1 = 3456.091124875956542151256683467m; // Too big, even for decimal
           
            // Show variables
            Console.WriteLine(floatingPointValue.GetType() + " : " + floatingPointValue.ToString());
            Console.WriteLine(floatingPointValue1.GetType() + " : " + floatingPointValue1.ToString());
            Console.WriteLine(doubleValue.GetType() + " : " + doubleValue.ToString());
            Console.WriteLine(floatingPointValue2.GetType() + " : " + floatingPointValue2.ToString());
            Console.WriteLine(decimalValue.GetType() + " : " + decimalValue.ToString());
            Console.WriteLine(decimalValue1.GetType() + " : " + decimalValue1.ToString());
        }
    }

    /// <summary>
    /// Write a program, which compares correctly two real numbers with accuracy at least 0.000001.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            bool result = CompareTwoNumbers(5f, 5.00001f);
            Console.WriteLine(result);
        }

        public static bool CompareTwoNumbers(float a, float b)
        {
            return (Math.Abs(a - b) < 0.000001);
        }
    }

    /// <summary>
    /// Initialize a variable of type int with a value of 256 in hexadecimal format(256 is 100 in a numeral system with base 16).
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            int hexadecimal256 = 0x0100;
            Console.WriteLine(hexadecimal256);
        }
    }

    /// <summary>
    /// Declare a variable of type char and assign it as a value the character, which has Unicode code, 72 (use the Windows calculator in order to find hexadecimal representation of 72).
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            char letter = '\u0048';
            Console.WriteLine(letter);
        }
    }

    /// <summary>
    /// Declare a variable isMale of type bool and assign a value to it depending on your gender
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            bool isMale = true;
            Console.WriteLine("Are you a male ? " + isMale);
        }
    }

    /// <summary>
    /// Declare two variables of type string with values "Hello" and "World". 
    /// Declare a variable of type object. 
    /// Assign the value obtained of concatenation of the two string variables(add space if necessary) to this variable.
    /// Print the variable of type object.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            string hello = "Hello";
            string world = "World";
            object sentence = hello + " " + world;
            Console.WriteLine(sentence);
        }
    }

    /// <summary>
    /// Declare two variables of type string and give them values "Hello" and "World". 
    /// Assign the value obtained by the concatenation of the two variables of type string (do not miss the space in the middle) to a variable of type object. 
    /// Declare a third variable of type string and initialize it with the value of the variable of type object (you should use type casting).
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            string hello = "Hello";
            string world = "World";
            object sentence = hello + " " + world;
            Console.WriteLine(sentence);

            string strSentence = (string)sentence; // string strSentence = sentence as string;
            Console.WriteLine(strSentence);
        }
    }

    /// <summary>
    /// Declare two variables of type string and assign them a value “The "use" of quotations causes difficulties.” (without the outer quotes).     /// In one of the variables use quoted string and in the other do not use it.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            string str1 = "The \"use\" of quotations causes difficulties.";
            string str2 = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(str1);
            Console.WriteLine(str2);
        }
    }

    /// <summary>
    /// Write a program to print a figure in the shape of a heart by the sign "o".
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            string oHeart =
                 "     o o       o o\n" +
                 "   o     o   o     o\n" +
                 "  o       o o       o\n" +
                 "  o        o       o\n" +
                 "   o              o\n" +
                 "     o           o\n" +
                 "       o       o\n" +
                 "         o   o\n" +
                 "           o \n";
            Console.WriteLine(oHeart);
        }
    }

    /// <summary>
    /// Write a program that prints on the console isosceles triangle which sides consist of the copyright character "©".
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            string triangleIsocele = 
                "    \u00A9\n" +
                "   \u00A9 \u00A9\n" +
                "  \u00A9   \u00A9\n" +
                " \u00A9     \u00A9\n" +
                "\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\n";
            Console.WriteLine(triangleIsocele);
        }
    }

    /// <summary>
    /// A company dealing with marketing wants to keep a data record of its employees.
    /// Each record should have the following characteristic – first name, last name, age, gender(‘m’ or ‘f’) and unique employee number (27560000 to 27569999). 
    /// Declare appropriate variables needed to maintain the information for an employee by using the appropriate data types and attribute names.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {
            string firstName = "Benjamin";
            string lastName = "Peter";
            byte age = 19;
            char gender = 'm';
            int employeeNumber = 27569316;
        }
    }

    /// <summary>
    /// Declare two variables of type int. 
    /// Assign to them values 5 and 10 respectively.
    /// Exchange(swap) their values and print them.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {
            int five = 5;
            int ten = 10;

            int tempVar = five;
            five = ten;
            ten = tempVar;

            Console.WriteLine($"Five vaut mtn : {five}");
            Console.WriteLine($"Ten vaut mtn : {ten}");
        }
    }
}
