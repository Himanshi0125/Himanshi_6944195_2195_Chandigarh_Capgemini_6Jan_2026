using System;

namespace MultiTaskDelegate
{
    public delegate void Math(int x, int y);
    class MultiClass
    {
        public void add(int x, int y)
        {
            Console.WriteLine("Add : " + (x+y));
        }
        public void sub(int x, int y)
        {
            Console.WriteLine("Subtract : " + (x-y));
        }
        public void mul(int x, int y)
        {
            Console.WriteLine("Multiplication : "+ (x*y));
        }
        public void div(int x, int y)
        {
            Console.WriteLine("Division : " + (x/y));
        }

        static void Main()
        {
            MultiClass obj = new MultiClass();
            Math m = new Math(obj.add);
            m += obj.sub;
            m += obj.mul;
            m += obj.div;

            m(100,50);
            Console.WriteLine();
            m(40, 20);
            Console.WriteLine();
            m -= obj.div;
            m(30,10);
            Console.ReadLine();
        }
    }
}