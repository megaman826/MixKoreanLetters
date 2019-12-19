using System;
using System.Collections.Generic;
using System.IO;

namespace MixKoreanLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Environment.CurrentDirectory;

            string text;
            string resultFileName = "result.txt";

            resultFileName = Path.Combine(currentDirectory, resultFileName);
            while (true)
            {
                Console.WriteLine("Please Input Text: ");
                Console.WriteLine("(input 'q' or 'Q' quit program.)");
                text = Console.ReadLine();

                if (text == "q" || text == "Q")
                    break;

                // cut 'text' by space
                // relocate each words
                text = text.Trim();
                string[] lines = text.Split('\n');
                string newLines = "";
                Random random = new Random();
                foreach(string line in lines)
                {
                    string newLine = "";
                    string[] words = text.Split(' ');

                    foreach(string word in words)
                    {
                        char[] array = word.ToCharArray();
                        Random rng = new Random();
                        int n = array.Length;
                        while (n > 1)
                        {
                            n--;
                            int k = rng.Next(n + 1);
                            var value = array[k];
                            if(value.Equals(",") || value.Equals("."))
                            {
                                continue;
                            }

                            array[k] = array[n];
                            array[n] = value;
                        }
                        newLine += new string(array) + " ";
                    }

                    newLines += newLine + "\n";
                }

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(resultFileName))
                {
                    file.WriteLine(newLines);
                }

                Console.WriteLine(">>Make " + resultFileName + "!! Check This File.");
                Console.WriteLine();
            }
        }
    }
}
