using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_3_Operators_and_Expressions
{
    public struct Vector2
    {
        //Attributs
        public float x;
        public float y;

        //Constructor
        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }

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
            //Exo14.Execute();
            //Exo15.Execute();
            //Exo16.Execute();
        }
    }

    /// <summary>
    /// Write an expression that checks whether an integer is odd or even.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            int value = 42;
            bool isOdd = !IsEven(value);
            Console.WriteLine($"The variable {value} is odd : {isOdd}");
        }

        public static bool IsEven(int value)
        {
            return (value % 2 == 0);
        }
    }

    /// <summary>
    /// Write a Boolean expression that checks whether a given integer is divisible by both 5 and 7, without a remainder.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            int value = 42;
            bool isDivisibleBy5Or7 = (value % 5 == 0 && value % 7 == 0);
            Console.WriteLine($"The variable {value} is divisible by 5 or 7 : {isDivisibleBy5Or7}");
        }
    }

    /// <summary>
    /// Write an expression that looks for a given integer if its third digit (right to left) is 7.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            Random random = new Random();
            int number = random.Next(0, 1000);
            int temp = number / 100;
            int result = temp % 10;
            if (result == 7)
            {
                Console.WriteLine("Win : " + number);
            }
            else
            {
                Console.WriteLine("Lose : " + number);
            }

        }
    }

    /// <summary>
    /// Write an expression that checks whether the third bit in a given integer is 1 or 0.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            int integerBit = 42;
            bool thirdBit = (integerBit & 8) != 0;
            Console.WriteLine($"The 3rd bit is : {thirdBit}");
        }
    }

    /// <summary>
    /// Write an expression that calculates the area of a trapezoid by given sides a, b and height h.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            float sideA = 5f;
            float sideB = 6f;
            float height = 20f;
            float trapezoidArea = ((sideA + sideB) * height) / 2;
            Console.WriteLine($"The aera of a trapezoid is : {trapezoidArea}");
        }
    }

    /// <summary>
    /// Write a program that prints on the console the perimeter and the area of a rectangle by given side and height entered by the user.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Console.Write("Write the width : ");
            float rectWidth = float.Parse(Console.ReadLine());
            Console.Write("Write the height : ");
            float rectHeight = float.Parse(Console.ReadLine());
            float rectPerimeter = (rectHeight + rectWidth) * 2;
            float rectArea = rectWidth * rectHeight;
            Console.WriteLine($"The rectangle perimeter is : {rectPerimeter}, and the area i : {rectArea}");
        }
    }

    /// <summary>
    /// The gravitational field of the Moon is approximately 17% of that on the Earth.
    /// Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            float earthGravity = -9.81f;
            //Console.WriteLine("Veuillez rentrer votre poids :");
            //float weight = float.Parse(Console.ReadLine());
            float weight = 60f;
            float moonGravity = -9.81f * 0.17f;
            float weightOnMoon = (moonGravity * weight) / earthGravity;
            Console.WriteLine($"Votre poids sur la Lune est {weightOnMoon}");
        }
    }

    /// <summary>
    /// Write an expression that checks for a given point {x, y} if it is within the circle K({ 0, 0}, R=5). 
    /// Explanation: the point {0, 0} is the center of the circle and 5 is the radius.
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            //c.f Exo9
        }
    }

    /// <summary>
    /// Write an expression that checks for given point {x, y} if it is within the circle K({ 0, 0}, R=5) and out of the rectangle[{-1, 1}, {5, 5}]. 
    /// Clarification: for the rectangle the lower left and the upper right corners are given.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Vector2 point2D = new Vector2(2f, 2f);
            Vector2 circleCenter = new Vector2(0f, 0f);
            float radius = 5f;

            Vector2 bottomLeftRec = new Vector2(-1f, 1f);
            Vector2 bottolRightRec = new Vector2(5f, 1f);
            Vector2 topLeftRec = new Vector2(-1f, 5f);
            Vector2 topRightRec = new Vector2(5f, 5f);
            Vector2[] rectangle = new Vector2[4];
            rectangle[0] = topLeftRec; //A
            rectangle[1] = topRightRec; //B
            rectangle[2] = bottolRightRec; //C
            rectangle[3] = bottomLeftRec; //D



            Vector2 AB = new Vector2(rectangle[1].x - rectangle[0].x, rectangle[1].y - rectangle[0].y);
            Vector2 BC = new Vector2(rectangle[2].x - rectangle[1].x, rectangle[2].y - rectangle[1].y);
            Vector2 CD = new Vector2(rectangle[3].x - rectangle[2].x, rectangle[3].y - rectangle[2].y);
            Vector2 DA = new Vector2(rectangle[0].x - rectangle[3].x, rectangle[0].y - rectangle[3].y);
            Vector2 AP = new Vector2(point2D.x - rectangle[0].x, point2D.y - rectangle[0].y);
            Vector2 BP = new Vector2(point2D.x - rectangle[1].x, point2D.y - rectangle[1].y);
            Vector2 CP = new Vector2(point2D.x - rectangle[2].x, point2D.y - rectangle[2].y);
            Vector2 DP = new Vector2(point2D.x - rectangle[3].x, point2D.y - rectangle[3].y);

            float lenghtAB = (float)Math.Sqrt((AB.x * AB.x) + (AB.y * AB.y));
            float lenghtBC = (float)Math.Sqrt((BC.x * BC.x) + (BC.y * BC.y));
            float lenghtCD = (float)Math.Sqrt((CD.x * CD.x) + (CD.y * CD.y));
            float lenghtDA = (float)Math.Sqrt((DA.x * DA.x) + (DA.y * DA.y));
            float lenghtAP = (float)Math.Sqrt((AP.x * AP.x) + (AP.y * AP.y));
            float lenghtBP = (float)Math.Sqrt((BP.x * BP.x) + (BP.y * BP.y));
            float lenghtCP = (float)Math.Sqrt((CP.x * CP.x) + (CP.y * CP.y));
            float lenghtDP = (float)Math.Sqrt((DP.x * DP.x) + (DP.y * DP.y));


            float semiperimeterABP = (lenghtAB + lenghtAP + lenghtBP) / 2f;
            float semiperimeterBCP = (lenghtBC + lenghtBP + lenghtCP) / 2f;
            float semiperimeterCDP = (lenghtCD + lenghtCP + lenghtDP) / 2f;
            float semiperimeterDAP = (lenghtDA + lenghtDP + lenghtAP) / 2f;

            float areaABP = (float)Math.Sqrt(semiperimeterABP * (semiperimeterABP - lenghtAB) * (semiperimeterABP - lenghtAP) * (semiperimeterABP - lenghtBP));
            float areaBCP = (float)Math.Sqrt(semiperimeterBCP * (semiperimeterBCP - lenghtBC) * (semiperimeterBCP - lenghtBP) * (semiperimeterBCP - lenghtCP));
            float areaCDP = (float)Math.Sqrt(semiperimeterCDP * (semiperimeterCDP - lenghtCD) * (semiperimeterCDP - lenghtCP) * (semiperimeterCDP - lenghtDP));
            float areaDAP = (float)Math.Sqrt(semiperimeterDAP * (semiperimeterDAP - lenghtDA) * (semiperimeterDAP - lenghtDP) * (semiperimeterDAP - lenghtAP));

            float rectArea2 = lenghtAB * lenghtBC;


            float deltaX = (float)Math.Pow(point2D.x - circleCenter.x, 2);
            float deltaY = (float)Math.Pow(point2D.y - circleCenter.y, 2);
            if ((Math.Sqrt(deltaX + deltaY) <= radius))
            {
                Console.WriteLine($"The point is inside the circle");
                if (rectArea2 - areaABP + areaBCP + areaCDP + areaDAP <= 0.000001f)
                {
                    Console.WriteLine($"The point is inside the circle and outside the rectangle");
                }
                else
                {
                    Console.WriteLine($"The point is inside the circle and inside the rectangle");
                }
            }
            else
            {
                Console.WriteLine($"The point is outside the circle");
                if (rectArea2 - areaABP + areaBCP + areaCDP + areaDAP <= 0.000001f)
                {
                    Console.WriteLine($"The point is outside the circle and outside the rectangle");
                }
                else
                {
                    Console.WriteLine($"The point is outside the circle and inside the rectangle");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following actions:
    /// - Calculates the sum of the digits(in our example 2+0+1+1 = 4).
    /// - Prints on the console the number in reversed order: dcba(in our example 1102).
    /// - Puts the last digit in the first position: dabc(in our example 1201).
    /// - Exchanges the second and the third digits: acbd(in our example 2101).
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            Console.WriteLine("Ecrire un nombre à 4 chiffres :");
            int number = 4056; // int.Parse(Console.ReadLine());
            int digit1 = number % 10;
            int digit2 = (number / 10) % 10;
            int digit3 = (number / 100) % 10;
            int digit4 = (number / 1000) % 10;
            int sumOfDigits = digit1 + digit2 + digit3 + digit4;
            Console.WriteLine("Etat initial : " + digit1 + " " + digit2 + " " + digit3 + " " + digit4);

            Console.WriteLine(digit4 + digit3 + digit2 + digit1);

            digit1 = digit4;
            digit2 = digit2 + digit3;
            digit3 = digit2 - digit3;
            digit2 = digit2 - digit3;

            Console.WriteLine("Etat final : " + digit1 + " " + digit2 + " " + digit3 + " " + digit4);
        }
    }

    /// <summary>
    /// We are given a number n and a position p. 
    /// Write a sequence of operations that prints the value of the bit on the position p in the number(0 or 1). 
    /// Example: n=35, p=5 -> 1. Another example: n=35, p=6 -> 0.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            // Console.WriteLine("Ecrire un nombre :");
            int value2 = 42; // int.Parse(Console.ReadLine());
            //Console.WriteLine("Ecrire une position :");
            int position = 8; // int.Parse(Console.ReadLine());
            int bitOnPos;
            int tempvalue2 = value2 >> position;
            if ((tempvalue2 & 1) != 0)
            {
                bitOnPos = 1;
            }
            else
            {
                bitOnPos = 0;
            }
            Console.WriteLine($"n = {value2}, p = {position} => {bitOnPos}");
        }
    }

    /// <summary>
    /// Write a Boolean expression that checks if the bit on position p in the integer v has the value 1.
    /// Example v = 5, p = 1-> false.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {
            // Console.WriteLine("Ecrire un nombre :");
            int value2 = 42; // int.Parse(Console.ReadLine());
            //Console.WriteLine("Ecrire une position :");
            int position = 8; // int.Parse(Console.ReadLine());
            int bitOnPos;
            int tempvalue2 = value2 >> position;
            if ((tempvalue2 & 1) != 0)
            {
                bitOnPos = 1;
            }
            else
            {
                bitOnPos = 0;
            }
            Console.WriteLine($"n = {value2}, p = {position} => {bitOnPos}");

            bool bit1OnPos = (tempvalue2 & 1) != 0;
            Console.WriteLine($"There is a 1 on position {position} => {bit1OnPos}");
        }
    }

    /// <summary>
    /// We are given the number n, the value v (v = 0 or 1) and the position p. write a sequence of operations that changes the value of n, so the bit on the position p has the value of v.
    /// Example: n= 35, p= 5, v= 0->n = 3. Another example: n= 35, p= 2, v= 1->n = 39.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        { 
            Console.WriteLine("Ecrire un nombre :");
            int value3 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ecrire une valeur du bit :");
            int bitValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Ecrire une position :");
            int position3 = int.Parse(Console.ReadLine());

            int bitAtPos = bitValue << position3;
            int bitChanged = value3 ^ bitAtPos;

            Console.WriteLine("The new value is " + bitChanged);
        }
    }

    /// <summary>
    /// Write a program that checks if a given number n (1 <(>) n <(>) 100) is a prime number
    /// </summary>
    public static class Exo14
    {
        public static void Execute()
        {
            Console.WriteLine("Ecrivez un nombre entre 2 et 99 :");
            int value4 = int.Parse(Console.ReadLine());
            if (value4 > 1 && value4 < 100)
            {
                bool isPrimeNumber = true;
                for (int i = 2; i < 100; i++)
                {
                    if (value4 % i == 0)
                    {
                        if (!(value4 == i))
                        {
                            isPrimeNumber = false;
                            break;
                        }
                    }
                }
                if (isPrimeNumber)
                {
                    Console.WriteLine("C'est un nombre premier");
                }
                else
                {
                    Console.WriteLine("Ce n'est pas un nombre premier");
                }
            }
            else
            {
                Console.WriteLine("Veuillez rentrer un nombre correct");
            }
        }
    }

    /// <summary>
    /// Write a program that exchanges the values of the bits on positions 3, 4 and 5 with bits on positions 24, 25 and 26 of a given 32-bit unsigned integer.
    /// </summary>
    public static class Exo15
    {
        public static void Execute()
        {
            Random rand = new Random(42);
            uint randomInt1 = (uint)rand.Next(0, int.MaxValue);
            Console.WriteLine(randomInt1);
            int bitOnPos3 = ((randomInt1 & 8) != 0) ? 1 : 0;
            int bitOnPos4 = ((randomInt1 & 16) != 0) ? 1 : 0;
            int bitOnPos5 = ((randomInt1 & 32) != 0) ? 1 : 0;
            int bitOnPos24 = ((randomInt1 & 16777216) != 0) ? 1 : 0;
            int bitOnPos25 = ((randomInt1 & 33554432) != 0) ? 1 : 0;
            int bitOnPos26 = ((randomInt1 & 67108864) != 0) ? 1 : 0;
            uint randomInt = (uint)(randomInt1 & (~(1 << 24) | bitOnPos3 << 24));
            randomInt = (uint)(randomInt & (~(1 << 25) | bitOnPos4 << 25));
            randomInt = (uint)(randomInt & (~(1 << 26) | bitOnPos5 << 26));
            randomInt = (uint)(randomInt1 & (~(1 << 3) | bitOnPos24 << 3));
            randomInt = (uint)(randomInt & (~(1 << 4) | bitOnPos25 << 4));
            randomInt = (uint)(randomInt & (~(1 << 5) | bitOnPos26 << 5));


            uint num = randomInt1;
            uint bit3 = (num >> 3) & 1;
            uint bit24 = (num >> 24) & 1;
            num = (uint)(num & (~(1 << 24)) | (bit3 << 24));
            num = (uint)(num & (~(1 << 3)) | (bit24 << 3));
            uint bit4 = (num >> 4) & 1;
            uint bit25 = (num >> 25) & 1;
            num = (uint)(num & (~(1 << 25)) | (bit3 << 25));
            num = (uint)(num & (~(1 << 4)) | (bit24 << 4));
            uint bit5 = (num >> 5) & 1;
            uint bit26 = (num >> 26) & 1;
            num = (uint)(num & (~(1 << 26)) | (bit3 << 26));
            num = (uint)(num & (~(1 << 5)) | (bit24 << 5));
            Console.WriteLine("Result : " + num + ", j'obtient : " + randomInt);
        }
    }

    /// <summary>
    /// Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
    /// </summary>
    public static class Exo16
    {
        public static void Execute()
        {

        }
    } //TODO
}
