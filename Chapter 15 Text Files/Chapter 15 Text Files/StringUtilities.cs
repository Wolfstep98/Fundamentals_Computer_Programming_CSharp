using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter_15_Text_Files
{
    /// <summary>
    /// Class containing string functions utilities.
    /// </summary>
    public static class StringUtilities
    {
        //private static readonly char[] 

        /// <summary>
        /// Removes a selected token <paramref name="word"/> from a <paramref name="sentence"/>.
        /// You can select a find <paramref name="option"/>.
        /// </summary>
        /// <param name="sentence">The sentence to remove the string from.</param>
        /// <param name="word">The word to remove from the sentence.</param>
        /// <param name="option">The remove option.</param>
        /// <returns>The <paramref name="sentence"/> without the <paramref name="word"/>.</returns>
        public static string RemoveTokenFromString(string sentence, string word, StringFindOption option = StringFindOption.Part)
        {
            int index = 0;
            int startIndex = 0;
            char[] temp = null;
            StringBuilder tempBuffer = new StringBuilder(100);
            //Regex
            string pattern = @"\b(" + word + @")/b";
            Regex regex = new Regex(pattern);
            string result = Regex.Replace(sentence, pattern, "");
            return result;

            // Custom word detection
            while (index != -1 && index < sentence.Length)
            {
                index = sentence.IndexOf(word, index, sentence.Length - index, StringComparison.CurrentCulture);
                if (index != -1)
                {
                    switch(option)
                    {
                        case StringFindOption.Part:
                            break;
                        case StringFindOption.WholeWord:
                            break;
                        case StringFindOption.BeginningOfAWord:
                            break;
                        // Check if the word is at the end of another word.
                        case StringFindOption.EndOfAWord:
                            int nextChar = index + word.Length;
                            if(index - 1 >= 0)
                            {
                                // Check if the word is attached to another.
                                if(sentence[index - 1] == ' ')
                                {
                                    index += word.Length;
                                    startIndex = index;
                                    break;
                                }
                            }
                            if (nextChar < sentence.Length)
                            {
                                // Check if the word is the last part of another.
                                if (sentence[nextChar] != ' ')
                                {
                                    index += word.Length;
                                    startIndex = index;
                                    break;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    temp = new char[index - startIndex];
                    sentence.CopyTo(startIndex, temp, 0, index - startIndex);
                    tempBuffer.Append(temp);
                    temp = null;
                    index += word.Length;
                    startIndex = index;
                }
                else
                {
                    if (startIndex != 0)
                    {
                        temp = new char[sentence.Length - startIndex];
                        sentence.CopyTo(startIndex, temp, 0, sentence.Length - startIndex);
                        tempBuffer.Append(temp);
                    }
                    break;
                }
            }
            if (tempBuffer.Length == 0)
                return sentence;
            return tempBuffer.ToString(0, tempBuffer.Length);
        }
    }
    
    public enum StringFindOption
    {
        Part,
        WholeWord,
        BeginningOfAWord,
        EndOfAWord
    }
}
