using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_7_Arrays
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
            Exo16.Execute();
            Exo17.Execute();
            Exo18.Execute();
            Exo19.Execute();
            Exo20.Execute();
            Exo21.Execute();
            Exo22.Execute();
            Exo23.Execute();
            Exo24.Execute();
            Exo25.Execute();
        }
    }

    /// <summary>
    /// Write a program, which creates an array of 20 elements of type integer and initializes each of the elements with a value equals to the index of the element multiplied by 5. 
    /// Print the elements to the console.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            int[] tab = new int[20];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = i * 5;
            }
            foreach (int number in tab)
            {
                Console.WriteLine(number);
            }
        }
    }

    /// <summary>
    /// Write a program, which reads two arrays from the console and checks whether they are equal (two arrays are equal when they are of equal length and all of their elements, which have the same index, are equal).
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Console.Write("First array lenght : ");
            int length1 = int.Parse(Console.ReadLine());
            int[] numbers1 = new int[length1];
            for (int i = 0; i < numbers1.Length; i++)
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
            if (numbers1.Length == numbers2.Length)
            {
                for (int i = 0; i < numbers2.Length; i++)
                {
                    if (numbers1[i] != numbers2[i])
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
        }
    }

    /// <summary>
    /// Write a program, which compares two arrays of type char lexicographically (character by character) and checks, which one is first in the lexicographical order.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            char[] sentence1, sentence2;
            Console.Write("Write something : ");
            string text1 = Console.ReadLine();
            Console.Write("Write something : ");
            string text2 = Console.ReadLine();
            sentence1 = text1.ToCharArray();
            sentence2 = text2.ToCharArray();

            bool sentence1BeforeSentence2 = true;
            for (int i = 0; i < sentence1.Length && i < sentence2.Length; i++)
            {
                if (sentence1[i] > sentence2[i])
                {
                    sentence1BeforeSentence2 = false;
                    break;
                }
            }

            Console.WriteLine($"Sentence 1 is before sentence 2 ? {sentence1BeforeSentence2}");
        }
    }

    /// <summary>
    /// Write a program, which finds the maximal sequence of consecutive equal elements in an array. 
    /// E.g.: {1, 1, 2, 3, 2, 2, 2, 1} => {2, 2, 2}.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            int[] numbers = new int[20] { 5, 4, 2, 7, 7, 7, 7, 7, 2, 4, 2, 5, 4, 2, 2, 2, 2, 1, 3, 5 };
            int tempNbrR, tempNbrOfTime = 0; ;
            int nbrR = 0, nbrOfTime = 0;
            for (int i = 0; i < numbers.Length; i++)
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
                if (tempNbrOfTime > nbrOfTime)
                {
                    nbrR = tempNbrR;
                    nbrOfTime = tempNbrOfTime;
                }
                i += tempNbrOfTime - 1;
            }
            Console.WriteLine($"The value {nbrR} is repeated {nbrOfTime} times.");
        }
    }

    /// <summary>
    /// Write a program, which finds the maximal sequence of consecutively placed increasing integers. 
    /// Example: {3, 2, 3, 4, 2, 2, 4} => {2, 3, 4}.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            Random random = new Random();

            int[] numbers = new int[50];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 20);
            }

            List<int> maxSeqOfIncrease = new List<int>();
            List<int> temp = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
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
                if (temp.Count > maxSeqOfIncrease.Count)
                {
                    maxSeqOfIncrease.Clear();
                    for (int j = 0; j < temp.Count; j++)
                    {
                        maxSeqOfIncrease.Add(temp[j]);
                    }
                }
                temp.Clear();
            }

            for (int i = 0; i < maxSeqOfIncrease.Count; i++)
            {
                Console.Write($"{maxSeqOfIncrease[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }

    /// <summary>
    /// Write a program, which finds the maximal sequence of increasing elements in an array arr[n]. 
    /// It is not necessary the elements to be consecutively placed. 
    /// E.g.: {9, 6, 2, 7, 4, 7, 6, 5, 8, 4} => {2, 4, 6, 8}.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Random random = new Random();

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
        }

        public static List<int> MaxSeqOfIncreasingNumbers(List<int> tab)
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
    }

    /// <summary>
    /// Write a program, which reads from the console two integer numbers N and K (K<(>)N) and array of N integers. 
    /// Find those K consecutive elements in the array, which have maximal sum.
    /// </summary>
    public static class Exo7
    { 
        public static void Execute()
        {
            Random random = new Random();

            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            if (k < n)
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
        }
    }

    /// <summary>
    /// Sorting an array means to arrange its elements in an increasing (or decreasing) order. 
    /// Write a program, which sorts an array using the algorithm "selection sort".
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            Random random = new Random();

            int[] tab = new int[random.Next(0, 50)];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = random.Next(0, 100);
            }
            SelectionSort(tab);
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
        }

        public static void SelectionSort(int[] integerArray)
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
    }

    /// <summary>
    /// Write a program, which finds a subsequence of numbers with maximal sum. 
    /// E.g.: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} => 11
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Random random = new Random();

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
            for (int i = 0; i < tab.Length; i++)
            {
                tempMaxSum = currentMaxSum = tab[i];
                tempIndex.Add(i);
                for (int j = i + 1; j < tab.Length; j++)
                {
                    tempMaxSum += tab[j];
                    if (tempMaxSum > currentMaxSum)
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
                    for (int j = 0; j < tempIndex.Count; j++)
                    {
                        index.Add(tempIndex[j]);
                    }
                    tempIndex.Clear();
                }
            }
            for (int i = 0; i < index.Count; i++)
            {
                Console.Write(tab[index[i]] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Max sum is : " + maxSum);
        }
    }

    /// <summary>
    /// Write a program, which finds the most frequently occurring element in an array. 
    /// Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} => 4 (5 times).
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            Random random = new Random();

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
            for (int i = 0; i < array.Length; i++)
            {
                tempNumber = array[i];
                tempOcurrence = 1;
                for (int j = i; j < array.Length - 1; j++)
                {
                    if (array[j + 1] == tempNumber)
                    {
                        tempOcurrence++;
                    }
                    else
                    {
                        i = j;
                        break;
                    }
                }
                if (tempOcurrence > ocurrence)
                {
                    number = tempNumber;
                    ocurrence = tempOcurrence;
                }
            }
            Console.WriteLine($"The number {number} appeare {ocurrence} times.");
        }
    }

    /// <summary>
    /// Write a program to find a sequence of neighbor numbers in an array, which has a sum of certain number S. 
    /// Example: {4, 3, 1, 4, 2, 5, 8}, S=11 => {4, 2, 5}.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            Random random = new Random();

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
            for (int i = 0; i < tab.Length; i++)
            {
                tempMaxSum = tab[i];
                tempIndex.Add(i);
                for (int j = i + 1; j < tab.Length; j++)
                {
                    tempMaxSum += tab[j];
                    if (tempMaxSum == S)
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
        }
    }

    /// <summary>
    /// Write a program, which creates square matrices like those in the figures below and prints them formatted to the console.
    /// The size of the matrices will be read from the console. 
    /// See the examples for matrices with size of 4 x 4 and make the other sizes in a similar fashion: ...
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {
            Example1();
            Example2();
            Example3();
            Example4();
        }

        public static void Example1()
        {
            Console.Write("Write the size of the matrix : ");
            int size = int.Parse(Console.ReadLine());
            int[,] tab1 = new int[size, size];
            int number = 1;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    tab1[x, y] = number;
                    number++;
                }
            }
        }

        public static void Example2()
        {
            Console.Write("Write the size of the matrix : ");
            int size = int.Parse(Console.ReadLine());
            int[,] tab1 = new int[size, size];
            int number = 1;

            bool up = false;
            for (int y = 0; y < size; y++)
            {
                if (!up)
                {
                    for (int x = 0; x < size; x++)
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
        }

        public static void Example3()
        {
            Console.Write("Write the size of the matrix : ");
            int size = int.Parse(Console.ReadLine());
            int[,] tab1 = new int[size, size];
            int number = 1;

            //Etat initial
            int x = size - 1;
            int y = 0;
            int xMin = size - 1;
            int yMin = 0;

            //Loop
            while (xMin != 0 || yMin != size)
            {
                tab1[x, y] = number++;

                if (x + 1 >= size || y + 1 >= size)
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
        }

        public static void Example4()
        {
            Console.Write("Write the size of the matrix : ");
            int size = int.Parse(Console.ReadLine());
            int padValue = 1;
            for (int i = 3; ; i *= 3)
            {
                if (size <= i)
                    break;
                padValue++;
            }
            Console.WriteLine("Pad value is : " + padValue);

            int[,] tab1 = new int[size, size];
            int number = 1;

            int value = size;
            bool change = true;
            int direction = 0;
            int x = 0, y = 0;
            while (value > 0)
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
                if (change)
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
                    switch (padValue)
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
        }
    }

    /// <summary>
    /// Write a program, which creates a rectangular array with size of n by m elements.
    /// The dimensions and the elements should be read from the console.
    /// Find a platform with size of(3, 3) with a maximal sum.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {
            Random random = new Random();

            Console.Write("Write the lenght : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Write the width : ");
            int m = int.Parse(Console.ReadLine());

            if (n < 3)
                n = 10;
            if (m < 3)
                m = 5;

            int[,] rectangle = new int[n, m];
            for (int i = 0; i < rectangle.GetLength(0); i++)
            {
                for (int j = 0; j < rectangle.GetLength(1); j++)
                {
                    rectangle[i, j] = random.Next(0, 10);
                }
            }

            int maxSum = int.MinValue;
            int[,] platform = new int[3, 3];
            for (int x = 0; x < rectangle.GetLength(0) - 3; x++)
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
                        for (int i = 0; i < platform.GetLength(0); i++)
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
        }
    }

    /// <summary>
    /// Write a program, which finds the longest sequence of equal string elements in a matrix.
    /// A sequence in a matrix we define as a set of neighbor elements on the same row, column or diagonal.
    /// </summary>
    public static class Exo14
    {
        public static void Execute()
        {
            string[,] words = new string[4, 4] {
                {"ah","ah","bh","bh" },
            {"nn","ah","ah","bh" },
            { "nn","nn","ah","bh"},
            {"nn","nn","bh","ah" },
            };
            for (int i = 0; i < words.GetLength(0); i++)
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
                        if (tempNbrOfTime > nbrOfTime)
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
        }
    }

    /// <summary>
    /// Write a program, which creates an array containing all Latin letters. 
    /// The user inputs a word from the console and as result the program prints to the console the indices of the letters from the word.
    /// </summary>
    public static class Exo15
    {
        public static void Execute()
        {
            Console.Write("Write a word : ");
            string word = Console.ReadLine();
            foreach (char letter in word)
            {
                Console.WriteLine($"{(int)letter - (int)'A'}");
            }
        }
    }

    /// <summary>
    /// Write a program, which uses a binary search in a sorted array of integer numbers to find a certain element.
    /// </summary>
    public static class Exo16
    {
        public static void Execute()
        {
            Random random = new Random();

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
            List<int> array = sortedTab.ToList();
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
        }
    }

    /// <summary>
    /// Write a program, which sorts an array of integer elements using a "merge sort" algorithm.
    /// </summary>
    public static class Exo17
    {
        public static void Execute()
        {
            Random random = new Random();

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

            MergeSort(tab);

            Console.WriteLine("Tab is sorted :");
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
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
    }

    /// <summary>
    /// Write a program, which sorts an array of integer elements using a "quick sort" algorithm.
    /// </summary>
    public static class Exo18
    {
        public static void Execute()
        {
            Random random = new Random();

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

            QuickSort(tab,0,tab.Length - 1);

            Console.WriteLine("Tab is sorted :");
            foreach (int value in tab)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
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
    }

    /// <summary>
    /// Write a program, which finds all prime numbers in the range [1…10,000,000].
    /// </summary>
    public static class Exo19
    {
        public static void Execute()
        {

            int[] primes = Eratosthene(10000000);
            Console.WriteLine("The prime number between 1 and 10,000,000 are :");
            foreach (int number in primes)
            {
                Console.Write(number + " ");
            }
        }

        public static int[] Eratosthene(int limite)
        {
            List<int> result = new List<int>();
            bool[] A = new bool[limite];
            for (int i = 0; i < A.Length; i++)
                A[i] = true;
            double sqrtLimite = Math.Sqrt(limite);
            for (int i = 2; i < sqrtLimite; i++)
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
    }

    /// <summary>
    /// Write a program, which checks whether there is a subset of given array of N elements, which has a sum S.
    /// The numbers N, S and the array values are read from the console. 
    /// Same number can be used many times.
    /// Example: { 2, 1, 2, 4, 3, 5, 2, 6}, S = 14 => yes(1 + 2 + 5 + 6 = 14)
    /// </summary>
    public static class Exo20
    {
        public static void Execute()
        {
            Random random = new Random();

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

            //int sums = FindSumInArray(tab, 0, s, out sumFind);

            // First try
            List<int[][]> possibilities = new List<int[][]>();
            for (int i = 1; i <= tab.Length; i++)
            {
                int[][] temp = new int[n + (i != 1 ? n : 0)][];
                for (int j = 0; j < temp.GetLength(0); j++)
                {
                    temp[j] = new int[i];
                }

                int lInit = 0;
                int pos = (i - 1) * 4 + (i == 1 ? 1 : 0);
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

            for (int i = 0; i < possibilities.Count; i++)
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

            if (sumFind)
            {
                Console.Write("The sum have been found : ");
                foreach (int number in sum)
                {
                    Console.Write(number + "+");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The sum haven't been found !");
            }
        }
    }

    /// <summary>
    /// Write a program which by given N numbers, K and S, finds K elements out of the N numbers, the sum of which is exactly S or says it is not possible.
    /// Example: { 3, 1, 2, 4, 9, 6}, S = 14, K = 3 => yes(1 + 2 + 4 = 14)
    /// </summary>
    public static class Exo21
    {
        public static void Execute()
        {
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
        }
    }

    /// <summary>
    /// Write a program, which reads an array of integer numbers from the console and removes a minimal number of elements in such a way that the remaining array is sorted in an increasing order.
    /// Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} => {1, 3, 3, 4, 5}
    /// </summary>
    public static class Exo22
    {
        public static void Execute()
        {

        }
    } //TODO

    /// <summary>
    /// Write a program, which reads the integer numbers N and K from the console and prints all variations of K elements of the numbers in the interval [1…N]. 
    /// Example: N = 3, K = 2 => {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}.
    /// </summary>
    public static class Exo23
    {
        public static void Execute()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());

            int[][] subsets = new int[(int)Math.Pow(n, k)][];
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
                if (value > n)
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

            foreach (int[] set in subsets)
            {
                Console.Write("{");
                int j = 0;
                foreach (int number in set)
                {
                    Console.Write(number);
                    if (j != set.Length - 1)
                        Console.Write(",");
                    j++;
                }
                Console.WriteLine("}");
            }
        }
    }

    /// <summary>
    /// Write a program, which reads an integer number N from the console and prints all combinations of K elements of numbers in range [1 … N]. 
    /// Example: N = 5, K = 2 => {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}.
    /// </summary>
    public static class Exo24
    {
        public static void Execute()
        {

        }
    } //c.f Exo 23

    /// <summary>
    /// Write a program, which finds in a given matrix the largest area of equal numbers. 
    /// We define an area in the matrix as a set of neighbor cells (by row and column). 
    /// Here is one example with an area containing 13 elements with equal value of 3:...
    /// </summary>
    public static class Exo25
    {
        public static void Execute()
        {

        }
    } //Already done on antoher project with an implementation of A* Pathfinding algorithm
}
