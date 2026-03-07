using System;
using System.Collections.Generic;

namespace UniversityEnrollmentSystem
{
    // Base Class
    class Person
    {
        private int id;
        private string name;
        private string email;

        public Person(int id, string name, string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }

        public virtual void DisplayProfile()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Email: " + email);
        }
    }

    // Derived Class - Student
    class Student : Person
    {
        private string courseEnrolled;

        public Student(int id, string name, string email, string course)
            : base(id, name, email)
        {
            courseEnrolled = course;
        }

        public override void DisplayProfile()
        {
            base.DisplayProfile();
            Console.WriteLine("Enrolled Course: " + courseEnrolled);
        }
    }

    // Derived Class - Professor
    class Professor : Person
    {
        private List<Course> assignedCourses = new List<Course>();

        public Professor(int id, string name, string email)
            : base(id, name, email) { }

        public void AssignCourse(Course course)
        {
            assignedCourses.Add(course);
        }

        public override void DisplayProfile()
        {
            base.DisplayProfile();
            Console.WriteLine("Courses Assigned:");
            foreach (var course in assignedCourses)
            {
                Console.WriteLine("- " + course.CourseName);
            }
        }
    }

    // Derived Class - Staff
    class Staff : Person
    {
        private string department;

        public Staff(int id, string name, string email, string dept)
            : base(id, name, email)
        {
            department = dept;
        }

        public override void DisplayProfile()
        {
            base.DisplayProfile();
            Console.WriteLine("Department: " + department);
        }
    }

    // Course Class
    class Course
    {
        public string CourseCode { get; }
        public string CourseName { get; }

        public Course(string code, string name)
        {
            CourseCode = code;
            CourseName = name;
        }
    }

    // Department Class
    class Department
    {
        public string DepartmentName { get; }
        private List<Course> courses = new List<Course>();

        public Department(string name)
        {
            DepartmentName = name;
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void DisplayCourses()
        {
            Console.WriteLine("Courses in " + DepartmentName + " Department:");
            foreach (var course in courses)
            {
                Console.WriteLine(course.CourseCode + " - " + course.CourseName);
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(1, "Himanshi", "himanshi@gmail.com", "Computer Science");
            Professor professor = new Professor(101, "Dr. Sharma", "sharma@uni.edu");
            Staff staff = new Staff(201, "Raj", "raj@uni.edu", "Administration");

            Course c1 = new Course("CS101", "Data Structures");
            Course c2 = new Course("CS102", "Operating Systems");

            Department csDept = new Department("Computer Science");
            csDept.AddCourse(c1);
            csDept.AddCourse(c2);

            professor.AssignCourse(c1);
            professor.AssignCourse(c2);

            Console.WriteLine("\n--- Student Profile ---");
            student.DisplayProfile();

            Console.WriteLine("\n--- Professor Profile ---");
            professor.DisplayProfile();

            Console.WriteLine("\n--- Staff Profile ---");
            staff.DisplayProfile();

            Console.WriteLine();
            csDept.DisplayCourses();

            Console.ReadLine();
        }
    }
}
