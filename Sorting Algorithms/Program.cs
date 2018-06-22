using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = GenerateData();
            Console.WriteLine("This Data is:");
            PrintResults(data);

            Stopwatch stopwatch = Stopwatch.StartNew();
            IntArrayInsertionSort(data);
            stopwatch.Stop();

            Console.WriteLine("Sorted by insertion");
            PrintResults(data);

            Console.WriteLine($"And this took {stopwatch.ElapsedTicks} ticks");
            DividerLine();

            data = GenerateData();
            Console.WriteLine("This Data is:");
            PrintResults(data);
            stopwatch = Stopwatch.StartNew();
            IntArraySelectionSort(data);
            stopwatch.Stop();

            Console.WriteLine("Sorted by selection");
            PrintResults(data);

            Console.WriteLine($"And this took {stopwatch.ElapsedTicks} ticks");

            DividerLine();

            List<int> dataList = GenerateData().ToList();
            Console.WriteLine("This Data is:");
            PrintResults(dataList.ToArray());
            stopwatch = Stopwatch.StartNew();
            dataList = MergeSort(dataList);
            stopwatch.Stop();

            Console.WriteLine("Sorted by MergeSort");
            PrintResults(dataList.ToArray());

            Console.WriteLine($"And this took {stopwatch.ElapsedTicks} ticks");

            DividerLine();

            data = GenerateData();
            Console.WriteLine("This Data is:");
            PrintResults(data);
            stopwatch = Stopwatch.StartNew();
            IntArrayQuickSort(data);
            stopwatch.Stop();

            Console.WriteLine("Sorted by QuickSort");
            PrintResults(data);

            Console.WriteLine($"And this took {stopwatch.ElapsedTicks} ticks");

            Console.ReadLine();
        }
        private static void DividerLine()
        {
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
        }
        public static void IntArrayQuickSort(int[] data, int l, int r)
        {
            int i, j;
            int x;

            i = l;
            j = r;

            x = data[(l + r) / 2]; /* find pivot item */
            while (true)
            {
                while (data[i] < x)
                    i++;
                while (x < data[j])
                    j--;
                if (i <= j)
                {
                    exchange(data, i, j);
                    i++;
                    j--;
                }
                if (i > j)
                    break;
            }
            if (l < j)
                IntArrayQuickSort(data, l, j);
            if (i < r)
                IntArrayQuickSort(data, i, r);
        }
        public static void IntArrayQuickSort(int[] data)
        {
           IntArrayQuickSort(data, 0, data.Length - 1);
        }
        private static List<int> MergeSort(List<int> data)
        {
            if (data.Count <= 1)
                return data;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = data.Count / 2;
            for (int i = 0; i < middle; i++) 
            {
                left.Add(data[i]);
            }
            for (int i = middle; i < data.Count; i++)
            {
                right.Add(data[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First()) 
                    {
                        result.Add(left.First());
                        left.Remove(left.First());    
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
        private static int[] GenerateData()
        {
            int Min = 0;
            int Max = 300;
            Random randNum = new Random();
            int[] data = Enumerable
                .Repeat(0, 200)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();
            return data;
        }
        private static void PrintResults(int[] data)
        {
            Console.WriteLine();
            int last = data.Last();

            foreach (var item in data)
            {
                if (item == last)
                {
                    Console.Write(item.ToString());

                }
                else
                {
                    Console.Write($"{item.ToString()}, ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static int IntArrayMin(int[] data, int start)
        {
            int minPos = start;
            for (int pos = start + 1; pos < data.Length; pos++)
                if (data[pos] < data[minPos])
                    minPos = pos;
            return minPos;
        }
        public static void IntArrayInsertionSort(int[] data)
        {
            int i, j;
            int N = data.Length;

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && data[i] < data[i - 1]; i--)
                {
                    exchange(data, i, i - 1);
                }
            }
        }
        public static void IntArraySelectionSort(int[] data)
        {
            int i;
            int N = data.Length;

            for (i = 0; i < N - 1; i++)
            {
                int k = IntArrayMin(data, i);
                if (i != k)
                    exchange(data, i, k);
            }
        }
        public static void exchange(int[] data, int m, int n)
        {
            int temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }
    }
}
