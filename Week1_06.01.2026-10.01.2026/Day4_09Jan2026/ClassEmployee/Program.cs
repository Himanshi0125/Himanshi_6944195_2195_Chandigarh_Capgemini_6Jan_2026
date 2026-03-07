using System;

namespace Day4_09Jan2026
{
    class ClassEmployee
    {
        public int EmpId, Eage; public string EName = ""; public string Eaddress = "";
        public void GetEmpData()
        {
            Console.Write("Enter employee id : ");
            this.EmpId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter employee name : ");
            this.EName = Console.ReadLine()!;
            Console.Write("Enter employee age : ");
            this.Eage = int.Parse(Console.ReadLine()!);
            Console.Write("Enter employee address : ");
            this.Eaddress = Console.ReadLine()!;
        }
        public void PrintEmpData()
        {
            Console.WriteLine("Employee Name is: " + this.EName);
            Console.WriteLine("Employee Id is: " + this.EmpId);
            Console.WriteLine("Employee Age is: " + this.Eage);
            Console.WriteLine("Employee Address is: " + this.Eaddress);
        }
    }

    class Program2{
        static void Main(string[] args)
        {
            ClassEmployee emp = new ClassEmployee();
            emp.GetEmpData();
            emp.PrintEmpData();
            Console.ReadLine();
        }
    }
}
