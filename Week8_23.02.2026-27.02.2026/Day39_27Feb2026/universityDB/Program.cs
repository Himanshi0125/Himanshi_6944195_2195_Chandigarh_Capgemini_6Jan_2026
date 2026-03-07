using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace universityDB
{
    class Program
    {
        static string connectionString =
        "Server=localhost;Database=UniversityDB;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== UNIVERSITY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. View All Students");
                Console.WriteLine("2. View Student By ID");
                Console.WriteLine("3. Add Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        GetAllStudents();
                        break;

                    case 2:
                        Console.Write("Enter Student ID: ");
                        int sid = Convert.ToInt32(Console.ReadLine()!);
                        GetStudentById(sid);
                        break;

                    case 3:
                        Console.Write("First Name: ");
                        string fn = Console.ReadLine()!;

                        Console.Write("Last Name: ");
                        string ln = Console.ReadLine()!;

                        Console.Write("Email: ");
                        string email = Console.ReadLine()!;

                        Console.Write("Dept ID: ");
                        int dept = Convert.ToInt32(Console.ReadLine()!);

                        InsertStudent(fn, ln, email, dept);
                        Console.WriteLine("Student Added!");
                        break;

                    case 4:
                        Console.Write("Student ID to Update: ");
                        int uid = Convert.ToInt32(Console.ReadLine()!);

                        Console.Write("New First Name: ");
                        fn = Console.ReadLine()!;

                        Console.Write("New Last Name: ");
                        ln = Console.ReadLine()!;

                        Console.Write("New Email: ");
                        email = Console.ReadLine()!;

                        Console.Write("New Dept ID: ");
                        dept = Convert.ToInt32(Console.ReadLine()!);

                        UpdateStudent(uid, fn, ln, email, dept);
                        Console.WriteLine("Student Updated!");
                        break;

                    case 5:
                        Console.Write("Student ID to Delete: ");
                        int did = Convert.ToInt32(Console.ReadLine()!);

                        DeleteStudent(did);
                        Console.WriteLine("Student Deleted!");
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }

        static void GetAllStudents()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetAllStudents", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]} - {reader["DeptName"]}");
            }
        }

        static void GetStudentById(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetStudentById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", id);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine($"Student: {reader["FirstName"]} {reader["LastName"]}");
            }
        }

        static void InsertStudent(string fn,string ln,string email,int dept)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("InsertStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", fn);
            cmd.Parameters.AddWithValue("@LastName", ln);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@DeptId", dept);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        static void UpdateStudent(int id,string fn,string ln,string email,int dept)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UpdateStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@FirstName", fn);
            cmd.Parameters.AddWithValue("@LastName", ln);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@DeptId", dept);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        static void DeleteStudent(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DeleteStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}