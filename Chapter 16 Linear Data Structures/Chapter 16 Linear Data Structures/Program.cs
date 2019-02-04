using System;
using System.IO;
using System.Collections;
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
            //Exo10.Execute();
            //Exo16.Execute();
            Exo17.Execute();
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
    /// Implement the operations for adding(OK), removing(OK) and searching for an element(OK), as well as inserting an element at a given index(OK), retrieving an element by a given index(OK) and a method, which returns an array with the elements of the list(OK).
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {

        }
        //TODO : Better Inserts/Adds/Remove functions => errors when back or front operation call
        public class DoublyLinkedList<T> : ICollection<T>, IEnumerable<T>, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, IEnumerable//, ICollection, IList
        {
            #region Classes
            // --- Node ---
            private class DoublyLinkedNode
            {
                #region Fields
                private T m_value = default(T);
                private DoublyLinkedNode m_previousNode = null;
                private DoublyLinkedNode m_nextNode = null;
                #endregion

                #region Constructor
                public DoublyLinkedNode(T value = default(T), DoublyLinkedNode previousNode = null, DoublyLinkedNode nextNode = null)
                {
                    this.m_value = value;
                    this.m_previousNode = previousNode;
                    this.m_nextNode = nextNode;
                }
                #endregion

                #region Properties
                public T Value { get { return this.m_value; } set { this.m_value = value; } }
                public DoublyLinkedNode PreviousNode { get { return this.m_previousNode; } set { this.m_previousNode = value; } }
                public DoublyLinkedNode NextNode { get { return this.m_nextNode; } set { this.m_nextNode = value; } }
                #endregion
            }

            // --- Enumerator ---
            public class Enumerator : IEnumerator, IEnumerator<T>
            {
                #region Fields
                private int version = 0;
                private int index = 0;
                private T current = default(T);
                private DoublyLinkedNode currentNode = null;
                private DoublyLinkedList<T> list = null;
                #endregion

                #region Constructors
                public Enumerator(DoublyLinkedList<T> list)
                {
                    this.version = list.version;
                    this.index = -1;
                    this.current = default(T);
                    this.currentNode = list.head;
                    this.list = list;
                }
                #endregion

                #region Properties
                public T Current { get { return this.current; } }

                object IEnumerator.Current => throw new NotImplementedException();
                #endregion

                #region Methods
                public void Dispose()
                {
                    this.index = this.list.count + 1;
                }

                public bool MoveNext()
                {
                    if(this.version != this.list.version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }
                    if(this.currentNode == null)
                    {
                        this.index = this.list.count + 1;
                        return false;
                    }
                    this.index++;
                    this.current = this.currentNode.Value;
                    this.currentNode = this.currentNode.NextNode;
                    return true;
                }

                public void Reset()
                {
                    if (this.version != this.list.version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }
                    this.index = -1;
                    this.current = default(T);
                    this.currentNode = null;
                }
                #endregion
            }

            #endregion

            #region Fields
            private bool isReadOnly = false;

            private int count = 0;
            private int version = 0;

            private DoublyLinkedNode head = null;
            private DoublyLinkedNode tail = null;
            #endregion

            #region Constructors
            public DoublyLinkedList()
            {
                this.count = 0;
                this.version = 0;
                this.head = null;
                this.tail = null;
            }
            #endregion

            #region Properties

            public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int Count { get { return this.count; } }

            public bool IsReadOnly { get { return this.isReadOnly; } }

            #endregion

            /// <summary>
            /// Add an item at the end of the linked list.
            /// </summary>
            /// <param name="item">The element to add.</param>
            public void Add(T item)
            {
                if(head == null)
                {
                    this.head = new DoublyLinkedNode(item,null,null);
                    this.tail = this.head;
                }
                else
                {
                    DoublyLinkedNode previousNode = this.tail;
                    this.tail = new DoublyLinkedNode(item, previousNode, null);
                    previousNode.NextNode = this.tail;
                }
                this.count++;
                this.version++;
            }

            public void AddLast(T item)
            {
                if(this.head == null)
                {
                    this.head = new DoublyLinkedNode(item, null, null);
                    this.tail = this.head;
                }
                else
                {
                    DoublyLinkedNode node = new DoublyLinkedNode(item, this.tail, null);
                    this.tail.NextNode = node;
                    this.tail = node;
                }
                this.count++;
                this.version++;
            }

            public void AddBefore(T item)
            {
                if (this.head == null)
                {
                    this.head = new DoublyLinkedNode(item, null, null);
                    this.tail = this.head;
                }
                else
                {
                    DoublyLinkedNode node = new DoublyLinkedNode(item, null, this.head);
                    this.head.PreviousNode = node;
                    this.head = node;
                }
                this.count++;
                this.version++;
            }

            private void AddBeforeNode(T item, DoublyLinkedNode node)
            {
                DoublyLinkedNode newNode = new DoublyLinkedNode(item, node.PreviousNode, node);
                node.PreviousNode.NextNode = newNode;
                node.PreviousNode = newNode;
                this.count++;
                this.version++;
            }

            /// <summary>
            /// Clear all the elements in the list.
            /// </summary>
            public void Clear()
            {
                this.count = 0;
                this.version++;
                this.head = null;
                this.tail = null;
            }

            /// <summary>
            /// Check if the list contains this <paramref name="item"/>.
            /// </summary>
            /// <param name="item">The elements that is researched.</param>
            /// <returns>Is the elements in the list ?</returns>
            public bool Contains(T item)
            {
                DoublyLinkedNode current = this.head;
                while(current != null)
                {
                    if (object.Equals(item, current.Value))
                        return true;
                    current = current.NextNode;
                }
                return false;
            }

            /// <summary>
            /// Copy a part of this list in another array starting from <paramref name="arrayIndex"/>.
            /// </summary>
            /// <param name="array">The array where the values will be copied.</param>
            /// <param name="arrayIndex">The starting index of th ecopy.</param>
            public void CopyTo(T[] array, int arrayIndex)
            {
                if(arrayIndex < 0 && arrayIndex >= this.count)
                {
                    throw new IndexOutOfRangeException("Index out of range (0," + this.count + ") : " + arrayIndex);
                }

                DoublyLinkedNode node = this.head;
                for(int i = 0; i < arrayIndex;i++)
                {
                    node = node.NextNode;
                }

                for (int i = 0; i < this.count - arrayIndex; i++)
                {
                    array[i] = node.Value;
                    node = node.NextNode;
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new Enumerator(this);
            }

            /// <summary>
            /// Check the index of an item in the list.
            /// </summary>
            /// <param name="item">The item we are searching for.</param>
            /// <returns>The index of the item in the list. Return -1 if not found.</returns>
            public int IndexOf(T item)
            {
                int index = -1;
                DoublyLinkedNode node = this.head;
                for(;index < this.count;)
                {
                    index++;
                    if (object.Equals(item, node.Value))
                    {
                        return index;
                    }
                    node = node.NextNode;
                }
                return -1;
            }

            #region Insertion
            /// <summary>
            /// Insert an <paramref name="item"/> at the <paramref name="index"/>.
            /// </summary>
            /// <param name="index">The index where we want to insert the item.</param>
            /// <param name="item">The item to insert in the list.</param>
            public void Insert(int index, T item)
            {
                if(index < 0 && index >= this.count)
                {
                    throw new IndexOutOfRangeException("Index out of range (0," + this.count + ") : " + index);
                }

                int currentIndex = 0;
                DoublyLinkedNode node = this.head;
                for (; currentIndex < this.count; currentIndex++) 
                {
                    if(currentIndex == index)
                    {
                        this.AddBeforeNode(item, node);
                        return;
                    }
                    node = node.NextNode;
                }
            }
            #endregion

            /// <summary>
            /// Remove an <paramref name="item"/> in the list.
            /// </summary>
            /// <param name="item">The item to remove.</param>
            /// <returns>Has the item been removed.</returns>
            public bool Remove(T item)
            {
                DoublyLinkedNode node = this.head;
                while(node != null)
                {
                    if(object.Equals(item,node.Value))
                    {
                        this.RemoveNode(node);
                        return true;
                    }
                    node = node.NextNode;
                }
                return false;
            }

            /// <summary>
            /// Remove an item at an <paramref name="index"/> in the list.
            /// </summary>
            /// <param name="index">The index of the item to remove.</param>
            public void RemoveAt(int index)
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException("Index out of range (0," + this.count + ") : " + index);
                DoublyLinkedNode node = this.head;    
                for(int i = 0; i < this.count; i++)
                {
                    if (i == index)
                        break;
                    node = node.NextNode;
                }

                this.RemoveNode(node);
            }

            /// <summary>
            /// Remove a node and make connections correctly.
            /// </summary>
            /// <param name="node">The node to remove.</param>
            private void RemoveNode(DoublyLinkedNode node)
            {
                this.count--;
                this.version++;
                if (this.count == 0)
                {
                    this.head = null;
                    this.tail = null;
                }
                else if (node.PreviousNode == null)
                {
                    this.head = node.NextNode;
                    this.head.PreviousNode = null;
                }
                else if (node.NextNode == null)
                {
                    this.tail = node.PreviousNode;
                    this.tail.NextNode = null;
                }
                else
                {
                    node.PreviousNode.NextNode = node.NextNode;
                    node.NextNode.PreviousNode = node.PreviousNode;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new Enumerator(this);
            }

            /// <summary>
            /// Return an array of the current list.
            /// </summary>
            /// <returns>Return an array of the current list values.</returns>
            public T[] ToArray()
            {
                T[] array = new T[this.count];
                DoublyLinkedNode node = this.head;
                for(int i = 0; i < this.count;i++)
                {
                    array[i] = node.Value;
                    node = node.NextNode;
                }
                return array;
            }
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

        public interface IStack<T>
        {
            #region Properties
            /// <summary>
            /// Is the stack empty ?
            /// </summary>
            bool IsEmpty { get; }
            /// <summary>
            /// Number of elements in the stack.
            /// </summary>
            int Count { get; }
            #endregion

            #region Methods
            void Push(T item);
            T Pop();
            T Peek();
            void Clear();
            #endregion
        }

        public class DynamicStack<T> : IStack<T> ,IEnumerable<T>, ICollection, IReadOnlyCollection<T>
        {
            #region Classes
            // --- Node ---
            private class StackNode
            {
                #region Fields
                private T value;
                private StackNode previousNode;
                #endregion

                #region Constructors
                public StackNode(T value = default(T), StackNode previousNode = null)
                {
                    this.value = value;
                    this.previousNode = previousNode;
                }
                #endregion

                #region Properties
                public T Value { get { return this.value; } set { this.value = value; } }
                public StackNode PreviousNode { get { return this.previousNode; } set { this.previousNode = value; } }
                #endregion
            }

            // --- Enumerator ---
            public class Enumerator : IEnumerator<T>, IEnumerator
            {
                #region Fields
                private int version;
                private T current;
                private StackNode currentNode;
                private DynamicStack<T> stack;
                #endregion

                #region Constructors
                public Enumerator(DynamicStack<T> stack)
                {
                    this.version = stack.version;
                    this.current = default(T);
                    this.currentNode = stack.head;
                    this.stack = stack;
                }
                #endregion

                #region Properties
                public T Current
                {
                    get
                    {
                        if (this.version != stack.version)
                            throw new InvalidOperationException("The enumerator version does not match the stack version !");
                        if (this.currentNode == stack.head)
                            throw new InvalidOperationException("Enumerator not yet moved, invoke MoveNext first");
                        return this.current;
                    }
                }

                object IEnumerator.Current { get { return this.Current; } }
                #endregion

                #region Methods
                public void Dispose()
                {
                    this.current = default(T);
                    this.currentNode = null;
                }

                public bool MoveNext()
                {
                    if (this.currentNode == null)
                    {
                        this.current = default(T);
                        return false;
                    }

                    this.current = this.currentNode.Value;
                    this.currentNode = this.currentNode.PreviousNode;

                    return true;
                }

                public void Reset()
                {
                    this.current = default(T);
                    this.currentNode = this.stack.head;
                }
                #endregion
            }

            // --- Exceptions ---
            public class StackEmptyException : ApplicationException
            {
                public StackEmptyException() : base()
                {
                    
                }
                public StackEmptyException(string message) : base(message)
                {

                }
            }

            public class StackUnderflowException : ApplicationException
            {
                public StackUnderflowException() : base()
                {

                }
                public StackUnderflowException(string message) : base(message)
                {

                }
            }
            #endregion

            #region Fields
            private bool isEmpty = true;

            private bool isSynchronized = false;
            private Object syncRoot = null;

            private int count = 0;
            private int version = 0;
            private int defaultCount = 8;

            private StackNode head = null;
            #endregion

            #region Constructors
            public DynamicStack()
            {
                this.isEmpty = true;
                this.count = 0;
                this.version = 0;
                this.head = null;
            }
            public DynamicStack(int capacity)
            {
                this.isEmpty = true;
                this.count = 0;
                this.version = 0;
                this.head = null;
            }
            #endregion

            #region Properties
            public bool IsEmpty { get { return this.isEmpty; } }

            public int Count { get { return this.count; } }

            public bool IsSynchronized { get { return this.isSynchronized; } }

            public object SyncRoot { get { return this.syncRoot; } }
            #endregion

            #region Methods

            public void Clear()
            {
                this.isEmpty = true;
                this.count = 0;
                this.head = null;
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            } //TODO

            public IEnumerator<T> GetEnumerator()
            {
                return new DynamicStack<T>.Enumerator(this);
            }

            public T Peek()
            {
                if (this.head == null)
                    throw new StackEmptyException("The stack is empty !");
                return this.head.Value;
            }

            public T Pop()
            {
                if (this.head == null)
                    throw new StackUnderflowException("The stack is already empty !");

                StackNode node = this.head;
                this.head = this.head.PreviousNode;

                this.count--;
                this.version++;

                return node.Value;
            }

            public void Push(T item)
            {
                if (this.head == null)
                {
                    this.head = new StackNode(item, null);
                }
                else
                {
                    StackNode node = new StackNode(item, this.head);
                    this.head = node;
                }

                this.count++;
                this.version++;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new DynamicStack<T>.Enumerator(this);
            }
            #endregion
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
            Queue<int> d = new Queue<int>();
        }

        public class EmptyCollectionException : SystemException
        {
            public EmptyCollectionException() : base() { }
            public EmptyCollectionException(string message) : base(message) { }
        }

        public interface IDeque<T>
        {
            #region Fields
            bool IsEmpty { get; }
            int Count { get; }
            #endregion

            #region Methods
            void PushBack(T item);
            void PushFront(T item);
            T PopBack();
            T PopFront();
            T PeekBack();
            T PeekFront();
            void Clear();
            #endregion
        }

        public class Deque<T> : IDeque<T>, ICollection<T>, IEnumerable<T>
        {
            #region Classes
            private class DequeNode
            {
                #region Fields
                private T item = default(T);
                private DequeNode previousNode = null;
                private DequeNode nextNode = null;
                #endregion

                #region Constructors
                public DequeNode() : this(default(T))
                {

                }
                public DequeNode(T item, DequeNode previousNode = null, DequeNode nextNode = null)
                {
                    this.item = item;
                    this.previousNode = previousNode;
                    this.nextNode = nextNode;
                }
                #endregion

                #region Properties
                public T Item { get { return this.item; } set { this.item = value; } }
                public DequeNode PreviousNode { get { return this.previousNode; } set { this.previousNode = value; } }
                public DequeNode NextNode { get { return this.nextNode; } set { this.nextNode = value; } }
                #endregion
            }

            public class Enumerator : IEnumerator<T>, IEnumerator
            {
                #region Fields
                private int version = 0;
                private T current = default(T);

                private DequeNode currentNode = null;
                private Deque<T> deque = null;
                #endregion

                #region Constructors
                public Enumerator(Deque<T> deque)
                {
                    this.version = deque.version;
                    this.current = default(T);
                    this.currentNode = deque.backNode;
                    this.deque = deque;
                }
                #endregion

                #region Properties
                public T Current
                {
                    get
                    {
                        if (this.version != deque.version)
                        {
                            throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                        }
                        return this.current;
                    }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        if (this.version != deque.version)
                        {
                            throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                        }
                        return this.current;
                    }
                }
                #endregion

                #region Methods
                public void Dispose()
                {
                    this.current = default(T);
                    this.currentNode = null;
                }

                public bool MoveNext()
                {
                    if(this.version != deque.version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }
                    if (this.currentNode == null)
                    {
                        this.current = default(T);
                        return false;
                    }

                    this.current = this.currentNode.Item;
                    this.currentNode = this.currentNode.NextNode;
                    return true;
                }

                public void Reset()
                {
                    if (this.version != deque.version)
                    {
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    }
                    this.current = default(T);
                    this.currentNode = deque.backNode;
                }
                #endregion
            }
            #endregion

            #region Fields
            private bool isReadOnly = false;
            private bool isEmpty = true;

            private int count = 0;
            private int version = 0;

            private DequeNode backNode = null;
            private DequeNode frontNode = null;
            #endregion

            #region Constructors
            public Deque()
            {
                this.count = 0;
                this.version = 0;
                this.isEmpty = true;
                this.backNode = null;
                this.frontNode = null;
            }
            #endregion

            #region Properties
            public bool IsEmpty { get { return this.isEmpty; } }

            public int Count { get { return this.count; } }

            public bool IsReadOnly { get { return this.isReadOnly; } }
            #endregion

            #region Methods
            public void Add(T item)
            {
                this.PushFront(item);
            }

            public void Clear()
            {
                this.count = 0;
                this.version++;
                this.isEmpty = true;
                this.backNode = null;
                this.frontNode = null;
            }

            public bool Contains(T item)
            {
                if (this.isEmpty)
                    return false;

                DequeNode currentNode = this.backNode;
                while (currentNode != null)
                {
                    if (object.Equals(currentNode.Item, item))
                    {
                        return true;
                    }
                    currentNode = currentNode.NextNode;
                }

                return false;
            }

            //TODO
            public void CopyTo(T[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new Enumerator(this);
            }

            #region IDeque
            public T PeekBack()
            {
                if (this.isEmpty)
                    throw new EmptyCollectionException("Deque is empty !");

                return this.backNode.Item;
            }

            public T PeekFront()
            {
                if (this.isEmpty)
                    throw new EmptyCollectionException("Deque is empty !");

                return this.frontNode.Item;
            }

            public T PopBack()
            {
                if (this.isEmpty)
                    throw new EmptyCollectionException("Deque is empty !");

                T item = this.backNode.Item;
                this.RemoveNode(this.backNode);
                return item;
            }

            public T PopFront()
            {
                if (this.isEmpty)
                    throw new EmptyCollectionException("Deque is empty !");

                T item = this.frontNode.Item;
                this.RemoveNode(this.frontNode);
                return item;
            }

            public void PushBack(T item)
            {
                DequeNode node = new DequeNode(item);
                this.PushBackNode(node);
            }

            public void PushFront(T item)
            {
                DequeNode node = new DequeNode(item);
                this.PushFrontNode(node);
            }
            #endregion

            // --- Add Functions ---
            private void PushBackNode(DequeNode node)
            {
                if (this.backNode == null)
                {
                    this.frontNode = node;
                    this.backNode = node;

                    this.isEmpty = false;
                    this.version++;
                    this.count++;
                }
                else
                {
                    this.backNode.PreviousNode = node;
                    node.NextNode = this.backNode;
                    this.backNode = node;

                    this.version++;
                    this.count++;
                }
            }
            private void PushFrontNode(DequeNode node)
            {
                if(this.frontNode == null)
                {
                    this.frontNode = node;
                    this.backNode = node;

                    this.isEmpty = false;
                    this.version++;
                    this.count++;
                }
                else
                {
                    this.frontNode.NextNode = node;
                    node.PreviousNode = this.frontNode;
                    this.frontNode = node;

                    this.version++;
                    this.count++;
                }
            }
            private void AddNodeBefore(DequeNode node, DequeNode futurNextNode)
            {
                if(futurNextNode == this.backNode)
                {
                    this.PushBackNode(node);
                }
                else
                {
                    DequeNode previousNode = futurNextNode.PreviousNode;
                    node.PreviousNode = previousNode;
                    node.NextNode = futurNextNode;
                    futurNextNode.PreviousNode = node;
                    previousNode.NextNode = node;

                    this.version++;
                    this.count++;
                }
            }
            private void AddNodeAfter(DequeNode node, DequeNode futurPreviousNode)
            {
                if (futurPreviousNode == this.frontNode)
                {
                    this.PushFrontNode(node);
                }
                else
                {
                    DequeNode nextNode = futurPreviousNode.NextNode;
                    node.PreviousNode = futurPreviousNode;
                    node.NextNode = nextNode;
                    futurPreviousNode.NextNode = node;
                    nextNode.PreviousNode = node;

                    this.version++;
                    this.count++;
                }
            }

            // --- Remove Functions ---
            private void RemoveNode(DequeNode node)
            {
                if(this.count == 1)
                {
                    this.isEmpty = true;
                    this.backNode = null;
                    this.frontNode = null;
                }
                else
                {
                    if(node == this.backNode)
                    {
                        //Remove Back Node
                        DequeNode nextBackNode = this.backNode.NextNode;
                        this.backNode = nextBackNode;
                    }
                    else if(node == this.frontNode)
                    {
                        //Remove Front Node
                        DequeNode nextFrontNode = this.frontNode.PreviousNode;
                        this.frontNode = nextFrontNode;
                    }
                    else
                    {
                        //Remove Node
                        DequeNode nextNode = node.NextNode;
                        DequeNode previousNode = node.PreviousNode;
                        previousNode.NextNode = nextNode;
                        nextNode.PreviousNode = previousNode;
                    }
                }

                this.count--;
                this.version++;
            }
            public bool Remove(T item)
            {
                if (this.isEmpty)
                    return false;

                DequeNode currentNode = this.backNode;
                while(currentNode != null)
                {
                    if(object.Equals(currentNode.Item, item))
                    {
                        this.RemoveNode(currentNode);
                        return true;
                    }
                    currentNode = currentNode.NextNode;
                }

                return false;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new Enumerator(this);
            }
            #endregion
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

        public class CircularQueue<T>
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
            string path = "C:/";
            BFS(path);
        }

        public static void BFS(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            DirectoryInfo infoDir = new DirectoryInfo(path);
            ConsolePading(infoDir.FullName);
            Console.WriteLine(infoDir.Name);

            while (queue.Count != 0)
            {
                string currentDirectory = "";
                try
                {
                    currentDirectory = queue.Dequeue();
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                try
                {
                    string[] directory = Directory.GetDirectories(currentDirectory);
                    for (int i = 0; i < directory.Length; i++)
                    {
                        DirectoryInfo infoDirec = new DirectoryInfo(directory[i]);
                        ConsolePading(infoDirec.FullName);
                        Console.WriteLine(infoDirec.Name);
                        queue.Enqueue(directory[i]);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                //try
                //{
                //    string[] files = Directory.GetFiles(currentDirectory);
                //    for (int i = 0; i < files.Length; i++)
                //    {
                //        FileInfo info = new FileInfo(files[i]);
                //        ConsolePading(info.FullName);
                //        Console.WriteLine(info.Name);
                //    }
                //}
                //catch (IOException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                //catch (UnauthorizedAccessException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                //catch (ArgumentException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
            }
        }

        public static void ConsolePading(string padding)
        {
            int depth = 0;

            for(int i = 0; i < padding.Length;i++)
            {
                if (padding[i] == '\\')
                    depth++;
            }

            for(int i = 0; i < depth; i++)
            {
                Console.Write("    ");
            }
        }
    }

    /// <summary>
    /// Using queue (Stack), implement a complete traversal of all directories on your hard disk and print them on the console. 
    /// Implement the algorithm Depth-First-Search (DFS) – you may find some articles in the internet.
    /// </summary>
    public static class Exo17
    {
        public static void Execute()
        {
            string path = "D:/";
            DFS(path);
        }

        public static void DFS(string path)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push(path);

            string currentDirectory;
            while (stack.Count != 0)
            {
                currentDirectory = stack.Pop();
                DirectoryInfo info = new DirectoryInfo(currentDirectory);
                ConsolePading(info.FullName);
                Console.WriteLine(info.Name);
                try
                {
                    string[] directories = Directory.GetDirectories(currentDirectory);
                    for (int i = 0; i < directories.Length; i++)
                    {
                        stack.Push(directories[i]);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void ConsolePading(string padding)
        {
            int depth = 0;

            for (int i = 0; i < padding.Length; i++)
            {
                if (padding[i] == '\\')
                    depth++;
            }

            for (int i = 0; i < depth; i++)
            {
                Console.Write("    ");
            }
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
