using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_2
{
    class Program
    {
        static Random rnd = new Random();
        static void FillArr(int[] arr, int left = 0, int right = 100)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(left, right);
            }
        }
        static void ShowArr(int[] arr)
        {
            foreach (int el in arr)
                Console.Write($"{el,-5}");
            Console.WriteLine();
        }
        //Task 1
        static void MaxMin(int[] arr, ref int max, ref int min)
        {
            max = arr.Max();
            min = arr.Min();
        }
        //Task 2
        static void Task2(string str)
        {
            string minLen, maxLen, firstAlpha, lastAlpha;
            string[] arr = str.Split(".,\n\'\" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            minLen = maxLen = firstAlpha = lastAlpha = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (String.Compare(firstAlpha, arr[i], true) > 0)
                    firstAlpha = arr[i];
                else if (String.Compare(lastAlpha, arr[i], true) < 0)
                    lastAlpha = arr[i];
                if (arr[i].Length < minLen.Length)
                    minLen = arr[i];
                else if (arr[i].Length > maxLen.Length)
                    maxLen = arr[i];
            }
            Console.WriteLine($"Text: {str}");
            Console.WriteLine($"MinLen: {minLen}  MaxLen: {maxLen}");
            Console.WriteLine($"FirstAlpha: {firstAlpha}  LastAlpha: {lastAlpha}");
        }
        //Task 3
        static void Task3(string str, char letter)
        {
            int index = -1, newIndex = 0;
            Console.Write($"Letter {letter} ");
            if (str.IndexOf(letter) < 0)
                Console.WriteLine($"is not found.");
            else
            {
                Console.Write($"on position: ");
                while (index < str.Length && (newIndex = str.IndexOf(letter, index + 1)) >= 0)
                {
                    Console.Write($" {newIndex} ");
                    index = newIndex;
                }
                Console.WriteLine();
                str = str.Replace(letter, char.ToUpper(letter));
                if (index != str.Length - 1)
                    str = str.Remove(index + 1);
                Console.WriteLine($"Your string now: {str}");
            }
        }
        //Task 4
        static void Task4(ref string str, params char[] arr)
        {
            int index;
            foreach (char el in arr)
            {
                index = 0;
                while ((index < str.Length) && ((index = str.IndexOf(el, index)) >= 0))
                    str = str.Remove(index, 1);
            }
        }
        //Task 5
        static void Task5(string str)
        {
            char tmp;
            int quantity = 0;
            for (int i = 97; i < 123; i++)
            {
                tmp = Convert.ToChar(i);
                Console.Write($"{tmp} ");
                if (str.IndexOf(tmp) >= 0)
                {
                    quantity = str.ToLower().Count((x) => { return x == tmp; });
                    Console.Write($"[{quantity}]\t");
                    for (int j = 0; j < quantity; j++)
                        Console.Write("*");
                }
                else
                    Console.Write("[-]");
                Console.WriteLine();
            }
        }
        //Task 6
        static void Task6(string str)
        {
            string[] words = new string[] {
                "Console",  "WriteLine", "Write", "int", "double", "char", "string", "static", "Convert",
                "ref", "out", "new", "Read", "ReadLine", "ToLower", "ToUpper", "void", "for", "ToChar"};
            int[] counters = new int[words.Length];
            string[] code = str.Split(" .,\n\t()\'\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (Array.FindIndex(code, (x) => { return x == words[i]; }) >= 0)
                    counters[i] = code.Count((x) => { return x == words[i]; });
            }
            Array.Sort(counters, words);
            Console.WriteLine($"Key words appear in given code:");
            for (int i = counters.Length - 1; i >= 0 && counters[i] > 0; i--)
            {
                Console.WriteLine($"{words[i]}\t- {counters[i]} {(counters[i] > 1 ? "times" : "time")}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task1 ===============");
            int max = 0, min = 0;
            int[] arr1 = new int[10];
            FillArr(arr1);
            ShowArr(arr1);
            MaxMin(arr1, ref max, ref min);
            Console.WriteLine($"Max: {max}\t Min: {min}.");
            Console.WriteLine();

            Console.WriteLine("Task2 ===============");
            string test2 = "Lets assume this sentence is long enough.";
            Task2(test2);
            Console.WriteLine();

            Console.WriteLine("Task3 ===============");
            Console.WriteLine($"Enter some text: ");
            string str3 = Console.ReadLine();
            Console.WriteLine($"Enter letter to find: ");
            char ch3 = Convert.ToChar(Console.ReadLine());
            Task3(str3, ch3);
            Console.WriteLine();

            Console.WriteLine("Task4 ===============");
            Console.Write($"Enter some text: ");
            string text = Console.ReadLine();
            Console.WriteLine(text);
            Task4(ref text, 'a', 'e', 'i', 'o', 'u', 'y');
            Console.WriteLine(text);
            Console.WriteLine();

            Console.WriteLine("Task5 ===============");
            string task5 = "I don’t know whether to delete this or rewrite it";
            Console.WriteLine(task5);
            Task5(task5);
            Console.WriteLine();

            Console.WriteLine("Task6 ===============");
            string code = @"        static void Task5(string str)
        {
            char tmp;
            int quantity = 0;
            for (int i = 97; i < 123; i++)
            {
                tmp = Convert.ToChar(i);
                Console.Write";
            Console.WriteLine(code);
            Console.WriteLine();
            Task6(code);
        }
    }
}
