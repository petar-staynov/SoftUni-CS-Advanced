using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read words to count
            StreamReader wordsReader = new StreamReader("../../words.txt");
//            List<string> words = new List<string>();
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (wordsReader)
            {
                string word = wordsReader.ReadLine();
                while (word != null)
                {
                    if (!words.ContainsKey(word))
                    {
                        words[word.ToLower()] = 0;
                    }

                    word = wordsReader.ReadLine();
                }
            }

            //Read file
            StreamReader streamReader = new StreamReader("../../text.txt");
            using (streamReader)
            {
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    string cleanLine = Regex.Replace(line, "[^0-9A-Za-z ]", " ");
                    var lineArr = cleanLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    for (int word = 0; word < lineArr.Length; word++)
                    {
                        string currentWord = lineArr[word].ToLower();
                        if (words.ContainsKey(currentWord))
                        {
                            words[currentWord]++;
                        }
                    }

                    line = streamReader.ReadLine();
                }
            }

            //Sort the result dictionary
            var sortedWords = words.OrderByDescending(pair => pair.Value);
            foreach (var keyValuePair in sortedWords)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
            }
        }
    }
}