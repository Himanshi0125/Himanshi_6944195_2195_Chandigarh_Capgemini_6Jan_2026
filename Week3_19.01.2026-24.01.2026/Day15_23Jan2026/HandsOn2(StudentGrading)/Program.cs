using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Dictionary to store RollNo -> Grade
        Dictionary<int, int> studentGrades = new Dictionary<int, int>();

        // Add students
        studentGrades.Add(101, 78);
        studentGrades.Add(102, 45);
        studentGrades.Add(103, 88);
        studentGrades.Add(104, 52);

        Console.WriteLine("Student Grades:");
        DisplayGrades(studentGrades);

        // Func to calculate average grade
        Func<Dictionary<int, int>, double> calculateAverage =
            grades => grades.Values.Average();

        double average = calculateAverage(studentGrades);
        Console.WriteLine("\nAverage Grade: " + average);

        // Predicate to identify at-risk students (grade < 50)
        Predicate<KeyValuePair<int, int>> isAtRisk =
            student => student.Value < 50;

        Console.WriteLine("\nAt-Risk Students:");
        foreach (var student in studentGrades)
        {
            if (isAtRisk(student))
            {
                Console.WriteLine("Roll No: " + student.Key +
                                  ", Grade: " + student.Value);
            }
        }

        // Update a student's grade
        Console.WriteLine("\nUpdating grade of Roll No 102...");
        studentGrades[102] = 65;

        Console.WriteLine("\nUpdated Student Grades:");
        DisplayGrades(studentGrades);

        // Re-evaluate at-risk students
        Console.WriteLine("\nAt-Risk Students After Update:");
        bool anyRisk = false;

        foreach (var student in studentGrades)
        {
            if (isAtRisk(student))
            {
                Console.WriteLine("Roll No: " + student.Key +
                                  ", Grade: " + student.Value);
                anyRisk = true;
            }
        }

        if (!anyRisk)
            Console.WriteLine("No students at risk.");
    }

    static void DisplayGrades(Dictionary<int, int> grades)
    {
        foreach (var student in grades)
        {
            Console.WriteLine("Roll No: " + student.Key +
                              ", Grade: " + student.Value);
        }
    }
}
