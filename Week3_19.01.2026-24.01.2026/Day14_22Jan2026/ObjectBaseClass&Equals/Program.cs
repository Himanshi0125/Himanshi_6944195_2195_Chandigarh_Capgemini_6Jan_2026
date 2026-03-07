using System;

class ObjectBaseClass{
    static void Main()
    {
        Console.Write("ToString() method : ");
        object obj1 = 15;
        Console.WriteLine(obj1.ToString());
        

        Console.Write("GetType() method : ");
        object obj2 = "Hello";
        Console.WriteLine(obj2.GetType());

        Console.Write("Equals() method : ");
        object obj3 = 10;
        object obj4 = "10";
        Console.WriteLine(obj3.Equals(obj4));

        Console.Write("== : ");
        Console.WriteLine(obj3 == obj4);

        Console.Write("GetHashCode() method : ");
        object obj5 = "123";
        Console.WriteLine(obj5.GetHashCode());
    }
}