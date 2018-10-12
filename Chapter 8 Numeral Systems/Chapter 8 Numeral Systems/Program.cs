using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_8_Numeral_Systems
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
            Exo13.Execute();
            Exo14.Execute();
            Exo15.Execute();
        }
    }

    public static class Converter
    {
        public static char[] DecimalToBinary(int number)
        {
            if (number == 0)
                return new char[] { '0' };
            string binary = "";
            while (number > 0)
            {
                int reste = number % 2;
                binary += reste.ToString();
                number /= 2;
            }
            IEnumerable<char> bin = binary.Reverse();
            return binary.ToCharArray();
        }

        public static string DecimalToBinary2(int number)
        {
            if (number == 0)
                return "0";
            string binary = "";
            while (number > 0)
            {
                int reste = number % 2;
                binary += reste.ToString();
                number /= 2;
            }
            IEnumerable<char> bin = binary.Reverse();
            char[] temp = bin.ToArray<char>();
            StringBuilder builder = new StringBuilder(temp.Length);
            builder.Append(temp);
            return builder.ToString();
        }

        public static int BinaryToDecimal(char[] binaries)
        {
            int number = 0;
            for (int i = 0; i < binaries.Length; i++)
            {
                number += (binaries[i] == '1') ? (int)Math.Pow(2, binaries.Length - 1 - i) : 0;
            }
            return number;
        }

        public static int BinaryToDecimal(string binaries)
        {
            return BinaryToDecimal(binaries.ToArray());
        }

        public static int BinaryToDecimalHorner(string binary)
        {
            int result = 0;
            if (binary == "0" || binary == "1")
                return int.Parse(binary);
            int temp = int.Parse(binary[0].ToString()) * 2 + int.Parse(binary[1].ToString());
            if (binary.Length == 2)
                return temp;
            for (int i = 2; i < binary.Length; i++)
            {
                temp *= 2 + int.Parse(binary[i].ToString());
            }
            result = temp;
            return result;
        }

        public static string HexadecimalToBinary(string hexa)
        {
            string result = Convert.ToString(Convert.ToInt32(hexa, 16), 2);
            return result;
        }

        public static string BinaryToHexadecimal(string binary)
        {
            string hexa = "";
            string[] binaries = new string[binary.Length / 4 + 1];
            int iterator = 0;
            for (int i = 0; i < binaries.Length; i++)
            {
                for (int bin = 0; bin < 4; bin++)
                {
                    binaries[i] += (iterator + bin < binary.Length) ? binary[binary.Length - 1 - (iterator + bin)] : '0';
                }
                iterator += 4;
            }
            foreach (string bits in binaries)
            {
                char[] bitTemp = bits.ToCharArray();
                Array.Reverse(bitTemp);
                string bit = new string(bitTemp);
                Console.WriteLine(bit);
                hexa += Convert.ToString(Convert.ToInt32(bit, 2), 16);
            }
            char[] temp = hexa.ToCharArray();
            Array.Reverse(temp);
            hexa = new string(temp);
            return hexa;
        }

        public static string DecimalToHexadecimal(int number)
        {
            string result = "";
            if (number == 0)
                return "0";
            int temp = 0;
            while (number != 0)
            {
                temp = number % 16;
                switch (temp)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        result += temp.ToString();
                        break;
                    case 10:
                        result += 'A';
                        break;
                    case 11:
                        result += 'B';
                        break;
                    case 12:
                        result += 'C';
                        break;
                    case 13:
                        result += 'D';
                        break;
                    case 14:
                        result += 'E';
                        break;
                    case 15:
                        result += 'F';
                        break;
                    default:
                        break;
                }
                number /= 16;
            }
            char[] cResult = result.ToCharArray();
            Array.Reverse(cResult);
            result = new string(cResult);
            return result;
        }

        public static int HexadecimalToDecimal(string hexaNumber)
        {
            int result = 0;
            for (int i = 0; i < hexaNumber.Length; i++)
            {
                int temp = 0;
                switch (hexaNumber[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        temp = hexaNumber[i];
                        break;
                    case 'A':
                        temp = 10;
                        break;
                    case 'B':
                        temp = 11;
                        break;
                    case 'C':
                        temp = 12;
                        break;
                    case 'D':
                        temp = 13;
                        break;
                    case 'E':
                        temp = 14;
                        break;
                    case 'F':
                        temp = 15;
                        break;
                    default:
                        break;
                }
                result += temp * (int)Math.Pow(16, hexaNumber.Length - 1 - i);
            }
            return result;
        }

        public static int SBasedNumeralToDecimal(string number, int sBased)
        {
            int result = 0;
            int index = number.Length - 1;
            while (index >= 0)
            {
                int currentNumber = 0;
                char bit = number[number.Length - index - 1];
                switch (bit)
                {
                    case '0':
                        currentNumber = 0;
                        break;
                    case '1':
                        currentNumber = 1;
                        break;
                    case '2':
                        currentNumber = 2;
                        break;
                    case '3':
                        currentNumber = 3;
                        break;
                    case '4':
                        currentNumber = 4;
                        break;
                    case '5':
                        currentNumber = 5;
                        break;
                    case '6':
                        currentNumber = 6;
                        break;
                    case '7':
                        currentNumber = 7;
                        break;
                    case '8':
                        currentNumber = 8;
                        break;
                    case '9':
                        currentNumber = 9;
                        break;
                    case 'A':
                        currentNumber = 10;
                        break;
                    case 'B':
                        currentNumber = 11;
                        break;
                    case 'C':
                        currentNumber = 12;
                        break;
                    case 'D':
                        currentNumber = 13;
                        break;
                    case 'E':
                        currentNumber = 14;
                        break;
                    case 'F':
                        currentNumber = 15;
                        break;
                    default:
                        break;
                }
                currentNumber *= (int)Math.Pow(sBased, index);
                result += currentNumber;
                index--;
            }
            return result;
        }

        public static string DecimalToDBasedNumeral(int number, int dBased)
        {
            string result = "";
            if (number == 0)
                return "0";
            int temp = 0;
            while (number != 0)
            {
                temp = number % dBased;
                switch (temp)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        result += temp.ToString();
                        break;
                    case 10:
                        result += 'A';
                        break;
                    case 11:
                        result += 'B';
                        break;
                    case 12:
                        result += 'C';
                        break;
                    case 13:
                        result += 'D';
                        break;
                    case 14:
                        result += 'E';
                        break;
                    case 15:
                        result += 'F';
                        break;
                    default:
                        break;
                }
                number /= dBased;
            }
            char[] cResult = result.ToCharArray();
            Array.Reverse(cResult);
            result = new string(cResult);
            return result;
        }

        public static string SBasedNumeralToDBasedNumeral(string number, int sBased, int dBased)
        {
            int numberDecimal = SBasedNumeralToDecimal(number, sBased);
            Console.WriteLine($"The number {number} in the {sBased} numeral system is {numberDecimal} in decimal");
            string result = DecimalToDBasedNumeral(numberDecimal, dBased);
            Console.WriteLine($"The number {numberDecimal} in the {dBased} numeral system is {result}");
            return result;
        }

        public static string FractionalPartToBinary(float fractional)
        {
            string bits = "";
            while (fractional < 1f)
            {
                fractional *= 2;
                if (fractional >= 1f)
                    bits += "1";
                else
                    bits += '0';
                int integralTemp = (int)Math.Floor(fractional);
                fractional -= integralTemp;
            }
            return bits;
        }

        //public static string DecimalFloatToBinary(float number, out long sign, out string exponent, out string mantissa)
        //{
        //    byte[] bits = System.BitConverter.GetBytes(number);
        //    string binary = "";
        //    for (int i = 0; i < bits.Length; i++)
        //    {
        //        char[] tempChar = DecimalToBinary(bits[i]);
        //        for (int j = 0; j < tempChar.Length; j++)
        //            binary += tempChar[j];
        //    }

        //    int tempBin2 = int.Parse(binary);
        //    int temp = tempBin2 << 1;
        //    temp = temp >> 8;
        //    exponent = temp.ToString();

        //    mantissa = "";

        //    return binary;
        //}
    }

    /// <summary>
    /// Convert the numbers 151, 35, 43, 251, 1023 and 1024 to the binary numeral system.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            int number1 = 151;
            int number2 = 35;
            int number3 = 43;
            int number4 = 251;
            int number5 = 1023;
            int number6 = 1024;

            string binary1 = Converter.DecimalToBinary2(number1);
            string binary2 = Converter.DecimalToBinary2(number2);
            string binary3 = Converter.DecimalToBinary2(number3);
            string binary4 = Converter.DecimalToBinary2(number4);
            string binary5 = Converter.DecimalToBinary2(number5);
            string binary6 = Converter.DecimalToBinary2(number6);

            Console.WriteLine(number1 + " => " + binary1);
            Console.WriteLine(number2 + " => " + binary2);
            Console.WriteLine(number3 + " => " + binary3);
            Console.WriteLine(number4 + " => " + binary4);
            Console.WriteLine(number5 + " => " + binary5);
            Console.WriteLine(number6 + " => " + binary6);
        }
    }

    /// <summary>
    /// Convert the number 1111010110011110(2) to hexadecimal and decimal numeral systems.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            string binary = "1111010110011110";

            string hexa = Converter.BinaryToHexadecimal(binary);
            int number = Converter.BinaryToDecimal(binary);

            Console.WriteLine(binary + " : ToDecimal => " + number + " | ToHexadecimal => " + hexa);
        }
    }

    /// <summary>
    /// Convert the hexadecimal numbers FA, 2A3E, FFFF, 5A0E9 to binary and decimal numeral systems.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            string hexa1 = "FA";
            string hexa2 = "2A3E";
            string hexa3 = "FFFF";
            string hexa4 = "5A0E9";

            string binary1 = Converter.HexadecimalToBinary(hexa1);
            string binary2 = Converter.HexadecimalToBinary(hexa2);
            string binary3 = Converter.HexadecimalToBinary(hexa3);
            string binary4 = Converter.HexadecimalToBinary(hexa4);

            int number1 = Converter.HexadecimalToDecimal(hexa1);
            int number2 = Converter.HexadecimalToDecimal(hexa2);
            int number3 = Converter.HexadecimalToDecimal(hexa3);
            int number4 = Converter.HexadecimalToDecimal(hexa4);

            Console.WriteLine(hexa1 + " ToBinary => " + binary1 + " | ToDecimal => " + number1);
            Console.WriteLine(hexa2 + " ToBinary => " + binary2 + " | ToDecimal => " + number2);
            Console.WriteLine(hexa3 + " ToBinary => " + binary3 + " | ToDecimal => " + number3);
            Console.WriteLine(hexa4 + " ToBinary => " + binary4 + " | ToDecimal => " + number4);
        }
    }

    /// <summary>
    /// Write a program that converts a decimal number to binary one.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            Random random = new Random();
            int number = random.Next(0, 1000000);
            char[] binary = Converter.DecimalToBinary(number);
            Console.Write($"{number} to binary : ");
            foreach (char bin in binary)
            {
                Console.Write(bin);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Write a program that converts a binary number to decimal one.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            Console.Write("Write a binary number : ");
            string binary = Console.ReadLine();
            int number = Converter.BinaryToDecimal(binary);

            Console.WriteLine($"{number} to binary : {binary}");
        }
    }

    /// <summary>
    /// Write a program that converts a decimal number to hexadecimal one.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Random random = new Random();
            int number = random.Next(0, 1000000);
            string hexadecimal = Converter.DecimalToHexadecimal(number);
            Console.WriteLine($"{number} to hexa : {hexadecimal}");
        }
    }

    /// <summary>
    /// Write a program that converts a hexadecimal number to decimal one.
    /// </summary>
    public static class Exo7
    { 
        public static void Execute()
        {
            Console.Write("Write an hexadecimal number : ");
            string hexa = Console.ReadLine();
            int number = Converter.HexadecimalToDecimal(hexa);

            Console.WriteLine($"{hexa} to decimal : {number}");
        }
    }

    /// <summary>
    /// Write a program that converts a hexadecimal number to binary one.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            Console.Write("Write an hexadecimal number : ");
            string hexa = Console.ReadLine();
            string binary = Converter.HexadecimalToBinary(hexa);

            Console.WriteLine($"{hexa} to binary : {binary}");
        }
    }

    /// <summary>
    /// Write a program that converts a binary number to hexadecimal one.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Console.Write("Write a binary number : ");
            string binary = Console.ReadLine();
            string hexa = Converter.BinaryToHexadecimal(binary);

            Console.WriteLine($"{binary} to hexa : {hexa}");
        }
    }

    /// <summary>
    /// Write a program that converts a binary number to decimal using the Horner scheme.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            Console.Write("Write a binary number : ");
            string binary = Console.ReadLine();
            int number = Converter.BinaryToDecimalHorner(binary);
            Console.WriteLine($"{binary} to decimal : {number}");
        }
    }

    /// <summary>
    /// Write a program that converts Roman digits to Arabic ones.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {

        }
    } //TODO

    /// <summary>
    /// Write a program that converts Arabic digits to Roman ones.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {

        }
    } //TODO

    /// <summary>
    /// Write a program that by given N, S, D (2 ≤ S, D ≤ 16) converts the number N from an S-based numeral system to a D based numeral system.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {
            Console.Write("Write a number N in an S based numeral system : ");
            string number = Console.ReadLine();
            Console.Write("Write the S based numeral system : ");
            int sBased = int.Parse(Console.ReadLine());
            Console.Write("Write the D based numeral system : ");
            int dBased = int.Parse(Console.ReadLine());
            string result = Converter.SBasedNumeralToDBasedNumeral(number, sBased, dBased);
            Console.WriteLine($"The number {number} in {sBased} numeral system is {result} in the {dBased} numeral system");
        }
    }

    /// <summary>
    /// Try adding up 50,000,000 times the number 0.000001. 
    /// Use a loop and addition (not direct multiplication). 
    /// Try it with float and double and after that with decimal. 
    /// Do you notice the huge difference in the results and speed of calculation? 
    /// Explain what happens.
    /// </summary>
    public static class Exo14
    {
        public static void Execute()
        {
            float fNumber = 0f;
            double dNumber = 0;
            decimal mNumber = 0m;

            for (int f = 0; f < 50000000; f++)
            {
                fNumber += 0.000001f;
            }
            for (int d = 0; d < 50000000; d++)
            {
                dNumber += 0.000001;
            }
            for (int m = 0; m < 50000000; m++)
            {
                mNumber += 0.000001m;
            }
            Console.WriteLine("The solution are :");
            Console.WriteLine($"float : {fNumber} | double : {dNumber} | decimal : {mNumber}");
        }
    }

    /// <summary>
    /// Write a program that prints the value of the mantissa, the sign of the mantissa and exponent in float numbers (32-bit numbers with a floating-point according to the IEEE 754 standard). 
    /// Example: for the number -27.25 should be printed: sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
    /// </summary>
    public static class Exo15
    {
        public static void Execute()
        {
            Random random = new Random();
            int max = 100, min = -100;
            Console.Write("Write a number : ");
            float number = (float)random.NextDouble() * (max - min) + min;
            BigInteger sign = 0;
            string exponent = "", mantissa = "";
            //string result = Converter.DecimalFloatToBinary(number, out sign, out exponent, out mantissa);

            Console.WriteLine($"The number {number} is : sign = {sign}, exponent = {exponent}, mantissa = {mantissa}");
        }
    } //TODO
}
