using System;
using System.Collections.Generic;
using System.IO;

namespace Chapter_10_Recursion
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
        }
    }

    public class Vector2
    {
        public bool visited;
        public bool passable;
        public int x;
        public int y;

        public Vector2()
        {
            this.x = 0;
            this.y = 0;
            visited = false;
            this.passable = false;
        }

        public Vector2(int x, int y, bool passable)
        {
            this.x = x;
            this.y = y;
            visited = false;
            this.passable = passable;
        }
    }

    /// <summary>
    /// Write a program to simulate n nested loops from 1 to n.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            Console.Write("Write a number n = ");
            int n = int.Parse(Console.ReadLine());
            NestedLoops(n - 1, n);
        }

        static void NestedLoops(int k, int n)
        {
            if (k < 0)
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Depth level " + k);
                NestedLoops(k - 1, n);
            }
        }
    }

    /// <summary>
    /// Write a program to generate all variations with duplicates of n elements class k.
    /// </summary>
    public static class Exo2
    {
        private static int numberOfLoop;
        private static int numberOfIteration;
        private static int[] loops;

        public static void Execute()
        {
            Console.Write("Write the number of loop = ");
            numberOfLoop = int.Parse(Console.ReadLine());
            Console.Write("Write the number of iteration = ");
            numberOfIteration = int.Parse(Console.ReadLine());
            loops = new int[numberOfLoop];
            VariationWithDuplicate(0);
        }

        static void VariationWithDuplicate(int currentLoop)
        {
            if (currentLoop == numberOfLoop)
            {
                PrintLoop();
                return;
            }
            for (int i = 1; i < numberOfIteration; i++)
            {
                loops[currentLoop] = i;
                VariationWithDuplicate(currentLoop + 1);
            }
        }

        static void PrintLoop()
        {
            Console.Write("(");
            foreach (int number in loops)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine(")");
        }
    }

    /// <summary>
    /// Write a program to generate and print all combinations with duplicates of k elements from a set with n elements.
    /// </summary>
    public static class Exo3
    {
        private static int numberOfLoop;
        private static int numberOfIteration;
        private static int[] loops;

        public static void Execute()
        {
            Console.Write("Write the number of loop = ");
            numberOfLoop = int.Parse(Console.ReadLine());
            Console.Write("Write the number of iteration = ");
            numberOfIteration = int.Parse(Console.ReadLine());
            loops = new int[numberOfLoop];
            VariationWithIncreasingDuplicate(0);
        }

        static void VariationWithIncreasingDuplicate(int currentLoop)
        {
            if (currentLoop == numberOfLoop)
            {
                PrintLoop();
                return;
            }
            for (int i = 1; i < numberOfIteration; i++)
            {
                if (i == 1 && currentLoop > 0)
                    i = loops[currentLoop - 1];
                loops[currentLoop] = i;
                VariationWithIncreasingDuplicate(currentLoop + 1);
            }
        }

        static void PrintLoop()
        {
            Console.Write("(");
            foreach (int number in loops)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine(")");
        }
    }

    /// <summary>
    /// You are given a set of strings. 
    /// Write a recursive program, which generates all subsets, consisting exactly k strings chosen among the elements of this set.
    /// </summary>
    public static class Exo4
    {
        private static int numberOfIteration;
        static string[] subset;
        static int nbrOfLoop;

        public static void Execute()
        {
            string[] words = new string[5];
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = "word " + i;
            }
            foreach (string word in words)
            {
                Console.Write(word + "|");
            }
            Console.WriteLine();
            Console.Write("Write an int k = ");
            int k = int.Parse(Console.ReadLine());
            subset = new string[k];
            nbrOfLoop = k;
            FindSubsets(words, 0, 0);
        }

        static void FindSubsets(string[] words, int k, int startingIndex)
        {
            if (k == nbrOfLoop)
            {
                PrintSubset();
                return;
            }
            for (int i = startingIndex; i < words.Length; i++)
            {
                subset[k] = words[i];
                FindSubsets(words, k + 1, i + 1);
            }
        }

        static void PrintSubset()
        {
            Console.Write("(");
            for (int i = 0; i < subset.Length; i++)
            {
                Console.Write(subset[i] + " ");
            }
            Console.Write(")");
        }
    }

    /// <summary>
    /// Write a recursive program, which prints all subsets of a given set of N words.
    /// </summary>
    public static class Exo5
    {
        static string[] subset;
        static int nbrOfLoop;

        public static void Execute()
        {
            Console.Write("Write an int n = ");
            int n = int.Parse(Console.ReadLine());

            string[] words = new string[n];
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = "word " + i;
            }
            foreach (string word in words)
            {
                Console.Write(word + "|");
            }
            Console.WriteLine();

            FindAllSubsets(words);
        }

        static void FindAllSubsets(string[] words)
        {
            for (int i = 0; i <= words.Length; i++)
            {
                subset = new string[i];
                nbrOfLoop = i;
                Console.WriteLine("With " + i + "subset :");
                FindSubsets(words, 0, 0);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void FindSubsets(string[] words, int k, int startingIndex)
        {
            if (k == nbrOfLoop)
            {
                PrintSubset();
                return;
            }
            for (int i = startingIndex; i < words.Length; i++)
            {
                subset[k] = words[i];
                FindSubsets(words, k + 1, i + 1);
            }
        }

        static void PrintSubset()
        {
            Console.Write("(");
            for (int i = 0; i < subset.Length; i++)
            {
                Console.Write(subset[i] + " ");
            }
            Console.Write(")");
        }
    }

    /// <summary>
    /// Implement the merge-sort algorithm recursively. 
    /// In it the initial array is divided into two equal in size parts, which are sorted (recursively via merge-sort) and after that the two sorted parts are merged in order to get the whole sorted array.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Random random = new Random();

            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 10);
            }
            foreach (int number in numbers)
            {
                Console.Write(number + "|");
            }
            Console.WriteLine();

            MergeSortRecursive(numbers);

            foreach (int number in numbers)
            {
                Console.Write(number + "|");
            }
            Console.WriteLine();
        }

        static void MergeSortRecursive(int[] numbers)
        {
            MergeSort(numbers, 0, numbers.Length - 1);
        }

        static void MergeSort(int[] numbers, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(numbers, low, mid);
                MergeSort(numbers, mid + 1, high);
                Merge(numbers, low, mid, high);
            }
        }

        static void Merge(int[] numbers, int low, int mid, int high)
        {
            int left = low;
            int right = mid + 1;
            int[] temp = new int[high - low + 1];
            int tempIndex = 0;

            while (left <= mid && right <= high)
            {
                if (numbers[left] < numbers[right])
                {
                    temp[tempIndex] = numbers[left];
                    left++;
                }
                else
                {
                    temp[tempIndex] = numbers[right];
                    right++;
                }
                tempIndex++;
            }
            while (left <= mid)
            {
                temp[tempIndex] = numbers[left];
                left++;
                tempIndex++;
            }
            while (right <= high)
            {
                temp[tempIndex] = numbers[right];
                right++;
                tempIndex++;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                numbers[low + i] = temp[i];
            }
        }

        static void Permutations(int[] input)
        {
            Permutation(input, 0);
        }

        static void Permutation(int[] input, int k)
        {
            if (k == input.Length - 1)
            {
                PrintPermutation(input);
                return;
            }
            for (int i = k; i < input.Length; i++)
            {
                int[] tempInput = new int[input.Length];
                input.CopyTo(tempInput, 0);
                tempInput[i] = input[k];
                tempInput[k] = input[i];
                Permutation(tempInput, k + 1);
            }
        }

        static void PrintPermutation(int[] input)
        {
            Console.Write("(");
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + " ");
            }
            Console.WriteLine(")");
        }
    }

    /// <summary>
    /// Write a recursive program, which generates and prints all permutations of the numbers 1, 2, …, n, for a given integer n.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            Console.Write("Write an int n = ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            for (int i = 1; i <= numbers.Length; i++)
            {
                numbers[i - 1] = i;
            }
            foreach (int number in numbers)
            {
                Console.Write(number + "|");
            }
            Console.WriteLine();

            Permutations(numbers);
        }

        static void Permutations(int[] input)
        {
            Permutation(input, 0);
        }

        static void Permutation(int[] input, int k)
        {
            if (k == input.Length - 1)
            {
                PrintPermutation(input);
                return;
            }
            for (int i = k; i < input.Length; i++)
            {
                int[] tempInput = new int[input.Length];
                input.CopyTo(tempInput, 0);
                tempInput[i] = input[k];
                tempInput[k] = input[i];
                Permutation(tempInput, k + 1);
            }
        }

        static void PrintPermutation(int[] input)
        {
            Console.Write("(");
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + " ");
            }
            Console.WriteLine(")");
        }
    }

    /// <summary>
    /// You are given an array of integers and a number N. 
    /// Write a recursive program that finds all subsets of numbers in the array, which have a sum N. 
    /// For example, if we have the array {2, 3, 1, -1} and N=4, we can obtain N=4 as a sum in the following two ways: 4=2+3-1; 4=3+1.
    /// </summary>
    public static class Exo8
    {
        static int nbrOfLoop;
        static int[] subsetInt;
        static int sumToFind;
        static List<int[]> sums;

        public static void Execute()
        {
            Random random = new Random();

            Console.Write("Write a sum to find in the array : ");
            sumToFind = int.Parse(Console.ReadLine());

            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(-5, 10);
            }
            foreach (int number in numbers)
            {
                Console.Write(number + "|");
            }
            Console.WriteLine();
            double beginTickCount = System.Environment.TickCount;
            FindAllSubsetsWithSum(numbers);
            double endTickCount = System.Environment.TickCount;
            Console.WriteLine("The operation took : " + (endTickCount - beginTickCount) / 1000 + "sec");
            foreach (int[] number in sums)
            {
                Console.Write(sumToFind + " = ");
                for (int i = 0; i < number.Length; i++)
                {
                    if (i == number.Length - 1)
                        Console.Write(number[i]);
                    else
                        Console.Write(number[i] + "+");
                }
                Console.WriteLine();
            }
        }

        static void FindAllSubsetsWithSum(int[] numbers)
        {
            sums = new List<int[]>();
            for (int i = 1; i <= numbers.Length; i++)
            {
                subsetInt = new int[i];
                nbrOfLoop = i;
                FindSubsetsWithSum(numbers, 0, 0);
            }
            Console.WriteLine();
        }

        static void FindSubsetsWithSum(int[] numbers, int k, int startingIndex)
        {
            if (k == nbrOfLoop)
            {
                PrintSubsetWithSum();
                return;
            }
            for (int i = startingIndex; i < numbers.Length; i++)
            {
                subsetInt[k] = numbers[i];
                FindSubsetsWithSum(numbers, k + 1, i + 1);
            }
        }

        static void PrintSubsetWithSum()
        {
            int sumTemp = 0;
            for (int i = 0; i < subsetInt.Length; i++)
            {
                sumTemp += subsetInt[i];
            }
            if (sumTemp == sumToFind)
            {
                int[] temp = new int[subsetInt.Length];
                subsetInt.CopyTo(temp, 0);
                if (!sums.Exists(tab =>
                {
                    bool same = true;
                    for (int i = 0; i < tab.Length; i++)
                    {
                        if (tab[i] != subsetInt[i])
                        {
                            same = false;
                            break;
                        }
                    }
                    return same;
                }))
                {
                    sums.Add(temp);
                }
            }
        }
    }

    /// <summary>
    /// You are given an array of positive integers. 
    /// Write a program that checks whether there is one or more numbers in the array (subset), whose sum is equal to S. 
    /// Can you solve the task efficiently for large arrays?
    /// </summary>
    public static class Exo9
    {
        static int nbrOfLoop;
        static int[] subsetIntPos;
        static List<int[]> sums;
        static int currentSum;
        static int sumToFind;

        public static void Execute()
        {
            Random random = new Random();

            Console.Write("Write a sum to find in the array : ");
            sumToFind = int.Parse(Console.ReadLine());

            int[] numbers = new int[40];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 20);
            }
            foreach (int number in numbers)
            {
                Console.Write(number + "|");
            }
            Console.WriteLine();
            double beginTickCount = System.Environment.TickCount;
            FindAllPosSubsetsWithSum(numbers);
            double endTickCount = System.Environment.TickCount;
            Console.WriteLine("The operation took : " + (endTickCount - beginTickCount) / 1000 + "sec");
            foreach (int[] number in sums)
            {
                Console.Write(sumToFind + " = ");
                for (int i = 0; i < number.Length; i++)
                {
                    if (i == number.Length - 1)
                        Console.Write(number[i]);
                    else
                        Console.Write(number[i] + "+");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }


        static void FindAllPosSubsetsWithSum(int[] numbers)
        {
            currentSum = 0;
            sums = new List<int[]>();
            for (int i = 1; i <= numbers.Length; i++)
            {
                subsetIntPos = new int[i];
                nbrOfLoop = i;
                FindPosSubsetsWithSum(numbers, 0, 0);
            }
            Console.WriteLine();
        }

        static void FindPosSubsetsWithSum(int[] numbers, int k, int startingIndex)
        {
            if (k == nbrOfLoop)
            {
                currentSum = 0;
                PrintPosSubsetWithSum();
                return;
            }
            for (int i = startingIndex; i < numbers.Length; i++)
            {
                currentSum += numbers[i];
                subsetIntPos[k] = numbers[i];
                FindPosSubsetsWithSum(numbers, k + 1, i + 1);
            }
        }

        static void PrintPosSubsetWithSum()
        {
            bool sumCanBeFound = true;
            int sumTemp = 0;
            for (int i = 0; i < subsetIntPos.Length; i++)
            {
                sumTemp += subsetIntPos[i];
                if (sumTemp > sumToFind)
                {
                    sumCanBeFound = false;
                    break;
                }
            }
            if (sumCanBeFound)
            {
                if (sumTemp == sumToFind)
                {
                    int[] temp = new int[subsetIntPos.Length];
                    subsetIntPos.CopyTo(temp, 0);
                    if (!sums.Exists(tab =>
                    {
                        bool same = true;
                        for (int i = 0; i < tab.Length; i++)
                        {
                            if (tab[i] != subsetIntPos[i])
                            {
                                same = false;
                                break;
                            }
                        }
                        return same;
                    }))
                    {
                        sums.Add(temp);
                    }
                }
            }
        }
    }

    /// <summary>
    /// You are given a matrix with passable and impassable cells. 
    /// Write a recursive program that finds all paths between two cells in the matrix.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            // Passable cell : ' '
            // Impassable cell : 'x'
            // Start : "s"
            // End : "e"
            // Path : "p"
            
            const int lenght = 5, height = 10;
            char[,] matrix = new char[lenght, height]
            {
               { 'e',' ',' ',' ','x',' ',' ',' ','x',' ' },
               { ' ',' ','x',' ','x','x',' ',' ',' ',' ' },
               { ' ','x','x',' ',' ',' ',' ',' ','x',' ' },
               { ' ',' ',' ',' ',' ',' ',' ','x',' ',' ' },
               { ' ',' ',' ',' ',' ',' ',' ','x','s',' ' },
               //{ ' ',' ',' ','x',' ',' ',' ',' ',' ',' ' },
               //{ ' ',' ',' ',' ',' ',' ',' ',' ','x',' ' },
               //{ ' ',' ',' ',' ',' ','x',' ',' ','x',' ' },
               //{ ' ',' ',' ',' ',' ','x',' ',' ','x',' ' },
               //{ ' ',' ',' ',' ','x','x',' ',' ','x','s' }
            };
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            FindAllPathsInMatrix(matrix);
        }

        static void FindAllPathsInMatrix(char[,] matrix)
        {
            int[] startCoord = FindStart(matrix);
            string path = "";
            FindPathInMatrix(matrix, path, startCoord[0], startCoord[1]);
        }

        static int[] FindStart(char[,] matrix)
        {
            int[] coord = new int[2];
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (matrix[y, x] == 'e')
                    {
                        coord[0] = y;
                        coord[1] = x;
                        y = matrix.GetLength(1);
                        break;
                    }
                }
            }
            return coord;
        }

        static void FindPathInMatrix(char[,] matrix, string currentPath, int x, int y)
        {
            if (x < 0 || x >= matrix.GetLength(0) || y < 0 || y >= matrix.GetLength(1))
            {
                return;
            }
            if (matrix[x, y] == 's')
            {
                PrintPath(currentPath);
            }
            if (matrix[x, y] == 'x')
            {
                return;
            }
            if (matrix[x, y] == ' ' || matrix[x, y] == 'e')
            {
                matrix[x, y] = 'v';
                FindPathInMatrix(matrix, currentPath + "R", x, y + 1);
                FindPathInMatrix(matrix, currentPath + "U", x - 1, y);
                FindPathInMatrix(matrix, currentPath + "L", x, y - 1);
                FindPathInMatrix(matrix, currentPath + "D", x + 1, y);
                matrix[x, y] = ' ';
            }
        }

        static void PrintPath(string path)
        {
            Console.WriteLine("A path was found : " + path);
        }
    }

    /// <summary>
    /// Implement the algorithm BFS (breadth-first search) for finding the shortest path in a labyrinth.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {            // Passable cell : ' '
                     // Impassable cell : 'x'
                     // Start : "s"
                     // End : "e"
                     // Path : "p"

            const int lenght = 5, height = 10;
            char[,] matrix = new char[lenght, height]
            {
               { 'e',' ',' ',' ','x',' ',' ',' ','x',' ' },
               { ' ',' ','x',' ','x','x',' ',' ',' ',' ' },
               { ' ','x','x',' ',' ',' ',' ',' ','x',' ' },
               { ' ',' ',' ',' ',' ',' ',' ','x',' ',' ' },
               { ' ',' ',' ',' ',' ',' ',' ','x','s',' ' },
               //{ ' ',' ',' ','x',' ',' ',' ',' ',' ',' ' },
               //{ ' ',' ',' ',' ',' ',' ',' ',' ','x',' ' },
               //{ ' ',' ',' ',' ',' ','x',' ',' ','x',' ' },
               //{ ' ',' ',' ',' ',' ','x',' ',' ','x',' ' },
               //{ ' ',' ',' ',' ','x','x',' ',' ','x','s' }
            };
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write("|");
                }
                Console.WriteLine();
            }

            BFS(matrix);
        }

        static void BFS(char[,] matrix)
        {
            //Initialize
            List<Vector2> queue = new List<Vector2>();
            Dictionary<Vector2, Vector2> path = new Dictionary<Vector2, Vector2>();
            Vector2 start = FindStartBFS(matrix);
            BFSRecursive(matrix, start, path);
        }

        static Vector2 FindStartBFS(char[,] matrix)
        {
            Vector2 start = new Vector2(0, 0, true);
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (matrix[y, x] == 'e')
                    {
                        start.x = y;
                        start.y = x;
                        y = matrix.GetLength(1);
                        break;
                    }
                }
            }
            return start;
        }

        static void BFSRecursive(char[,] matrix, Vector2 current, Dictionary<Vector2, Vector2> path)
        {
            if (matrix[current.x, current.y] == 's')
            {
                PrintShortestPath();
                return;
            }
            Vector2[] childs = GetNeighbors(current, matrix);
            for (int i = 0; i < childs.Length; i++)
            {
                if (childs[i].passable)
                {
                    if (!childs[i].visited)
                    {
                        Console.WriteLine(childs[i].x + " " + childs[i].y);
                        path.Add(childs[i], current);
                        BFSRecursive(matrix, childs[i], path);
                        childs[i].visited = true;
                    }
                }
            }
        }

        static Vector2[] GetNeighbors(Vector2 position, char[,] matrix)
        {
            Vector2[] childs = new Vector2[4];
            childs[0] = GetNeighbor(position, matrix, 'R');
            childs[1] = GetNeighbor(position, matrix, 'D');
            childs[2] = GetNeighbor(position, matrix, 'L');
            childs[3] = GetNeighbor(position, matrix, 'U');
            return childs;
        }

        static Vector2 GetNeighbor(Vector2 position, char[,] matrix, char direction)
        {
            Vector2 result = new Vector2();
            bool passable = true;
            switch (direction)
            {
                case 'R':
                    if (!(position.x < 0 || position.x > matrix.GetLength(0) || position.y + 1 < 0 || position.y + 1 > matrix.GetLength(1)))
                    {
                        if (matrix[position.x, position.y + 1] == 'x')
                        {
                            passable = false;
                        }
                        result = new Vector2(position.x, position.y + 1, passable);
                    }
                    break;
                case 'D':
                    if (!(position.x + 1 < 0 || position.x + 1 > matrix.GetLength(0) || position.y < 0 || position.y > matrix.GetLength(1)))
                    {
                        if (matrix[position.x + 1, position.y] == 'x')
                        {
                            passable = false;
                        }
                        result = new Vector2(position.x + 1, position.y, passable);
                    }
                    break;
                case 'L':
                    if (!(position.x < 0 || position.x > matrix.GetLength(0) || position.y - 1 < 0 || position.y - 1 > matrix.GetLength(1)))
                    {
                        if (matrix[position.x, position.y - 1] == 'x')
                        {
                            passable = false;
                        }
                        result = new Vector2(position.x, position.y - 1, passable);
                    }
                    break;
                case 'U':
                    if (!(position.x - 1 < 0 || position.x - 1 > matrix.GetLength(0) || position.y < 0 || position.y > matrix.GetLength(1)))
                    {
                        if (matrix[position.x - 1, position.y] == 'x')
                        {
                            passable = false;
                        }
                        result = new Vector2(position.x - 1, position.y, passable);
                    }
                    break;
                default:
                    result = new Vector2(0, 0, false);
                    break;
            }
            return result;
        }

        static void PrintShortestPath()
        {
            Console.WriteLine("Path founded !!!");
        }
    }

    /// <summary>
    /// Modify the previous program to check whether a path exists between two cells without finding all possible paths. 
    /// Test the program with a matrix 100x100 filled only with passable cells.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {

        }
    } //Already done in another project

    /// <summary>
    /// You are given a matrix with passable and impassable cells. 
    /// Write a program that finds the largest area of neighboring passable cells.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {

        }
    } //Already done in another project

    /// <summary>
    /// Write a recursive program that traverses the whole hard disk C:\ recursively and prints all folders and files.
    /// </summary>
    public static class Exo14
    {
        public static void Execute()
        {
            RecursiveIterateOnHardDisk();
        }

        static void RecursiveIterateOnHardDisk()
        {
            PrintPath("D:/Steam", 0);
            Console.WriteLine("Finished !!!");
        }

        static void PrintPath(string path, int tabNbr)
        {
            bool next = true;
            try
            {
                string[] directories = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException e)
            {
                next = false;
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                next = false;
                Console.WriteLine(e.Message);
            }
            if (next)
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    DirectoryInfo info = new DirectoryInfo(directory);
                    for (int i = 0; i < tabNbr; i++)
                    {
                        Console.Write("   ");
                    }
                    Console.WriteLine(info.Name + "/");
                    PrintPath(directory, tabNbr + 1);
                }
            }
            next = true;
            try
            {
                string[] files = Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException e)
            {
                next = false;
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                next = false;
                Console.WriteLine(e.Message);
            }
            if (next)
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    for (int i = 0; i < tabNbr; i++)
                    {
                        Console.Write("   ");
                    }
                    Console.WriteLine(info.Name);
                }
            }
            return;
        }
    }
}
