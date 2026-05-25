using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lab2
{
    internal class Program
    {
        // list for storing words from file
        static IList<string> words = new List<string>();

        static void Main(string[] args)
        {
            bool running = true;

           
            ShowMenu();

            while (running)
            {
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        ImportWords("Words.txt");
                    }
                    else if (choice == "2")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            IList<string> result = BubbleSort(words);
                            Console.WriteLine("Sorted " + result.Count + " words.");
                        }
                    }
                    else if (choice == "3")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            IList<string> result = LINQSort(words);
                            Console.WriteLine("Sorted " + result.Count + " words.");
                        }
                    }
                    else if (choice == "4")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            CountDistinct(words);
                        }
                    }
                    else if (choice == "5")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            FirstTen(words);
                        }
                    }
                    else if (choice == "6")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            ReverseWords(words);
                        }
                    }
                    else if (choice == "7")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            EndsWithA(words);
                        }
                    }
                    else if (choice == "8")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            StartsWithM(words);
                        }
                    }
                    else if (choice == "9")
                    {
                        if (words.Count == 0)
                        {
                            Console.WriteLine("No words loaded. Use option 1 first.");
                        }
                        else
                        {
                            LongWordsWithS(words);
                        }
                    }
                    else if (choice == "X" || choice == "x")
                    {
                        running = false;
                        Console.WriteLine("Exit !");
                    }
                    else
                    {
                        Console.WriteLine("Wrong option, try again.");
                    }
                }
                catch (Exception ex)
                {
                    // catch errors so program doesn't crash
                    Console.WriteLine("Something went wrong: " + ex.Message);
                }

                // blank line for readability
                if (running)
                {
                    Console.WriteLine();
                }
            }
        }

        // prints the menu
        static void ShowMenu()
        {
            Console.WriteLine("-- Lab 1 Menu --");
            Console.WriteLine("(1) Import Words from File");
            Console.WriteLine("(2) Bubble Sort");
            Console.WriteLine("(3) LINQ Sort");
            Console.WriteLine("(4) Count Distinct Words");
            Console.WriteLine("(5) First 10 Words");
            Console.WriteLine("(6) Reverse Each Word");
            Console.WriteLine("(7) Words Ending With 'a'");
            Console.WriteLine("(8) Words Starting With 'm'");
            Console.WriteLine("(9) Words > 5 chars and have 's'");
            Console.WriteLine("(X) Exit");
            Console.WriteLine();
        }

        // option 1 - reads words from text file using StreamReader
        static void ImportWords(string path)
        {
            // reset the list every time we import
            words = new List<string>();

            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();
            while (line != null)
            {
                // split each line by space in case there are multiple words
                string[] parts = line.Split(' ');
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i] != "")
                    {
                        words.Add(parts[i]);
                    }
                }
                line = reader.ReadLine();
            }

            reader.Close();

            Console.WriteLine("Read " + words.Count + " words from " + path);
        }

        // option 2 - bubble sort
        static IList<string> BubbleSort(IList<string> words)
        {
            // copy the list so original doesn't change
            IList<string> sorted = new List<string>();
            for (int i = 0; i < words.Count; i++)
            {
                sorted.Add(words[i]);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // bubble sort algorithm
            int n = sorted.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sorted[j].CompareTo(sorted[j + 1]) > 0)
                    {
                        // swap
                        string temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("Bubble sort time: " + sw.ElapsedMilliseconds + " ms");

            return sorted;
        }

        // option 3 - LINQ sort
        static IList<string> LINQSort(IList<string> words)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // OrderBy makes a new sorted list, doesn't change original
            IList<string> sorted = words.OrderBy(w => w).ToList();

            sw.Stop();
            Console.WriteLine("LINQ sort time: " + sw.ElapsedMilliseconds + " ms");

            return sorted;
        }

        // option 4 - count distinct words
        static void CountDistinct(IList<string> words)
        {
            int count = words.Distinct().Count();
            Console.WriteLine("Distinct words: " + count);
        }

        // option 5 - first 10 words
        static void FirstTen(IList<string> words)
        {
            IList<string> first = words.Take(10).ToList();

            Console.WriteLine("First 10 words:");
            foreach (string w in first)
            {
                Console.WriteLine(w);
            }
        }

        // option 6 - reverse each word (without changing original list)
        static void ReverseWords(IList<string> words)
        {
            // Select makes a new list, so original list stays the same
            IList<string> reversed = words.Select(w => new string(w.Reverse().ToArray())).ToList();

            Console.WriteLine("Reversed words:");
            foreach (string w in reversed)
            {
                Console.WriteLine(w);
            }
        }

        // option 7 - words ending with 'a'
        static void EndsWithA(IList<string> words)
        {
            IList<string> result = words.Where(w => w.ToLower().EndsWith("a")).ToList();

            Console.WriteLine("Words ending with 'a':");
            foreach (string w in result)
            {
                Console.WriteLine(w);
            }
            Console.WriteLine("Count: " + result.Count);
        }

        // option 8 - words starting with 'm'
        static void StartsWithM(IList<string> words)
        {
            IList<string> result = words.Where(w => w.ToLower().StartsWith("m")).ToList();

            Console.WriteLine("Words starting with 'm':");
            foreach (string w in result)
            {
                Console.WriteLine(w);
            }
            Console.WriteLine("Count: " + result.Count);
        }

        // option 9 - words longer than 5 chars and contain 's'
        static void LongWordsWithS(IList<string> words)
        {
            IList<string> result = words.Where(w => w.Length > 5 && w.ToLower().Contains("s")).ToList();

            Console.WriteLine("Words > 5 chars and have 's':");
            foreach (string w in result)
            {
                Console.WriteLine(w);
            }
            Console.WriteLine("Count: " + result.Count);
        }
    }
}