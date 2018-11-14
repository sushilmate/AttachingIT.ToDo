using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    internal static class Exercise1
    {
        /// <summary>
        /// using LINQ
        /// </summary>
        internal static void Run()
        {
            // For each value count the number of occurences.
            // Only output the occurence for a value once.
            var arr = new int[] { 6, 6, 9, 8, 5, 4, 7, 8, 5, 3, 2, 3, 2, 3, 6, 5, 8, 5, 8, 6, 9, 6, 9, 9, 5, 8, 7, 4, 7, 8, 4, 5, 9, 5, 2, 6, 5, 8, 7, 1 };

            // Your output should look like: 1=1 2=3 3=3 4=3 5=8 6=6 7=4 8=7 9=5

            var groupedElements = arr.OrderBy(x => x).GroupBy(y => y);
            foreach (var item in groupedElements)
            {
                Console.Write(item.Key + "=" + item.Count() + " ");
            }
            //Another way to achieve solution
            //AnotherApproch();
        }

        /// <summary>
        /// without linq
        /// </summary>
        internal static void AnotherApproch()
        {
            var arr = new int[] { 6, 6, 9, 8, 5, 4, 7, 8, 5, 3, 2, 3, 2, 3, 6, 5, 8, 5, 8, 6, 9, 6, 9, 9, 5, 8, 7, 4, 7, 8, 4, 5, 9, 5, 2, 6, 5, 8, 7, 1 };
            var arrDict = new SortedDictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arrDict.ContainsKey(arr[i]))
                {
                    //increment the value
                    arrDict[arr[i]]++;
                }
                else
                {
                    // new element add in the dict & Initialize with 1
                    arrDict.Add(arr[i], 1);
                }
            }

            foreach (var item in arrDict)
            {
                Console.Write(item.Key + "=" + item.Value + " ");
            }
        }
    }
}