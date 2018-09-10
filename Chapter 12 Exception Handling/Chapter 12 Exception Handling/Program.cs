using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chapter_12_Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exo7.Execute();
            //Exo8.Execute();
            //Exo9.Execute();
            Exo10.Execute();
        }
    }

    /// <summary>
    /// Write a program that takes a positive integer from the console and prints the square root of this integer. 
    /// If the input is negative or invalid print "Invalid Number" in the console. 
    /// In all cases print "Good Bye".
    /// </summary>
    static class Exo7
    {
        public static void Execute()
        {
            Console.WriteLine("Write a number : ");
            try
            {
                uint number = uint.Parse(Console.ReadLine());

                double squareRoot = Math.Sqrt(number);

                Console.WriteLine("The square root of " + number + " is : " + squareRoot);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("[Error] " + e.Message);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("[Error] " + e.Message);
            }
            catch(OverflowException e)
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("[Error] " + e.Message);
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }
        }
    }



    // Write a method ReadNumber(int start, int end) that reads an integer from the console in the range [start…end]. 
    // In case the input integer is not valid or it is not in the required range throw appropriate exception. 
    // Using this method, write a program that takes 10 integers a1, a2, …, a10 such that 1 < a1 <  < a10 < 100  => ???
    static class Exo8
    {
        public static void Execute()
        {
            Random random = new Random();

            ReadNumber(2, 100);
        }

        public static void ReadNumber(int start, int end)
        {
            Console.WriteLine("Write a number : ");
            try
            {
                int number = int.Parse(Console.ReadLine());

                if(number < start || number > end)
                {
                    throw new Exception("The number give is not in the range [" + start + "," + end + "]");
                }

                Console.WriteLine("The number " + number + " is in the range [" + start + "," + end +"]");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("[Error] " + e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("[Error] " + e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("[Error] " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("[Error] " + e.Message);
            }
        }
    }

    /// <summary>
    /// Write a method that takes as a parameter the name of a text file, reads the file and returns its content as string.
    /// </summary>
    static class Exo9
    {
        public static void Execute()
        {
            try
            {
                string lines = ReadFile("C:/Users/Wolfstep/Documents/PROG/C#/Chapter12Exo9.txt");

                Console.WriteLine(lines);
            }
            catch(Exception e)
            {
                Console.WriteLine("[Error] " + e.Message);
            }
        }

        static string ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string lines = "";
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            while (!reader.EndOfStream)
            {
                lines += reader.ReadLine();
                lines += "\n";
            }
            return lines;
        }
    }

    /// <summary>
    /// Write a method that takes as a parameter the name of a binary file, reads the content of the file and returns it as an array of bytes. 
    /// Write a method that writes the file content to another file. 
    /// Compare both files.
    /// </summary>
    static class Exo10
    {
        public static void Execute()
        {
            byte[] binary = new byte[0];
            try
            {
                binary = ReadBinaryFile("C:/Users/Wolfstep/Documents/PROG/C#/Chapter12Exo9.txt");
                CopyFile("C:/Users/Wolfstep/Documents/PROG/C#/Chapter12Exo9.txt", "C:/Users/Wolfstep/Documents/PROG/C#/Chapter12Exo9Copy.txt");
            }
            catch(Exception e)
            {
                Console.WriteLine("[Error] " + e.Message);
            }

            for(int i = 0; i < binary.Length;i++)
            {
                Console.WriteLine(binary[i]);
            }
        }

        public static byte[] ReadBinaryFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(file, Encoding.ASCII);
            byte[] binary = reader.ReadBytes((int)reader.BaseStream.Length);
            reader.Close();
            return binary;
        }

        public static void CopyFile(string pathFileContent, string pathFileCopy)
        {
            byte[] binary = new byte[0];
            try
            {
                binary = ReadBinaryFile(pathFileContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("[Error] " + e.Message);
            }

            BinaryWriter writer = new BinaryWriter(File.Open(pathFileCopy, FileMode.Create),Encoding.ASCII);
            writer.BaseStream.Write(binary, 0, binary.Length);
            writer.Close();
        }
    }


    [Serializable]
    public class FileParseException : Exception
    {
        public string fileName { get; }
        public int row { get; }

        public FileParseException() { }
        public FileParseException(string message) : base(message) { }
        public FileParseException(string message, string fileName, int row) :base(message) { this.fileName = fileName; this.row = row; }
        public FileParseException(string message, Exception inner) : base(message, inner) { }
        protected FileParseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
