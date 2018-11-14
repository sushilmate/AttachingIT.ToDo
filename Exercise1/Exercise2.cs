using System;
using System.Linq;

namespace Exercise
{
    internal static class Exercise2
    {
        internal static void Run()
        {
            var arr = new char[] { 'z', 'q', 'a', 'u', 'w', 'r', 'c', 'f' };
            // Your output should be: a c f q r u w z
            Console.WriteLine(string.Join(" ", arr.OrderBy(x => x)));
            //Another approch
            //Console.WriteLine();
            //AnotherApporch();
        }

        internal static void AnotherApporch()
        {
            var arr = new char[] { 'z', 'q', 'a', 'u', 'w', 'r', 'c', 'f' };
            // Your output should be: a c f q r u w z

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", arr.OrderBy(x => x)));
        }
    }
}