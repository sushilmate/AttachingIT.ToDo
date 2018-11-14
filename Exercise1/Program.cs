using System;

namespace Exercise
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Exercise1.Run();

            Console.WriteLine();

            Exercise2.Run();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}