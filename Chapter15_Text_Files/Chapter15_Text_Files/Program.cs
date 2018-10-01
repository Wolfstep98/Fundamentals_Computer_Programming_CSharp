using System;
using System.IO;
using System.Collections.Generic;

namespace Chapter15_Text_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Exo10.Execute();
        }
    }

    /// <summary>
    /// Write a program that reads a text file and prints its odd lines on the console.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {
            StreamReader reader = new StreamReader("SimpleTextFile.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                }
            }
        }
    }

    /// <summary>
    /// Write a program that joins two text files and records the results in a third file.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            StreamWriter writer = new StreamWriter("FileJoinResult.txt");
            StreamReader readerOne = new StreamReader("FileJoin1.txt");
            StreamReader readerTwo = new StreamReader("FileJoin2.txt");
            string line = null;
            using (writer)
            {
                using (readerOne)
                {
                    line = readerOne.ReadLine();
                    while(line != null)
                    {
                        writer.WriteLine(line);
                        line = readerOne.ReadLine();
                    }
                }
                using (readerTwo)
                {
                    line = readerTwo.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = readerTwo.ReadLine();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Write a program that reads the contents of a text file and inserts the line numbers at the beginning of each line, then rewrites the file contents.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {
            StreamReader reader = new StreamReader("FileExo3.txt");
            string text = null;
            using (reader)
            {
                text = reader.ReadToEnd();
            }
            string[] lines = text.Split(Environment.NewLine);

            StreamWriter writer = new StreamWriter("FileExo3.txt", false);
            using (writer)
            {
                for(int i = 0; i < lines.Length;i++)
                {
                    writer.WriteLine((i + 1) + " - " + lines[i]);
                }
            }
        }
    }

    /// <summary>
    /// Write a program that compares two text files with the same number of rows line by line and prints the number of equal and the number of different lines.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            StreamReader readerOne = new StreamReader("FileComparable.txt");
            StreamReader readerTwo = new StreamReader("FileToCompare.txt");
            string lineOne = null;
            string lineTwo = null;
            int equalLines = 0;
            int differentLines = 0;
            using (readerOne)
            {
                using (readerTwo)
                {
                    lineOne = readerOne.ReadLine();
                    lineTwo = readerTwo.ReadLine();
                    while(lineOne != null && lineTwo != null)
                    {
                        if (lineOne == lineTwo)
                            equalLines++;
                        else
                            differentLines++;
                        lineOne = readerOne.ReadLine();
                        lineTwo = readerTwo.ReadLine();
                    }
                    if (lineOne != null || lineTwo != null)
                        throw new IOException("The file must contain the same number of lines.");
                }
            }
            Console.WriteLine("The 2 files have "+ equalLines + " equal lines and " + differentLines + " different lines !");
        }
    }

    /// <summary>
    /// Write a program that reads a square matrix of integers from a file and finds the sub-matrix with size 2 × 2 that has the maximal sum and writes this sum to a separate text file. 
    /// The first line of input file contains the size of the recorded matrix (N). 
    /// The next N lines contain N integers separated by spaces.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            StreamReader reader = new StreamReader("FileExo5.txt");
            int[,] matrix;
            int lenght = 0;
            string line = null;
            using (reader)
            {
                line = reader.ReadLine();
                lenght = int.Parse(line);
                matrix = new int[lenght, lenght];
                line = reader.ReadLine();
                string[] elements = line.Split(' ');
                for (int i = 0; i < lenght; i++)
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        matrix[i, j] = int.Parse(elements[j]);
                    }
                    line = reader.ReadLine();
                }
            }

            int bestSum = 0;
            for (int i = 0; i < lenght - 1; i++) 
            {
                for (int j = 0; j < lenght - 1; j++)
                {
                    int temp = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (temp > bestSum)
                        bestSum = temp;
                }
            }
            Console.WriteLine("The sub-matrix with size 2 × 2 has the maximal sum : " + bestSum);
        }
    }

    /// <summary>
    /// Write a program that reads a list of names from a text file, arranges them in alphabetical order, and writes them to another file. 
    /// The lines are written one per row.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            StreamReader reader = new StreamReader("Names.txt");
            string line = null;
            List<string> names = new List<string>();
            using (reader)
            {
                line = reader.ReadLine();
                while(line != null)
                {
                    names.Add(line);
                    line = reader.ReadLine();
                }
            }
            
            names.Sort(CompareAlphabeticalOrder);

            StreamWriter writer = new StreamWriter("NamesOrdered.txt");
            using (writer)
            {
                for(int i = 0; i < names.Count;i++)
                {
                    writer.WriteLine(names[i]);
                }
            }
        }

        static int CompareAlphabeticalOrder(string a, string b)
        {
            return string.Compare(a,b);
        }
    }

    /// <summary>
    /// Write a program that replaces every occurrence of the substring "start" with "finish" in a text file. 
    /// Can you rewrite the program to replace whole words only? 
    /// Does the program work for large files (e.g. 800 MB)?
    /// </summary>
    public static class Exo7
    {
        public static string token = " start ";
        public static string newToken = " finish ";

        public static void Execute()
        {
            StreamReader reader = new StreamReader("FileExo7.txt");
            StreamWriter writer = new StreamWriter("FileExo7Fixed.txt");

            string line = null;
            using (reader)
            {
                using (writer)
                {
                    line = reader.ReadLine();
                    while(line != null)
                    {
                        writer.WriteLine(FixToken(line));
                        line = reader.ReadLine();
                    }
                }
            }
        }

        public static string FixToken(string line)
        {
            return line.Replace(token, newToken);
        }
    }

    /// <summary>
    /// Write the previous program so that it changes only the whole words (not parts of the word).
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Write a program that deletes all the odd lines of a text file.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {
            StreamReader reader = new StreamReader("FileExo9.txt");
            StreamWriter writer = new StreamWriter("FileExo9WithoutOdd.txt");
            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Write a program that extracts from an XML file the text only (without the tags).
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            List<string> words = new List<string>();
            StreamReader reader = new StreamReader("FileExo10.xml");
            int depth = 0;
            using (reader)
            {
                string line = reader.ReadLine();
                string word = "";
                while(line != null)
                {
                    for(int i = 0; i < line.Length;i++)
                    {
                        if(depth == 0)
                        {
                            if (line[i] == '<')
                            {
                                if(word != "")
                                {
                                    words.Add(word);
                                }
                                depth++;
                                continue;
                            }
                            else if(line[i] != ' ' && line[i] != '\n' && line[i] != '\r')
                            {
                                word += line[i];
                            }
                        }
                        else
                        {
                            if (line[i] == '>')
                            {
                                depth--;
                                word = "";
                            }
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            for(int i = 0; i < words.Count;i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }

    /// <summary>
    /// Write a program that deletes all words that begin with the word "test". 
    /// The words will contain only the following chars: 0…9, a…z, A…Z.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {

        }
    } //TODO

    /// <summary>
    /// A text file words.txt is given, containing a list of words, one per line. 
    /// Write a program that deletes in the file text.txt all the words that occur in the other file. 
    /// Catch and handle all possible exceptions.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {

        }
    } //TODO

    /// <summary>
    /// Write a program that reads a list of words from a file called words.txt, counts how many times each of these words is found in another file text.txt, and records the results in a third file – result.txt, 
    /// but before that, sorts them by the number of occurrences in descending order. 
    /// Handle all possible exceptions.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {

        }
    } //TODO
}
