using System;

namespace Day3_08Jan2026
{
    internal class PassingParameters
    {
        void test1()
        {
            Console.WriteLine("This is first method.");
        }
        void test2(int x)
        {
            Console.WriteLine("This is 2nd method.");
        }
        string test3()
        {
            return "This is 3rd method";
        }
        string test4(string name)
        {
            return "Hello" + name;
        }
        void math1(int x, int y, ref int a, ref int b)
        {
            a = x + y;
            b = x * y;
        }
        void math2(int x, int y, out int a, out int b)
        {
            a = x - y;
            b = x / y;
        }
        static void Main(string[] args)
        {
            PassingParameters p = new PassingParameters();
            p.test1();
            p.test2(100);
            Console.WriteLine(p.test3());
            Console.WriteLine(p.test4("Ram"));

            int m = 0;
            int n = 0;
            p.math1(100, 50, ref m, ref n);
            Console.WriteLine(m+" "+n);
            int q, r;
            p.math2(100, 50, out q, out r);
            Console.WriteLine(q+" "+r);
            Console.ReadLine();
        }
    }
}
