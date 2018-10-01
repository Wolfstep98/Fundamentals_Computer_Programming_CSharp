using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace IntroToCSharp
{
    class HelloCSharp
    {

        struct Vector2
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

        static BigInteger Factorial(int n)
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

        static int CheckLastZeros(BigInteger value)
        {
            int number = 0;
            for (int i = 10; value % i == 0; i *= 10)
            {
                number++;
            }
            return number;
        }

        static bool CompareTwoNumbers(float a, float b)
        {
            return (Math.Abs(a - b) < 0.000001);
        }

        static string IntegerToBinary(int value)
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
        static int HexadecToDec(string value)
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

        static string DecToHexadec(int value)
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

        static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        static List<int> MaxSeqOfIncreasingNumbers(List<int> tab)
        {
            int[] P = new int[tab.Count];
            int[] M = new int[tab.Count + 1];
            int L = 0;
            for (int i = 0; i < tab.Count; i++)
            {
                double lo = 1;
                double hi = L;
                while (lo <= hi)
                {
                    double mid = Math.Ceiling((((double)lo + (double)hi) / 2));
                    if (tab[M[(int)mid]] < tab[i])
                        lo = mid + 1;
                    else
                        hi = mid - 1;
                }
                int newL = (int)lo;
                P[i] = M[newL - 1];
                M[newL] = i;
                if (newL > L)
                {
                    L = newL;
                }
            }
            int[] S = new int[L];
            int k = M[L];
            for (int i = 0; i < L - 1; i++)
            {
                S[i] = tab[k];
                k = P[k];
            }
            Console.WriteLine("Lenght : " + L);
            IEnumerable<int> result = S.Reverse();
            return result.ToList();
        }

        static void SelectionSort(int[] integerArray)
        {
            for (int i = 0; i < integerArray.Length - 1; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < integerArray.Length; j++)
                {
                    if (integerArray[j] < integerArray[iMin])
                        iMin = j;
                }
                if (iMin != i)
                {
                    int temp = integerArray[i];
                    integerArray[i] = integerArray[iMin];
                    integerArray[iMin] = temp;
                }
            }
        }

        static void MergeSort(int[] numbers)
        {
            int[] B = new int[numbers.Length];
            numbers.CopyTo(B, 0);
            SplitMerge(B, 0, numbers.Length, numbers);
        }

        static void SplitMerge(int[] B, int iBegin, int iEnd, int[] A)
        {
            if (iEnd - iBegin < 2)
                return;
            int iMiddle = (iEnd + iBegin) / 2;
            SplitMerge(A, iBegin, iMiddle, B);
            SplitMerge(A, iMiddle, iEnd, B);
            Merge(B, iBegin, iMiddle, iEnd, A);
        }

        static void Merge(int[] A, int iBegin, int iMiddle, int iEnd, int[] B)
        {
            int i = iBegin, j = iMiddle;
            for (int k = iBegin; k < iEnd; k++)
            {
                if (i < iMiddle && (j >= iEnd || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i++;
                }
                else
                {
                    B[k] = A[j];
                    j++;
                }
            }
        }

        static void QuickSort(int[] numbers, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(numbers, lo, hi);
                if (p > 1)
                    QuickSort(numbers, lo, p - 1);
                if (p + 1 < hi)
                    QuickSort(numbers, p + 1, hi);
            }
        }

        static int Partition(int[] A, int lo, int hi)
        {
            int pivot = A[lo];
            while (true)
            {
                while (A[lo] < pivot)
                {
                    lo++;
                }
                while (A[hi] > pivot)
                {
                    hi--;
                }
                if (lo < hi)
                {
                    int temp = A[lo];
                    A[lo] = A[hi];
                    A[hi] = temp;
                    if (A[lo] == A[hi])
                        lo++;
                }
                else
                    return hi;
            }
        }

        static int[] Eratosthene(int limite)
        {
            List<int> result = new List<int>();
            bool[] A = new bool[limite];
            for (int i = 0; i < A.Length; i++)
                A[i] = true;
            for (int i = 2; i < Math.Sqrt(limite); i++)
            {
                if (A[i])
                {
                    for (int j = i * i; j < limite; j += i)
                    {
                        A[j] = false;
                    }
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i])
                    result.Add(i);
            }
            return result.ToArray();
        }

        //Convertion Binary / Decimal / Hexadecimal

        static char[] DecimalToBinary(int number)
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

        static int BinaryToDecimal(char[] binaries)
        {
            int number = 0;
            for (int i = 0; i < binaries.Length; i++)
            {
                number += (binaries[i] == '1') ? (int)Math.Pow(2, binaries.Length - 1 - i) : 0;
            }
            return number;
        }

        static int BinaryToDecimal(string binaries)
        {
            return BinaryToDecimal(binaries.ToArray());
        }

        static string DecimalToHexadecimal(int number)
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

        static int HexadecimalToDecimal(string hexaNumber)
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

        static string HexadecimalToBinary(string hexa)
        {
            string result = Convert.ToString(Convert.ToInt16(hexa, 16), 2);
            return result;
        }

        static string BinaryToHexadecimal(string binary)
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

        static int BinaryToDecimalHorner(string binary)
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

        static int SBasedNumeralToDecimal(string number, int sBased)
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

        static string DecimalToDBasedNumeral(int number, int dBased)
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

        static string SBasedNumeralToDBasedNumeral(string number, int sBased, int dBased)
        {
            int numberDecimal = SBasedNumeralToDecimal(number, sBased);
            Console.WriteLine($"The number {number} in the {sBased} numeral system is {numberDecimal} in decimal");
            string result = DecimalToDBasedNumeral(numberDecimal, dBased);
            Console.WriteLine($"The number {numberDecimal} in the {dBased} numeral system is {result}");
            return result;
        }

        static string FractionalPartToBinary(float fractional)
        {
            string bits = "";
            while(fractional < 1f)
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
        /*
        static string DecimalFloatToBinary(float number, out long sign, out string exponent, out string mantissa)
        {
            byte[] bits = System.BitConverter.GetBytes(number);
            string binary = "";
            for(int i = 0; i < bits.Length;i++)
            {
                char[] tempChar = DecimalToBinary(bits[i]);
                for (int j = 0; j < tempChar.Length; j++)
                    binary += tempChar[j];
            }

            int tempBin2 = int.Parse(binary);
            int temp = tempBin2 << 1;
            temp = temp >> 8;
            exponent = temp.ToString();

            mantissa = "";

            return binary;
        }*/

        static void Main(string[] args)
        {
            Random random = new Random();

            //Chapitre 2 : Variable
            /*ushort var1 = 52130;
            sbyte var2 = -115;
            int var3 = 4825932;
            byte var4 = 97;
            short var5 = -10000;
            short var6 = 20000;
            byte var7 = 224;
            int var8 = 970700000;
            byte var9 = 112;
            sbyte var10 = -44;
            int var11 = -1000000;
            short var12 = 1990;
            ulong var13 = 123456789123456789;

            float val1 = 5f;
            float val2 = -5.01f;
            double val3 = 34.567839023;
            float val4 = 12.345f;
            float val5 = 8923.12345857f;
            decimal val6 = 3456.091124875956542151256683467m;

            int hexadecimal256 = 0x0100;
            Console.WriteLine(hexadecimal256);

            bool result = CompareTwoNumbers(5f, 5.00001f);
            Console.WriteLine(result);

            char letter = '\u0048';
            Console.WriteLine(letter);

            bool isMale = true;

            string hello = "Hello";
            string world = "World";
            object sentence = hello + " " + world;
            Console.WriteLine(sentence);

            string strSentence = (string)sentence;
            Console.WriteLine(strSentence);

            string str1 = "The \"use\" of quotations causes difficulties.";
            string str2 = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(str1);
            Console.WriteLine(str2);

            string oHeart =
                 "    o        o\n" +
                 "   o   o    o   o\n" +
                 "  o      o o      o\n" +
                 "  o       o      o\n" +
                 "   o            o\n" +
                 "     o         o\n" +
                 "       o      o\n" +
                 "         o   o\n" +
                 "           o \n";
            Console.WriteLine(oHeart);

            string triangleIsocele = "    \u00A9\n" +
                "   \u00A9 \u00A9\n" +
                "  \u00A9   \u00A9\n" +
                " \u00A9     \u00A9\n" +
                "\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\u00A9\n";
            Console.WriteLine(triangleIsocele);

            

            string firstName = "Benjamin";
            string lastName = "Peter";
            byte age = 19;
            char gender = 'm';
            int employeeNumber = 27569316;

            int five = 5;
            int ten = 10;

            int tempVar = five;
            five = ten;
            ten = tempVar;

            Console.WriteLine($"Five vaut mtn : {five}");
            Console.WriteLine($"Ten vaut mtn : {ten}"); */

            //Chapitre 3 : Operateur et expressions
            /*
            int value = 42;
            bool isOdd = (value % 2 == 0);
            Console.WriteLine($"The variable is odd : {isOdd}");

            bool isDivisibleBy5Or7 = (value % 5 == 0 && value % 7 == 0);
            Console.WriteLine($"The variable is divisible by 5 or 7 : {isDivisibleBy5Or7}");

            int integerBit = 42;
            bool thirdBit = (integerBit & 8) != 0;
            Console.WriteLine($"The 3rd bit is : {thirdBit}");

            float sideA = 5f;
            float sideB = 6f;
            float height = 20f;
            float trapezoidArea = ((sideA + sideB) * height) / 2;
            Console.WriteLine($"The aera of a trapezoid is : {trapezoidArea}");

            float rectWidth = 4f;
            float rectHeight = 6f;
            float rectPerimeter = (rectHeight + rectWidth) * 2;
            float rectArea = rectWidth * rectHeight;
            Console.WriteLine($"The rectangle perimeter is : {rectPerimeter}, and the area i : {rectArea}");

            float earthGravity = -9.81f;
            //Console.WriteLine("Veuillez rentrer votre poids :");
            //float weight = float.Parse(Console.ReadLine());
            float weight = 60f;
            float moonGravity = -9.81f * 0.17f;
            float weightOnMoon = (moonGravity * weight) / earthGravity;
            Console.WriteLine($"Votre poids sur la Lune est {weightOnMoon}");

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
                if(rectArea2 - areaABP + areaBCP + areaCDP + areaDAP <= 0.000001f)
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

            // Console.WriteLine("Ecrire un nombre :");
            int value2 = 42; // int.Parse(Console.ReadLine());
            //Console.WriteLine("Ecrire une position :");
            int position = 8; // int.Parse(Console.ReadLine());
            int bitOnPos;
            int tempvalue2 = value2 >> position;
            if((tempvalue2 & 1) != 0)
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

            //Console.WriteLine("Ecrire un nombre :");
            //int value3 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Ecrire une valeur du bit :");
            //int bitValue = int.Parse(Console.ReadLine());
            //Console.WriteLine("Ecrire une position :");
            //int position3 = int.Parse(Console.ReadLine());

            //int bitAtPos = bitValue << position3;
            //int bitChanged = value3 ^ bitAtPos;

            //Console.WriteLine("The new value is " + bitChanged);

            Console.WriteLine("Ecrivez un nombre entre 2 et 99 :");
            int value4 = int.Parse(Console.ReadLine());
            if(value4 > 1 && value4 < 100)
            {
                bool isPrimeNumber = true;
                for(int i = 2; i < 100; i++)
                {
                    if(value4 % i == 0)
                    {
                        if(!(value4 == i))
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
            */

            //Chapitre 4 : Console
            /*
            Console.WriteLine("Indiquer 3 int : ");
            int a, b, c;
            string outPut = Console.ReadLine();
            a = int.Parse(outPut);
            string outPut2 = Console.ReadLine();
            b = int.Parse(outPut2);
            string outPut3 = Console.ReadLine();
            c = int.Parse(outPut3);
            Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
            

            Console.Write("Write the radius of a circle : ");
            int radius = int.Parse(Console.ReadLine());
            Console.WriteLine("With a radius r = {0}, the perimeter is {1} and the area is {2}", radius, 2f * (float)Math.PI * radius,radius * radius * (float)Math.PI);
            

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
                "The manager is {5} {6}, you can contact it at {7}.",name,address,phoneNumber,faxNumber,webSite,managerName,managerSurname,managerPhoneNumber);
            

            int firstNumber = 25;
            float fractionalPos = 2.165554f;
            float fractionNeg1 = -54154.2684f;
            float fractionNeg2 = 455784.846f;
            Console.WriteLine($"{firstNumber,-10:X} | {fractionalPos,-10:C2} | {fractionNeg1:.00/}{fractionNeg2,-5:.00}");
            

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
                if(index % 5 == 0)
                {
                    Console.WriteLine(index);
                }
            }
            int number1, number2;
            Console.Write("Write an integer : ");
            string firstInt = Console.ReadLine();
            number1 = int.Parse(firstInt);
            Console.Write("Write an integer : ");
            firstInt = Console.ReadLine();
            number2 = int.Parse(firstInt);
            Console.WriteLine($"The biggest number is : {Math.Max(number1, number2)}");

            int number;
            long sum = 0L;
            string text;
            bool varIsInt = false;
            for(int index = 1; index <=5; index++)
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
                    if(index == 1)
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

            int number = 0;
            string text = "";
            Console.WriteLine("Write an integer : ");
            text = Console.ReadLine();
            number = int.Parse(text);
            for(int index = 1; index <= number; index++)
            {
                Console.WriteLine(index);
            }

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

            */

            //Chapitre 5 : Conditional Statements
            /* 

            int firstVar = 210;
            int secondVar = 55;
            if (firstVar > secondVar)
            {
                firstVar ^= secondVar;
                secondVar ^= firstVar;
                firstVar ^= secondVar;
            }

            Console.WriteLine(firstVar + " " + secondVar);
            

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

            int value1 = 486;
            int value2 = -5416;
            int value3 = 48;
            int biggestValue = 0;

            biggestValue = value1;
            if (value2 > biggestValue)
                biggestValue = value2;
            if (value3 > biggestValue)
                biggestValue = value3;

            Console.WriteLine(biggestValue);

            
            int value1 = -486;
            int value2 = -5;
            int value3 = -48;

            if(value2 < value3)
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
            if(value2 < value3)
            {
                value2 ^= value3;
                value3 ^= value2;
                value2 ^= value3;
            }

            Console.WriteLine($"{value1} {value2} {value3}");


            int number = -1;
            number = int.Parse(Console.ReadLine());
            switch(number)
            {
                case -1:
                    Console.WriteLine("Write an correct integer pls");
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
            

            float a = 4f;
            float b = 5f;
            float c = 0f;

            float discriminant = (b * b) - (4f * a * c);
            if(discriminant == 0)
            {
                float x = -b / (2f * a);
                Console.WriteLine($"There is one real roots, and it's on x = {x} !");
            }
            else if(discriminant > 0)
            {
                float x1 = (-b + (float)Math.Sqrt(discriminant)) / (2f * a);
                float x2 = (-b - (float)Math.Sqrt(discriminant)) / (2f * a);
                Console.WriteLine($"There is two real roots, and it's on x1 = {x1} and x2 = {x2} !");
            }
            else
            {
                Console.WriteLine("There is no real roots !");
            }    

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

            Console.Write("Write something : ");
            string text = Console.ReadLine();
            int valueType = 0;
            int number = 0;
            float floatingNumber = 0f;
            if(int.TryParse(text, out number))
            {
                valueType = 1;
            }
            else if(float.TryParse(text, out floatingNumber))
            {
                valueType = 2;
            }
            else
            {
                valueType = 3;
            }
            switch(valueType)
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

            Console.Write("Write an integer between 1 and 9 : ");
            int number = 0;
            if(int.TryParse(Console.ReadLine(), out number))
            {
                if(number > 0 && number <= 9)
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

            Console.Write("Write an integer n = ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++) 
            {
                Console.WriteLine(i);
            }

            Console.Write("Write an integer n = ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if(i % (3 * 7) != 0)
                    Console.WriteLine(i);
            }    

            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                bool nextIteration = true;
                do
                {
                    Console.Write("Write an integer : ");
                    nextIteration = !int.TryParse(Console.ReadLine(), out numbers[i]);
                } while (nextIteration);
            }
            IEnumerable<int> query = numbers.OrderBy((number) => number);
            Console.WriteLine("min = {0} / max = {1}", query.First(), query.Last());


            string[] cards = new string[13] {"As","Deux","Trois","Quatre","Cinq","Six","Sept","Huit","Neuf","Dix","Valet","Dame","Roi"};
            string[] forms = new string[4] { "Coeur", "Pique", "Carreaux", "Trefle" };
            foreach(string form in forms)
            {
                foreach(string card in cards)
                {
                    Console.WriteLine($"{card} de {form}");
                }
            }
            
            int value = int.Parse(Console.ReadLine());
            BigInteger i = 0;
            Console.WriteLine(i);
            BigInteger j = 1;
            Console.WriteLine(j);
            BigInteger temp;
            for(int index = 0; index < value; index++)
            {
                temp = i + j;
                i = j;
                j = temp;
                Console.WriteLine(j);
            }

            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            if(K > N)
            {
                K ^= N;
                N ^= K;
                K ^= N;
            }
            int M = N - K;
            BigInteger NFactorial = 1;
            BigInteger KFactorial = 1;
            BigInteger MFactorial = 1;
            for (int i = 1, j = 1; i<=N ;i++, j++)
            {
                NFactorial *= i;
                if(j < K)
                {
                    KFactorial *= j;
                }
                if(i < M)
                {
                    MFactorial *= i;
                }
            }
            Console.WriteLine("The result is {0}", (NFactorial * KFactorial) / MFactorial);

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            if(n >= 0)
            {
                
                BigInteger catalanNumber = ((Factorial(2 * n) / (Factorial(n + 1) * Factorial(n))));
                Console.WriteLine($"The Catalan Number is {catalanNumber}");
            }
            for(int i = 0; i < 20;i++)
            {
                BigInteger catalanNumber = ((Factorial(2 * i) / ((Factorial(i + 1)) * Factorial(i))));
                Console.WriteLine($"The Catalan Number is {catalanNumber}");
            }

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());
            BigInteger sum = 1;
            for(int i = 1; i < n; i++)
            {
                sum += Factorial(i) / BigInteger.Pow(x, n);
            }
            Console.WriteLine($"The sum is {sum}");

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            if (n > 20)
                n = 20;
            else if (n < 0)
                n = 1;
            int value = 1;
            for(int x =0; x < n; x ++)
            {
                int tempValue = value;
                for(int y = 0; y < n; y++)
                {
                    if(tempValue < 10)
                        Console.Write(" ");
                    Console.Write(tempValue + " ");
                    tempValue++;
                }
                value++;
                Console.WriteLine();
            }

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            BigInteger N = Factorial(n);
            int number = CheckLastZeros(N);
            Console.WriteLine("There is {0} 0 at the end of the factorial {1}", number, N);


            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            string binary = IntegerToBinary(n);
            Console.WriteLine($"Integer : {n} | Binary : {binary}");

            
            Console.Write("n = ");
            string n = Console.ReadLine();
            int value = BinaryToInt(n);
            Console.WriteLine($"Binary : {n} | Integer : {value}");

            Console.Write("n = ");
            string n = Console.ReadLine();
            int value = HexadecToDec(n);
            Console.WriteLine($"Hexadecimal : {n} | Decimal : {value}");

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            string value = DecToHexadec(n);
            Console.WriteLine($"Decimal : {n} | Hexadecimal : {value}");

            Random random = new Random();
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            List<int> integers = new List<int>(n+1);
            for (int i = 0; i < integers.Capacity; i++) 
            {
                integers.Add(i);
            }
            List<int> randomIntegers = new List<int>(n+1);
            for (int i = 0; i < integers.Capacity; i++)
            {
                int randomNumber = random.Next(0,integers.Count);
                randomIntegers.Add(integers[randomNumber]);
                integers.RemoveAt(randomNumber);
            }
            foreach(int number in randomIntegers)
            {
                Console.WriteLine(number);
            }
            

            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            int result = GCD(a, b);
            int lcm = (Math.Abs(a * b)) / result;
            Console.WriteLine($"There GCD is : {result}");
            Console.WriteLine($"There LCM is : {lcm}");

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int value = 0;
            int[,] array = new int[n, n];
            int colomn = 0, row = 0;
            while(value < n*n)
            {
                for(int i = 0; i < n; i ++)
                {
                    
                }

            }

            

            //Chapter 7 : Arrays
            
            int[] tab = new int[20];
            for(int i = 0; i < tab.Length;i++)
            {
                tab[i] = i * 5;
            }
            foreach(int number in tab)
            {
                Console.WriteLine(number);
            }
            
            Console.Write("First array lenght : ");
            int length1 = int.Parse(Console.ReadLine());
            int[] numbers1 = new int[length1];
            for(int i = 0; i < numbers1.Length; i++)
            {
                numbers1[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Second array lenght : ");
            int length2 = int.Parse(Console.ReadLine());
            int[] numbers2 = new int[length2];
            for (int i = 0; i < numbers2.Length; i++)
            {
                numbers2[i] = int.Parse(Console.ReadLine());
            }

            bool equal = true;
            if(numbers1.Length == numbers2.Length)
            {
                for(int i = 0; i < numbers2.Length; i++)
                {
                    if(numbers1[i] != numbers2[i])
                    {
                        equal = false;
                        break;
                    }
                }
            }
            else
            {
                equal = false;
            }

            Console.WriteLine($"Are they equal ? {equal}");


            char[] sentence1, sentence2;
            Console.Write("Write something : ");
            string text1 = Console.ReadLine();
            Console.Write("Write something : ");
            string text2 = Console.ReadLine();
            sentence1 = text1.ToCharArray();
            sentence2 = text2.ToCharArray();

            bool sentence1BeforeSentence2 = true;
            for(int i =0; i < sentence1.Length && i < sentence2.Length; i++)
            {
                if (sentence1[i] > sentence2[i])
                {
                    sentence1BeforeSentence2 = false;
                    break;
                }
            }

            Console.WriteLine($"Sentence 1 is before sentence 2 ? {sentence1BeforeSentence2}");


            int[] numbers = new int[20] {5,4,2,7,7,7,7,7,2,4,2,5,4,2,2,2,2,1,3,5 };
            int tempNbrR, tempNbrOfTime = 0; ;
            int nbrR = 0, nbrOfTime = 0;
            for(int i = 0; i < numbers.Length;i++)
            {
                tempNbrR = numbers[i];
                tempNbrOfTime = 1;
                bool numberAfterIsSame = true;
                do
                {
                    if (i + tempNbrOfTime < numbers.Length)
                    {
                        if (tempNbrR == numbers[i + tempNbrOfTime])
                        {
                            tempNbrOfTime++;
                        }
                        else
                        {
                            numberAfterIsSame = false;
                        }
                    }
                    else
                        break;
                } while (numberAfterIsSame);
                if(tempNbrOfTime > nbrOfTime)
                {
                    nbrR = tempNbrR;
                    nbrOfTime = tempNbrOfTime;
                }
                i += tempNbrOfTime - 1;
            }
            Console.WriteLine($"The value {nbrR} is repeated {nbrOfTime} times.");

            

            Random random = new Random();

            int[] numbers = new int[50];
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 20);
            }

            List<int> maxSeqOfIncrease = new List<int>();
            List<int> temp = new List<int>();

            for(int i = 0; i < numbers.Length; i++)
            {
                bool isIncreasing = true;
                do
                {
                    if (i + 1 >= numbers.Length)
                        break;
                    temp.Add(numbers[i]);
                    if (numbers[i] < numbers[i + 1])
                    {
                        i++;
                    }
                    else
                    {
                        isIncreasing = false;
                    }
                } while (isIncreasing && i + 1 < numbers.Length);
                if(temp.Count > maxSeqOfIncrease.Count)
                {
                    maxSeqOfIncrease.Clear();
                    for (int j = 0; j < temp.Count;j++)
                    {
                        maxSeqOfIncrease.Add(temp[j]);
                    }
                }
                temp.Clear();
            }

            for(int i = 0; i < maxSeqOfIncrease.Count; i++)
            {
                Console.Write($"{maxSeqOfIncrease[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            

            int[] numbers = new int[50];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 20);
            }

            List<int> maxSeqOfIncrease = new List<int>();

            maxSeqOfIncrease = MaxSeqOfIncreasingNumbers(numbers.ToList());

            for (int i = 0; i < maxSeqOfIncrease.Count; i++)
            {
                Console.Write($"{maxSeqOfIncrease[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            

            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            if(k < n)
            {
                for (int nombre = 0; nombre < 100; nombre++)
                {
                    int[] tab = new int[n];
                    for (int i = 0; i < tab.Length; i++)
                    {
                        tab[i] = random.Next(0, 10);
                        Console.Write(tab[i]);
                        Console.WriteLine();
                    }
                    int[] S = new int[k];
                    int maxSum = int.MinValue;
                    int tempSum = 0;
                    for (int i = 0; i < tab.Length - k + 1; i++)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            tempSum += tab[i + j];
                        }
                        if (tempSum > maxSum)
                        {
                            maxSum = tempSum;
                            for (int j = 0, l = i; j < k; j++, l++)
                            {
                                S[j] = tab[l];
                            }
                        }
                        tempSum = 0;
                    }
                    Console.WriteLine("The sum is : " + maxSum);
                    for (int i = 0; i < S.Length; i++)
                    {
                        Console.Write(S[i] + " ");
                    }
                }
            }
            

            int[] tab = new int[random.Next(0, 50)];
            for(int i = 0; i < tab.Length; i ++)
            {
                tab[i] = random.Next(0, 100);
            }
            SelectionSort(tab);
            foreach(int value in tab)
            {
                Console.Write(value + " ");
            }
            

            int[] tab = new int[random.Next(0, 50)];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = random.Next(-10, 10);
            }
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            List<int> index = new List<int>();
            List<int> tempIndex = new List<int>();
            int maxSum = int.MinValue, currentMaxSum, tempMaxSum;
            for(int i = 0; i < tab.Length; i++)
            { 
                tempMaxSum = currentMaxSum = tab[i];
                tempIndex.Add(i);
                for (int j = i + 1; j < tab.Length; j++) 
                {
                    tempMaxSum += tab[j];
                    if(tempMaxSum > currentMaxSum)
                    {
                        currentMaxSum = tempMaxSum;
                        if (tempIndex.Count != 0)
                            tempIndex.Clear();
                        for (int k = j; k >= i; k--)
                        {
                            tempIndex.Add(k);
                        }
                    }
                }
                if (currentMaxSum > maxSum)
                {
                    maxSum = currentMaxSum;
                    tempIndex.Reverse();
                    if (index.Count != 0)
                        index.Clear();
                    for(int j = 0; j < tempIndex.Count; j++)
                    {
                        index.Add(tempIndex[j]); 
                    }
                    tempIndex.Clear();
                }
            }
            for(int i = 0; i < index.Count;i++)
            {
                Console.Write(tab[index[i]] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Max sum is : " + maxSum);
            

            int[] tab = new int[random.Next(0, 50)];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = random.Next(-20, 20);
            }
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            IEnumerable<int> sortedTab = tab.OrderBy(value => value);
            int[] array = sortedTab.ToArray();
            int number = 0, ocurrence = 0;
            int tempNumber, tempOcurrence;
            for(int i = 0; i < array.Length;i++)
            {
                tempNumber = array[i];
                tempOcurrence = 1;
                for(int j = i; j < array.Length - 1; j++)
                {
                    if(array[j + 1] == tempNumber)
                    {
                        tempOcurrence++;
                    }
                    else
                    {
                        i = j;
                        break;
                    }
                }
                if(tempOcurrence > ocurrence)
                {
                    number = tempNumber;
                    ocurrence = tempOcurrence;
                }
            }
            Console.WriteLine($"The number {number} appeare {ocurrence} times.");
            

            int[] tab = new int[random.Next(0, 50)];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = random.Next(-10, 10);
            }
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.Write("Write a sum : ");
            int S = int.Parse(Console.ReadLine());
            List<int> index = new List<int>();
            List<int> tempIndex = new List<int>();
            int tempMaxSum;
            for(int i = 0; i < tab.Length; i++)
            { 
                tempMaxSum = tab[i];
                tempIndex.Add(i);
                for (int j = i + 1; j < tab.Length; j++) 
                {
                    tempMaxSum += tab[j];
                    if(tempMaxSum == S)
                    {
                        if (tempIndex.Count != 0)
                            tempIndex.Clear();
                        for (int k = j; k >= i; k--)
                        {
                            tempIndex.Add(k);
                        }
                        tempIndex.Reverse();
                        if (index.Count != 0)
                            index.Clear();
                        for (int k = 0; k < tempIndex.Count; k++)
                        {
                            index.Add(tempIndex[k]);
                        }
                        tempIndex.Clear();
                    }
                }
            }
            if (index.Count == 0)
            {
                Console.Write("The sum can't be found in this array");
            }
            else
            {
                for (int i = 0; i < index.Count; i++)
                {
                    Console.Write(tab[index[i]] + " ");
                }
            }
            

            Console.Write("Write the size of the matrix : ");
            int size = int.Parse(Console.ReadLine());
            int padValue =1;
            for (int i = 3; ; i *=3)
            {
                if (size <= i)
                    break;
                padValue++;
            }
            Console.WriteLine("Pad value is : " + padValue);

            int[,] tab1 = new int[size,size];
            int number = 1;
            /*
            for(int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    tab1[x, y] = number;
                    number++;
                }
            }
            */
            /*
            bool up = false;
            for (int y = 0; y < size; y++) 
            {
                if(!up)
                {
                    for(int x = 0; x < size; x++)
                    {
                        tab1[x, y] = number;
                        number++;
                    }
                }
                else
                {
                    for (int x = size - 1; x >= 0; x--)
                    {
                        tab1[x, y] = number;
                        number++;
                    }
                }
                up = !up;
            }
            */
            /*
            //Etat initial
            int x = size - 1;
            int y = 0;
            int xMin = size - 1;
            int yMin = 0;

            //Loop
            while(xMin != 0 || yMin != size)
            {
                tab1[x, y] = number++;                

                if(x + 1 >= size || y + 1 >= size)
                {    
                    if (xMin <= 0)
                    {
                        yMin++;
                        xMin = 0;     
                    }
                    else
                        xMin--;
                    x = xMin;
                    y = yMin;
                }
                else
                {
                    x++;
                    y++;
                }
            }
            */
            /*
            int value = size;
            bool change = true;
            int direction = 0;
            int x = 0, y = 0;
            while(value > 0)
            {
                for (int i = 0; i < value; i++)
                {
                    switch (direction)
                    {
                        case 0:
                            tab1[x, y] = number++;
                            if (i + 1 < value)
                                x++;
                            else
                                y++;
                            break;
                        case 1:
                            tab1[x, y] = number++;
                            if (i + 1 < value)
                                y++;
                            else
                                x--;
                            break;
                        case 2:
                            tab1[x, y] = number++;
                            if (i + 1 < value)
                                x--;
                            else
                                y--;
                            break;
                        case 3:
                            tab1[x, y] = number++;
                            if (i + 1 < value)
                                y--;
                            else
                                x++;
                            break;
                        default:
                            break;
                    }
                }
                if(change)
                    value--;
                change = !change;
                if (direction != 3)
                    direction++;
                else
                    direction = 0;
            }


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    switch(padValue)
                    {
                        case 2:
                            Console.Write($"{tab1[i, j],2} ");
                            break;
                        case 3:
                            Console.Write($"{tab1[i, j],3} ");
                            break;
                        case 4:
                            Console.Write($"{tab1[i, j],4} ");
                            break;
                        default:
                            Console.Write($"{tab1[i, j]} ");
                            break;
                    }
                }
                Console.WriteLine();
            }
            

            Console.Write("Write the lenght : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Write the width : ");
            int m = int.Parse(Console.ReadLine());

            if (n < 3)
                n = 10;
            if (m < 3)
                m = 5;

            int[,] rectangle = new int[n, m];
            for(int i = 0; i < rectangle.GetLength(0);i++)
            {
                for (int j = 0; j < rectangle.GetLength(1); j++)
                {
                    rectangle[i, j] = random.Next(0, 10);
                }
            }

            int maxSum = int.MinValue;
            int[,] platform = new int[3,3];
            for(int x = 0; x < rectangle.GetLength(0) - 3; x++)
            {
                for (int y = 0; y < rectangle.GetLength(1) - 3; y++)
                {
                    int tempSum;
                    tempSum = rectangle[x, y] + rectangle[x + 1, y] + rectangle[x + 2, y];
                    tempSum += rectangle[x, y + 1] + rectangle[x + 1, y + 1] + rectangle[x + 2, y + 1];
                    tempSum += rectangle[x, y + 2] + rectangle[x + 1, y + 2] + rectangle[x + 2, y + 2];
                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        for(int i = 0; i <platform.GetLength(0); i++)
                        {
                            for (int j = 0; j < platform.GetLength(1); j++)
                            {
                                platform[i, j] = rectangle[x + i, y + j];
                            }
                        }
                    }
                }
            }
            Console.WriteLine("The platform with the max sum is : " + maxSum);
            for (int i = 0; i < platform.GetLength(0); i++)
            {
                for (int j = 0; j < platform.GetLength(1); j++)
                {
                    Console.Write($"{platform[i, j],2}");
                }
                Console.WriteLine();
            }
            

            string[,] words = new string[4, 4] {
                {"ah","ah","bh","bh" },
            {"nn","ah","ah","bh" },
            { "nn","nn","ah","bh"},
            {"nn","nn","bh","ah" },
            };
            for(int i = 0; i < words.GetLength(0); i++)
            {
                for (int j = 0; j < words.GetLength(1); j++)
                {
                    Console.Write($"{words[i, j],2}|");
                }
                Console.WriteLine();
            }
            string word = "";
            int tempNbrOfTime = 0;
            string tempWord = "";
            int nbrOfTime = 0;
            for (int i = 0; i < words.GetLength(0); i++)
            {
                for (int j = 0; j < words.GetLength(1); j++)
                {
                    tempWord = words[i, j];
                    tempNbrOfTime = 1;
                    bool numberAfterIsSame = true;
                    do
                    {
                        if (i + tempNbrOfTime < words.GetLength(0))
                        {
                            if (tempWord == words[i + tempNbrOfTime, j])
                            {
                                tempNbrOfTime++;
                            }
                            else
                            {
                                numberAfterIsSame = false;
                            }
                        }
                        else
                            break;
                    } while (numberAfterIsSame);
                    if (tempNbrOfTime > nbrOfTime)
                    {
                        word = tempWord;
                        nbrOfTime = tempNbrOfTime;
                    }
                    i += tempNbrOfTime - 1;
                }
            }
            
            tempNbrOfTime = 0;
            tempWord = "";            
            for (int i = 0; i < words.GetLength(0); i++)
            {
                for (int j = 0; j < words.GetLength(1); j++)
                {
                    tempWord = words[i, j];
                    tempNbrOfTime = 1;
                    bool numberAfterIsSame = true;
                    do
                    {
                        if (j + tempNbrOfTime < words.GetLength(0))
                        {
                            if (tempWord == words[i, j + tempNbrOfTime])
                            {
                                tempNbrOfTime++;
                            }
                            else
                            {
                                numberAfterIsSame = false;
                            }
                        }
                        else
                            break;
                    } while (numberAfterIsSame);
                    if (tempNbrOfTime > nbrOfTime)
                    {
                        word = tempWord;
                        nbrOfTime = tempNbrOfTime;
                    }
                    j += tempNbrOfTime - 1;
                }

                tempNbrOfTime = 0;
                tempWord = "";
                string lastWord = "";
                //Etat initial
                int x = words.GetLength(0) - 1;
                int y = 0;
                int xMin = words.GetLength(0) - 1;
                int yMin = 0;

                //Loop
                while (xMin != 0 || yMin != words.GetLength(1))
                {
                    tempWord = words[x, y];
                    if (lastWord == tempWord)
                    {
                        tempNbrOfTime++;
                    }
                    else
                    {
                        tempNbrOfTime = 1;
                        lastWord = tempWord;
                    }
                    if (x + 1 >= words.GetLength(1) || y + 1 >= words.GetLength(1))
                    {
                        if (xMin <= 0)
                        {
                            yMin++;
                            xMin = 0;
                        }
                        else
                            xMin--;
                        x = xMin;
                        y = yMin;
                        if(tempNbrOfTime > nbrOfTime)
                        {
                            word = tempWord;
                            nbrOfTime = tempNbrOfTime;
                        }
                        lastWord = "";
                        tempNbrOfTime = 0;
                    }
                    else
                    {
                        x++;
                        y++;
                    }                    
                }
            }
            Console.WriteLine($"The word {word} is repeated {nbrOfTime} times.");
            

            Console.Write("Write a word : ");
            string word = Console.ReadLine();
            foreach(char letter in word)
            {
                Console.WriteLine($"{(int)letter - (int)'A'}");
            }
            

            int[] tab = new int[random.Next(0, 50)];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = random.Next(-20, 20);
            }
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            IEnumerable<int> sortedTab = tab.OrderBy(value => value);
            List<int>array = sortedTab.ToList();
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
            Console.Write("Write the number you are looking for : ");
            int n = int.Parse(Console.ReadLine());
            int index = array.BinarySearch(n);
            if (n >= 0)
                Console.WriteLine($"The number {n} is in the array at the index {index} => {array[index]}");
            else
                Console.WriteLine("The number is not in the array");
            

            int[] tab = new int[random.Next(0, 50)];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = random.Next(-20, 20);
            }
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            //MergeSort(tab);
            //QuickSort(tab,0,tab.Length - 1);

            Console.WriteLine("Tab is sorted :");
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            

            int[] primes = Eratosthene(10000000);
            Console.WriteLine("The prime number between 1 and 10,000,000 are :");
            foreach(int number in primes)
            {
                Console.Write(number + " ");
            }
            

            Console.Write("Array lenght : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Sum : ");
            int s = int.Parse(Console.ReadLine());
            bool sumFind = false;
            List<int> sum = new List<int>();


            int[] tab = new int[n];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = random.Next(0, 20);
            }
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            int sums = FindSumInArray(tab, 0, s, out sumFind);

            /* First try
            List<int[][]> possibilities = new List<int[][]>();
            for(int i = 1; i <= tab.Length; i++)
            {
                int[][] temp = new int[n+(i != 1?n:0)][];
                for(int j = 0; j < temp.GetLength(0); j++)
                {
                    temp[j] = new int[i];
                }

                int lInit = 0;
                int pos = (i-1) * 4 + (i == 1?1:0);
                for (int j = 0; j < tab.Length - (i - 1); j++)
                {

                }
                possibilities.Add(temp);
            }
            foreach (int[][] tab1 in possibilities)
            {
                for (int i = 0; i < tab1.Length; i++)
                {
                    for (int j = 0; j < tab1[i].Length; j++)
                    {
                        if (j > 0)
                            Console.Write(",");
                        Console.Write(tab1[i][j]);
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
            }

            for(int i = 0; i < possibilities.Count; i++)
            {
                for (int j = 0; j < possibilities[i].Length; j++)
                {
                    for (int k = 0; k < possibilities[i][j].Length; k++)
                    {
                        if (possibilities[i][j][k] == s)
                        {
                            sumFind = true;
                            sum.Add(possibilities[i][j][k]);
                        }
                    }
                }
                if (sumFind)
                    break;
            }
            */
            /*
            if(sumFind)
            {
                Console.Write("The sum have been found : ");
                foreach(int number in sum)
                {
                    Console.Write(number + "+");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The sum haven't been found !");
            }

            

            Console.Write("Array lenght : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k : ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Sum : ");
            int s = int.Parse(Console.ReadLine());
            bool sumFind = false;
            int[] result = new int[k];
            if (k < n)
            {
                int[] tab = new int[n];
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = random.Next(0, 20);
                }
                foreach (int value in tab)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();

                
            }
            Console.Write($"S = {s}, K = {k} => {sumFind}");
            if (sumFind)
            {
                Console.WriteLine(" :");
                foreach (int number in result)
                {
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
            


            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());

            int[][] subsets = new int[(int)Math.Pow(n,k)][];
            for (int j = 0; j < subsets.Length; j++)
            {
                if (j == 0)
                {
                    subsets[j] = new int[k];
                    for (int l = 0; l < subsets[j].Length; l++)
                        subsets[j][l] = 1;
                }
                else
                    subsets[j] = new int[k];
            }
            int i = 1;
            while (subsets[subsets.Length - 1][0] != n)
            {
                for (int l = 0; l < subsets[i - 1].Length; l++)
                {
                    Console.Write(subsets[i - 1][l] + " ");
                }
                Console.WriteLine();
                int value = subsets[i - 1][subsets[i].Length - 1] + 1;
                if(value > n)
                {
                    for (int j = subsets[i].Length - 1; j >= 0; j--)
                    {
                        if (subsets[i][j] == 0)
                        {
                            if (j != subsets[i].Length - 1)
                            {
                                if (subsets[i][j] > n)
                                {
                                    subsets[i][j] = 1;
                                    subsets[i][j - 1] = subsets[i - 1][j - 1] + 1;
                                }
                                else
                                    subsets[i][j] = subsets[i - 1][j];
                            }
                            else
                            {
                                subsets[i][j] = 1;
                                subsets[i][j - 1] = subsets[i - 1][j - 1] + 1;
                            }
                        }
                        else
                        {
                            if (j != subsets[i].Length - 1)
                            {
                                if (subsets[i][j] > n)
                                {
                                    subsets[i][j] = 1;
                                    subsets[i][j - 1] = subsets[i - 1][j - 1] + 1;
                                }
                            }
                            else
                            {
                                subsets[i][j] = 1;
                                subsets[i][j - 1] = subsets[i - 1][j - 1] + 1;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < subsets[i].Length; j++)
                    {
                        if (j != subsets[i].Length - 1)
                            subsets[i][j] = subsets[i - 1][j];
                        else
                            subsets[i][j] = subsets[i - 1][j] + 1;
                    }
                }
                i++;
            }

            foreach(int[] set in subsets)
            {
                Console.Write("{");
                int j = 0;
                foreach(int number in set)
                {
                    Console.Write(number);
                    if (j != set.Length - 1)
                        Console.Write(",");
                    j++;
                }
                Console.WriteLine("}");
            }
            

            //Chapter 8 : Numeral Systems

            int number = random.Next(0, 1000000);
            char[] binary = DecimalToBinary(number);
            Console.Write($"{number} to binary : ");
            foreach(char bin in binary)
            {
                Console.Write(bin);
            }
            Console.WriteLine();

            
            Console.Write("Write a binary number : ");
            string binary = Console.ReadLine();
            int number = BinaryToDecimal(binary);

            Console.WriteLine($"{number} to binary : {binary}");
            

            int number = random.Next(0, 1000000);
            string hexadecimal = DecimalToHexadecimal(number);
            Console.WriteLine($"{number} to hexa : {hexadecimal}");

            
            Console.Write("Write an hexadecimal number : ");
            string hexa = Console.ReadLine();
            int number = HexadecimalToDecimal(hexa);

            Console.WriteLine($"{hexa} to decimal : {number}");
            
            Console.Write("Write an hexadecimal number : ");
            string hexa = Console.ReadLine();
            string binary = HexadecimalToBinary(hexa);

            Console.WriteLine($"{hexa} to binary : {binary}");
            

            Console.Write("Write a binary number : ");
            string binary = Console.ReadLine();
            string hexa = BinaryToHexadecimal(binary);

            Console.WriteLine($"{binary} to hexa : {hexa}");
            
            Console.Write("Write a binary number : ");
            string binary = Console.ReadLine();
            int number = BinaryToDecimalHorner(binary);
            Console.WriteLine($"{binary} to decimal : {number}");

            Console.Write("Write a number N in an S based numeral system : ");
            string number = Console.ReadLine();
            Console.Write("Write the S based numeral system : ");
            int sBased = int.Parse(Console.ReadLine());
            Console.Write("Write the D based numeral system : ");
            int dBased = int.Parse(Console.ReadLine());
            string result = SBasedNumeralToDBasedNumeral(number, sBased, dBased);
            Console.WriteLine($"The number {number} in {sBased} numeral system is {result} in the {dBased} numeral system");

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

            int max = 100, min = -100;
            Console.Write("Write a number : ");
            float number = (float)random.NextDouble() * (max - min) + min;
            BigInteger sign = 0;
            string exponent = "", mantissa = "";
            string result = DecimalFloatToBinary(number,out sign, out exponent, out mantissa);

            Console.WriteLine($"The number {number} is : sign = {sign}, exponent = {exponent}, mantissa = {mantissa}");
            */

            //Chapitre 9 : Methods



        }
    }
}
