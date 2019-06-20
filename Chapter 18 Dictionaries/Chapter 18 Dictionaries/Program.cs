using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_18_Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exo1.Execute();
            Exo2.Execute();
        }
    }

    /// <summary>
    /// Write a program that counts, in a given array of integers, the number of occurrences of each integer.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            Random random = new Random();
            int[] sequence = new int[random.Next(10, 20)];
            for(int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = random.Next(0, 10);
                Console.WriteLine(sequence[i]);
            }
            Dictionary<int, int> numberOccurences = NumberOccurences(sequence);
            foreach(int key in numberOccurences.Keys)
            {
                Console.WriteLine(key + " with " + numberOccurences[key] + " occurence(s).");
            }
        }

        public static Dictionary<int,int> NumberOccurences(int[] sequence)
        {
            Dictionary<int, int> numberOccurences = new Dictionary<int, int>();
            foreach(int number in sequence)
            {
                if(!numberOccurences.ContainsKey(number))
                {
                    numberOccurences.Add(number, 0);
                }
                numberOccurences[number]++;
            }
            return numberOccurences;
        }
    }

    /// <summary>
    /// Write a program to remove from a sequence all the integers, which appear odd(impair) number of times.
    /// For instance, for the sequence {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6} the output would be {5, 3, 3, 5}.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Random random = new Random();
            int[] sequence = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6 };
            //int[] sequence = new int[random.Next(10, 20)];
            //for (int i = 0; i < sequence.Length; i++)
            //{
            //    sequence[i] = random.Next(0, 10);
            //    Console.WriteLine( i + " : "+sequence[i]);
            //}
            Console.WriteLine();
            int[] result = RemoveOddNumberOccurences(sequence);
            Console.WriteLine("Result : ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(i + " : " + result[i]);
            }
        }

        public static int[] RemoveOddNumberOccurences(int[] sequence)
        {
            Dictionary<int, int> occurences = NumberOccurences(sequence);
            List<int> result = new List<int>(sequence.Length);
            IEnumerable <KeyValuePair<int,int>> evenOccurences = occurences.Where(IsEven);
            for (int i = 0; i < sequence.Length; i++)
            {
                foreach (KeyValuePair<int, int> number in evenOccurences)
                {
                    if(sequence[i] == number.Key)
                    {
                        result.Add(sequence[i]);
                        break;
                    }
                }
            }
            return result.ToArray();
        }

        public static bool IsEven(KeyValuePair<int,int> element)
        {
            return element.Value % 2 == 0;
        }

        public static Dictionary<int, int> NumberOccurences(int[] sequence)
        {
            Dictionary<int, int> numberOccurences = new Dictionary<int, int>();
            foreach (int number in sequence)
            {
                if (!numberOccurences.ContainsKey(number))
                {
                    numberOccurences.Add(number, 0);
                }
                numberOccurences[number]++;
            }
            return numberOccurences;
        }
    }

    /// <summary>
    /// Write a program that counts how many times each word from a given text file words.txt appears in it.
    /// The result words should be ordered by their number of occurrences in the text. 
    /// Example: " This is the TEXT. Text, text, text – THIS TEXT! Is this the text? " 
    /// Result: is => 2, the => 2, this => 3, text => 6.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {

        }
    }
}
