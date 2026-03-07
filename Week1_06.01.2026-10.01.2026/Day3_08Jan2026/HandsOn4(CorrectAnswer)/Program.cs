using System;

namespace Day3_08Jan2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the correct way to declare a variable to store an integer value in C#?\na. int 1x = 10;\nb. int x = 10;\nc. float x = 10.0f;\nd. string x = \"10\";");
            Console.Write("Choose your answer : ");
            string ans = Console.ReadLine()!;
            if (ans == "b")
            {
                Console.WriteLine("Correct Answer.");
            }
            else
            {
                Console.WriteLine("Incorrect Answer.");
            }
            
            Console.ReadLine();
        }
    }
}
