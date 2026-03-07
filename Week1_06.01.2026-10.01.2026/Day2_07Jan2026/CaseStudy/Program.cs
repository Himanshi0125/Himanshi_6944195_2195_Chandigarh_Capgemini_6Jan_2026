using System;

namespace ConsoleApp2_cu
{
    internal class Project
    {
        public void TaskAssign()
        {
            Console.WriteLine("Task is Assigned.");
        }

        public void TaskStatus()
        {
            Console.WriteLine("Task is Completed.");
        }
        
        static void Main(string[] args)
        {
            Project ecommerce = new Project();
            ecommerce.TaskAssign();
            ecommerce.TaskStatus();
        }   
    }
}