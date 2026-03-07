using System;
using System.ComponentModel;

class Parameters
{
    void Add(int a, int b = 10)
    {
        Console.WriteLine(a + b);
    }

    void Display(string firstName, string lastName, int age)
    {
        Console.WriteLine($"{firstName} {lastName}, Age : {age}");
    }

    static void Main()
    {
        Add(5);
        Add(5, 20);
        Display("Himanshi", "Gupta", 20);
        Display(lastName: "Singh", firstName: "Kashish", age : 21);
        Display(age: 40, firstName: "Mark", lastName: "Lee");
    }
}