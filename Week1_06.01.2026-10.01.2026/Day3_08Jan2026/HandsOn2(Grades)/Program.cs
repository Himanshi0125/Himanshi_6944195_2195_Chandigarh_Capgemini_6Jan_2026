//determine the grades of a student

using System;

namespace Day3_08Jan2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your marks out of 100 : ");
            int marks = int.Parse(Console.ReadLine()!);

            switch (marks)
            {
                case > 90 and <= 100:
                    Console.WriteLine("Grade A");
                    break;
                case > 80 and <= 90:
                    Console.WriteLine("Grade B");
                    break;
                case > 70 and <= 80:
                    Console.WriteLine("Grade C");
                    break;
                case > 60 and <= 70:
                    Console.WriteLine("Grade D");
                    break;
                case <= 60:
                    Console.WriteLine("Grade E");
                    break;
            }

            Console.ReadLine();
        }
    }
}
