using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Chapter_13_Strings_TextProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Exo12.Execute();
        }
    }

    /// <summary>
    /// Write a program that reads a string, reverse it and prints it to the console. 
    /// For example: "introduction" => "noitcudortni".
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {
            Console.WriteLine("Write a word/sentence : ");
            string text = Console.ReadLine(); //= "introduction";
            string reverse = ReverseString(text);
            Console.WriteLine(text + " => " + reverse);
        }

        public static string ReverseString(string text)
        {
            StringBuilder builder = new StringBuilder(text.Length);
            for(int i = text.Length - 1; i >= 0;i--)
            {
                builder.Append(text[i]);
            }
            return builder.ToString();
        }
    }

    public static class Exo3
    {
        public static void Execute()
        {
            Console.WriteLine("Write an Arithmetic Expression with parentheses : ");
            string operation = Console.ReadLine();
            bool result = ParenthesesPlacedCorrectly(operation);

            Console.WriteLine("Are the parentheses placed correctly ? " + result);
        }

        public static bool ParenthesesPlacedCorrectly(string operation)
        {
            int depth = 0;
            for(int i = 0; i < operation.Length;i++)
            {
                if(operation[i] == '(')
                {
                    depth++;
                }
                else if(operation[i] == ')')
                {
                    depth--;
                }
                else
                {
                    continue;
                }
                if(depth < 0)
                {
                    return false;
                }
            }
            return (depth == 0);
        }
    }

    /// <summary>
    /// How many backslashes you must specify as an argument to the method Split(…) in order to split the text by a backslash?
    /// Example: one\two\three.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {
            string text = "one\\two\\three";
            Console.WriteLine(text);
            char[] splitChar = new char[1] { '\\' };
            string[] result = text.Split(splitChar);
            for(int i = 0; i < result.Length;i++)
            {
                Console.WriteLine(i + " : " + result[i]);
            }
        }
    }

    /// <summary>
    /// Write a program that detects how many times a substring is contained in the text.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string substring = "in";
            int count = SubStringCount(text, substring);
            Console.WriteLine("There is exactly " + count + " occurences of " + substring + " in the text.");
        }

        public static int SubStringCount(string text, string substring)
        {
            int count = 0;
            int index = text.IndexOf(substring,StringComparison.CurrentCultureIgnoreCase);
            while(index != -1)
            {
                count++;
                index = text.IndexOf(substring,index + substring.Length, StringComparison.CurrentCultureIgnoreCase);
            }
            return count;
        }
    }

    /// <summary>
    /// A text is given. 
    /// Write a program that modifies the casing of letters to uppercase at all places in the text surrounded by <upcase> and </upcase> tags. 
    /// Tags cannot be nested.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            string text = "We are living in a<upcase> yellow submarine</upcase>.\nWe don't have <upcase>anything</upcase> else.";
            string textToUpper = TextTagToUpper(text);
            Console.WriteLine(textToUpper);
        }

        public static string TextTagToUpper(string text)
        {
            string openTag = "<upcase>";
            string closeTag = "</upcase>";
            StringBuilder builder = new StringBuilder(text.Length);

            int lastIndex = 0;
            int index = text.IndexOf(openTag);
            while (index != -1)
            {
                for (int i = lastIndex; i < index;i++)
                {
                    builder.Append(text[i]);
                }
                index += openTag.Length;
                int closeIndex = text.IndexOf(closeTag, index);
                string textToUpcase = text.Substring(index,closeIndex - index);
                for(int i = 0; i < textToUpcase.Length;i++)
                {
                    builder.Append(char.ToUpper(textToUpcase[i]));
                }
                index = closeIndex + closeTag.Length;
                lastIndex = index;
                index = text.IndexOf(openTag, lastIndex);
            }
            for (int i = lastIndex; i < text.Length; i++)
            {
                builder.Append(text[i]);
            }

            return builder.ToString();
        }
    }

    /// <summary>
    /// Write a program that reads a string from the console (20 characters maximum) and if shorter complements it right with "*" to 20 characters.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {
            Console.WriteLine("Write a text, (20 characters max) :");
            string text = Console.ReadLine();
            if (text.Length > 20)
            {
                Console.WriteLine("Your text is too long, 20 characters max !");
                return;
            }
            StringBuilder builder = new StringBuilder(20);
            for(int i = 0; i < 20;i++)
            {
                if(i < text.Length)
                {
                    builder.Append(text[i]);
                }
                else
                {
                    builder.Append('*');
                }
            }
            Console.WriteLine(builder.ToString());
        }
    }

    /// <summary>
    /// Write a program that converts a given string into the form of array of Unicode escape sequences in the format used in the C# language
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {
            Console.WriteLine("Write smtg : ");
            string text = Console.ReadLine();
            string[] unicodes = new string[text.Length];
            for (int i = 0; i < text.Length;i++)
            {
                unicodes[i] = string.Format(@"\u{0:x4}",(int)text[i]);
                Console.WriteLine(unicodes[i]);
            }   
        }
    }


    // Write a program that encrypts a text by applying XOR (excluding or) operation between the given source characters and given cipher code. 
    //The encryption should be done by applying XOR between the first letter of the text and the first letter of the code, the second letter of the text and the second letter of the code, etc. 
    //until the last letter of the code, then goes back to the first letter of the code and the next letter of the text. 
    //Print the result as a series of Unicode escape characters \xxxx.
    //Sample source text: "Test". Sample cipher code: "ab". 
    //The result should be the following: "\u0035\u0007\u0012\u0016".
    public static class Exo9
    {
        public static void Execute()
        {
            Console.WriteLine("Write a text : ");
            string text = Console.ReadLine();
            string cipher = "ab";

            string[] unicodes = new string[text.Length];

            int cipherIndex = 0;
            for(int i = 0; i < text.Length;i++)
            {
                unicodes[i] = string.Format(@"\u{0:x4}", ((int)text[i] ^ (int)cipher[cipherIndex]));
                Console.WriteLine(unicodes[i]);
                cipherIndex++;
                cipherIndex %= cipher.Length;
            }
        }
    }

    /// <summary>
    /// Write a program that extracts from a text all sentences that contain a particular word. 
    /// We accept that the sentences are separated from each other by the character "." and the words are separated from one another by a character which is not a letter.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string[] sentences = SentenceWithWord(text, "submarine");
            for (int i = 0; i < sentences.Length; i++)
            {
                Console.WriteLine(sentences[i]);
            }
        }

        public static string[] SentenceWithWord(string text, string word)
        {
            int index = 0;
            char sentenceSplit = '.';
            char wordSplit = ' ';
            char separator = ';';
            StringBuilder sentences = new StringBuilder();

            index = text.IndexOf(word);
            while (index != -1)
            {
                //First, find if it's the word and not a little part of a word : thINking (incorrect) and IN (correct) for example.
                if(index - 1 != -1 && 
                    (text[index - 1] == sentenceSplit || text[index - 1] == wordSplit)
                    && (text[index + word.Length] == sentenceSplit || text[index + word.Length] == wordSplit))
                {
                    //now find the beginning and the end of the sentence ty to the '.'
                    int startIndex = text.LastIndexOf(sentenceSplit, index) + 1;
                    if (text[startIndex] == wordSplit)
                        startIndex++;
                    int endIndex = text.IndexOf(sentenceSplit, index) + 1;
                    sentences.Append(text.Substring(startIndex, endIndex - startIndex));
                    sentences.Append(separator);

                    index = text.IndexOf(word, endIndex);
                }
                else
                {
                    continue;
                }
            }

            return sentences.ToString().Split(separator);
        }
    }

    /// <summary>
    /// A string is given, composed of several "forbidden" words separated by commas. 
    /// Also a text is given, containing those words. 
    /// Write a program that replaces the forbidden words with asterisks.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {
            string forbiddenWord = "C#,CLR,Microsoft";
            string text = "Microsoft announced its next generation C# compiler today. It uses advanced parser and special optimizer for the Microsoft CLR.";

            string[] forbiddenWords = forbiddenWord.Split(',');
            int wordLenght = 0;
            for(int i = 0; i < forbiddenWords.Length;i++)
            {
                wordLenght = forbiddenWords[i].Length;
                string replaceWord = "";
                for(int j = 0; j < wordLenght;j++)
                {
                    replaceWord += "*";
                }
                text = Regex.Replace(text, forbiddenWords[i],replaceWord);
            }

            Console.WriteLine(text);
        }
    }

    /// <summary>
    /// Write a program that reads a number from console and prints it in 15-character field, aligned right in several ways: 
    /// as a decimal number, hexadecimal number, percentage, currency and exponential (scientific) notation.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {
            Console.WriteLine("Write a number : ");
            double number = double.Parse(Console.ReadLine());

            //Decimal number
            Console.WriteLine("{0,15:f}",number);
            //Hexadecimal number
            Console.WriteLine("{0:x15}",(int)number);
            //Percentage
            Console.WriteLine("{0:p}", number);
            //Currency
            Console.WriteLine("{0:c}",number);
            //Exponential
            Console.WriteLine("{0:e}",number);
        }
    }

    /// <summary>
    /// Write a program that parses an URL in following format: [protocol]://[server]/[resource]
    /// It should extract from the URL the protocol, server and resource parts.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {
            
        }
    }
}
