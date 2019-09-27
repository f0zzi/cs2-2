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
        static void Main(string[] args)
        {
            Console.WriteLine("Task1 ===============");
            int max = 0, min = 0;
            int[] arr1 = new int[10];
            FillArr(arr1);
            ShowArr(arr1);
            MaxMin(arr1, ref max, ref min);
            Console.WriteLine($"Max: {max}\t Min: {min}.");

            Console.WriteLine("Task2 ===============");
            string test2 = "Lets assume this sentence is long enough.";
            Task2(test2);

            Console.WriteLine("Task3 ===============");
            Console.WriteLine($"Enter some text and letter to find: ");
            Task3(Console.ReadLine(), Convert.ToChar(Console.ReadLine()));

            Console.WriteLine("Task4 ===============");
            Console.Write($"Enter some text: ");
            string text = Console.ReadLine();
            Console.WriteLine(text);
            Task4(ref text, 'a', 'e', 'i', 'o', 'u', 'y');
            Console.WriteLine(text);
        }
    }
}
