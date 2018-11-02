using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_16_Linear_Data_Structures
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
            Exo10.Execute();
        }

        public static void PrintIntegerArray(int[] tab)
        {
            Console.WriteLine("Tab :");

            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(" " + tab[i] + " |");
            }

            Console.WriteLine();
        }

        public static void PrintIntegerArray(List<int> tab)
        {
            PrintIntegerArray(tab.ToArray());
        }
    }

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. 
    /// The sequence ends when empty line is entered.
    /// Calculate and print the sum and the average of the sequence. 
    /// Keep the sequence in List<int>.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            List<int> sequence = new List<int>();
            Console.WriteLine("Write an integer and press enter, do it multiple times, when you are pissed off, just write nothing and press enter :");
            string text = Console.ReadLine();
            while(text != "")
            {
                sequence.Add(int.Parse(text));
                text = Console.ReadLine();
            }

            int sum = 0;
            int average = 0;
            for(int i = 0; i < sequence.Count;i++)
            {
                sum += sequence[i];
            }
            average = sum / sequence.Count;

            Console.WriteLine("Sum : " + sum + "\n" +
                "Average : " + average);
        }
    }

    /// <summary>
    /// Write a program, which reads from the console N integers and prints them in reversed order. 
    /// Use the Stack<int> class.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Random random = new Random();
            int n = random.Next(2, 50);
            Stack<int> stack = new Stack<int>(n);
            Console.WriteLine("Write " + n + " numbers : ");
            for(int i = 0; i < n;i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i <= stack.Count; i++)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. 
    /// The sequence ends when an empty line is entered. 
    /// Print the sequence sorted in ascending order.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            List<int> sequence = new List<int>();
            Console.WriteLine("Write an integer and press enter, do it multiple times, when you are pissed off, just write nothing and press enter :");
            string text = Console.ReadLine();
            while (text != "")
            {
                sequence.Add(int.Parse(text));
                text = Console.ReadLine();
            }

            IOrderedEnumerable<int> result = sequence.OrderBy(number => number);
            sequence = result.ToList<int>();

            for(int i = 0; i < sequence.Count;i++)
            {
                Console.WriteLine(sequence[i] + " ");
            }
        }
    }

    /// <summary>
    /// Write a method that finds the longest subsequence of equal numbers in a given List<int> and returns the result as new List<int>.
    /// Write a program to test whether the method works correctly.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            Random random = new Random();
            List<int> list1 = new List<int>();
            List<int> result1 = LongestSubsequence(list1);

            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            list2.Add(7);
            list2.Add(8);
            list2.Add(9);
            List<int> result2= LongestSubsequence(list2);

            List<int> list3 = new List<int>();
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5,5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            list3.Add(random.Next(-5, 5));
            List<int> result3 = LongestSubsequence(list3);

            List<int> list4 = new List<int>();
            for (int i = 0; i < 1000;i++)
                list4.Add(random.Next(0, 5));
            List<int> result4 = LongestSubsequence(list4);

            ShowArray(result1);
            ShowArray(result2);
            ShowArray(result3);
            ShowArray(result4);
        }

        public static List<int> LongestSubsequence(List<int> sequence)
        {
            if (sequence.Count == 0)
                return null;

            int current = sequence[0];
            int startIndex = 0;
            int endIndex = 1;
            List<int> result = new List<int>();

            for(int i = 1; i < sequence.Count;i++)
            {
                if(sequence[i] != current)
                {
                    if(i - startIndex > result.Count)
                    {
                        endIndex = i;
                        result.Clear();
                        for (int j = startIndex; j < endIndex; j++) 
                        {
                            result.Add(current);
                        }
                    }
                    current = sequence[i];
                    startIndex = i;
                }
            }

            return result;
        }

        public static void ShowArray(List<int> array)
        {
            if (array == null)
                return;
            Console.WriteLine("Array : ");
            for(int i = 0; i < array.Count;i++)
            {
                Console.Write(" : " + array[i]);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Write a program, which removes all negative numbers from a sequence.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            Random random = new Random();
            List<int> sequence = new List<int>(100);
            for(int i = 0; i < sequence.Capacity;i++)
            {
                sequence.Add(random.Next(-100, 100));
            }
            Predicate<int> inferiorThanZero = InferiorThanZero;
            sequence.RemoveAll(inferiorThanZero);

            Console.WriteLine("Array :");
            for(int i = 0; i < sequence.Count;i++)
            {
                Console.Write(sequence[i] + " | ");
            }
        }

        public static bool InferiorThanZero(int number)
        {
            if (number >= 0)
                return false;
            else
                return true;
        }
    }

    /// <summary>
    /// Write a program that removes from a given sequence all numbers that appear an odd count of times.
    /// </summary>
    public static class Exo6
    {
        static int minNumber = 0;
        static int maxNumber = 20;

        public static void Execute()
        {
            long firstTick = DateTime.Now.Ticks;

            Random random = new Random();
            int[] sequence = new int[50];

            Console.WriteLine("First tab :");
            for(int i = 0; i < sequence.Length;i++)
            {
                sequence[i] = random.Next(minNumber, maxNumber);
                Console.Write(" " + sequence[i] + " |");
            }

            Console.WriteLine();

            Dictionary<int, int> numberAppeared = new Dictionary<int, int>(maxNumber);

            for(int i = 0; i < sequence.Length;i++)
            {
                if(numberAppeared.ContainsKey(sequence[i]))
                {
                    numberAppeared[sequence[i]]++;
                }
                else
                {
                    numberAppeared.Add(sequence[i], 1);
                }
            }

            List<int> evenNumbers = new List<int>();
            for(int i = 0; i < sequence.Length;i++)
            {
                if(numberAppeared[sequence[i]] % 2 == 0)
                {
                    evenNumbers.Add(sequence[i]);
                }
            }

            Console.WriteLine("Final tab :");
            for (int i = 0; i < evenNumbers.Count;i++)
            {
                Console.Write(" " + evenNumbers[i] + " |");
            }

            Console.WriteLine();

            Dictionary<int, int>.KeyCollection keys = numberAppeared.Keys;
            foreach(int key in keys)
            {
                Console.WriteLine("The number " + key + " appears " + numberAppeared[key] + " time(s) !");
            }

            long lastTick = DateTime.Now.Ticks;

            float time = (lastTick - firstTick) / 1000000.0f;

            Console.WriteLine("The operation lasted : " + time + " sec");
        }
    }

    /// <summary>
    /// Write a program that finds in a given array of integers (in the range [0…1000]) how many times each of them occurs.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            Random random = new Random();
            int[] sequence = new int[50];
            for(int i = 0; i < sequence.Length;i++)
            {
                sequence[i] = random.Next(0, 1001);
            }

            Console.WriteLine("First tab :");
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(" " + sequence[i] + " |");
            }

            Console.WriteLine();

            int[] numbersAppearance = new int[1001];
            for(int i = 0; i < sequence.Length;i++)
            {
                numbersAppearance[sequence[i]]++;
            }

            for (int i = 0; i < numbersAppearance.Length; i++)
            {
                if (numbersAppearance[i] != 0)
                {
                    Console.WriteLine("The number " + i  + " appears " + numbersAppearance[i] + " time(s)");
                }
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
    /// Write a program that finds the majorant of given array and prints it. 
    /// If it does not exist, print "The majorant does not exist!".
    /// </summary>
    public static class Exo8
    {
        static int N = 20;

        public static void Execute()
        {
            Random random = new Random();
            List<int> sequence = new List<int>(N);
            for(int i = 0; i < sequence.Capacity;i++)
            {
                sequence.Add(random.Next(0, 2));
            }

            Program.PrintIntegerArray(sequence);

            sequence.Sort();

            Program.PrintIntegerArray(sequence);

            int currentNumber = -1;
            int numberAppearance = 0;
            for(int i = 0; i < sequence.Count;i++)
            {
                if(i >= (N/2))
                {
                    if(currentNumber != sequence[i])
                    {
                        Console.WriteLine("The majorant does not exist!");
                        break;
                    }
                    else
                    {
                        numberAppearance++;
                        if(numberAppearance >= (N / 2 + 1))
                        {
                            Console.WriteLine("The majorant is " + currentNumber);
                            break;
                        }
                    }
                }
                else
                {
                    if(currentNumber != sequence[i])
                    {
                        currentNumber = sequence[i];
                        numberAppearance = 1;
                    }
                    else
                    {
                        numberAppearance++;
                        if (numberAppearance >= (N / 2 + 1))
                        {
                            Console.WriteLine("The majorant is " + currentNumber);
                            break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// We are given the following sequence:
    ///   S1 = N;
    ///   S2 = S1 + 1;
    ///   S3 = 2* S1 + 1;
    ///   S4 = S1 + 2;
    ///   S5 = S2 + 1;
    ///   S6 = 2* S2 + 1;
    ///   S7 = S2 + 2;
    /// Using the Queue<T> class, write a program which by given N prints on the console the first 50 elements of the sequence.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            Queue<int> suite = new Queue<int>();
            Console.Write("Write N : ");
            int N = int.Parse(Console.ReadLine());
            Console.Write(N + " => ");
            suite.Enqueue(N);
            for (int i = 0; i < 50; i++)
            {
                suite.Enqueue(suite.Peek() + 1);
                suite.Enqueue(2 * suite.Peek() + 1);
                suite.Enqueue(suite.Peek() + 2);
                if(i == 49)
                    Console.Write(suite.Dequeue() + "\n");
                else
                    Console.Write(suite.Dequeue() + ", ");
            }
        }
    }

    /// <summary>
    /// We are given N and M and the following operations:
    ///     N = N+1
    ///     N = N+2
    ///     N = N*2
    /// Write a program, which finds the shortest subsequence from the operations, which starts with N and ends with M.
    /// Use queue.
    /// Example: N = 5, M = 16
    /// Subsequence: 5 => 7 => 8 => 16
    /// </summary>
    public static class Exo10
    {
        static int N = 0;
        static int M = 0;
        public static void Execute()
        {
            Queue<int> suite = new Queue<int>();
            Console.Write("Write N : ");
            N = int.Parse(Console.ReadLine());
            Console.Write("Write M : ");
            M = int.Parse(Console.ReadLine());

            suite.Enqueue(N);

            //FindSubsequence(suite);

            Console.Write(N + " => ");
            for (int i = 0; i < suite.Count; i++)
            {
                 Console.Write(suite.Dequeue() + " => ");
            }
            Console.WriteLine(M);

        }

        //public static void FindSubsequence(Queue<int> suite)
        //{
        //    int number = suite.Dequeue();

        //    int multipleTwo = number * 2;
        //    int plusTwo = number + 2;
        //    int plusOne = number + 1;

        //    if (multipleTwo <= M)
        //    {
        //        suite.Enqueue(multipleTwo);
        //        FindSubsequence(suite);
        //    }
        //    if (plusTwo <= M)
        //    {
        //        suite.Enqueue(plusTwo);
        //        FindSubsequence(suite);
        //    }
        //    if (plusOne <= M)
        //    {
        //        suite.Enqueue(plusOne);
        //        FindSubsequence(suite);
        //    }
        //}
    } //TODO

    /// <summary>
    /// Implement the data structure dynamic doubly linked list (DoublyLinkedList<T>) – list, the elements of which have pointers both to the next and the previous elements. 
    /// Implement the operations for adding, removing and searching for an element, as well as inserting an element at a given index, retrieving an element by a given index and a method, which returns an array with the elements of the list.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Create a DynamicStack<T> class to implement dynamically a stack (like a linked list, where each element knows its previous element and the stack knows its last element). 
    /// Add methods for all commonly used operations like Push(), Pop(), Peek(), Clear() and Count.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Implement the data structure "Deque". 
    /// This is a specific list-like structure, similar to stack and queue, allowing to add elements at the beginning and at the end of the structure. 
    /// Implement the operations for adding and removing elements, as well as clearing the deque. 
    /// If an operation is invalid, throw an appropriate exception.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Implement the structure "Circular Queue" with array, which doubles its capacity when its capacity is full. 
    /// Implement the necessary methods for adding, removing the element in succession and retrieving without removing the element in succession. 
    /// If an operation is invalid, throw an appropriate exception.
    /// </summary>
    public static class Exo14
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Implement numbers sorting in a dynamic linked list without using an additional array or other data structure.
    /// </summary>
    public static class Exo15
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Using queue, implement a complete traversal of all directories on your hard disk and print them on the console.
    /// Implement the algorithm Breadth-First-Search (BFS) – you may find some articles in the internet.
    /// </summary>
    public static class Exo16
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Using queue, implement a complete traversal of all directories on your hard disk and print them on the console. 
    /// Implement the algorithm Depth-First-Search (DFS) – you may find some articles in the internet.
    /// </summary>
    public static class Exo17
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// We are given a labyrinth of size N x N. 
    /// Some of the cells of the labyrinth are empty (0), and others are filled (x). 
    /// We can move from an empty cell to another empty cell, if the cells are separated by a single wall.
    /// We are given a start position (*). 
    /// Calculate and fill the labyrinth as follows: in each empty cell put the minimal distance from the start position to this cell. 
    /// If some cell cannot be reached, fill it with "u".
    /// </summary>
    public static class Exo18
    {
        public static void Execute()
        {

        }
    }
}
