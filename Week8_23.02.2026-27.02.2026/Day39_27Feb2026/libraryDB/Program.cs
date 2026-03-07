using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace libraryDB
{
    class Program
    {
        static string connectionString =
        "Server=localhost;Database=LibraryDB;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("\n--- LIBRARY SYSTEM ---");
                Console.WriteLine("1. View Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");

                Console.Write("Choose option: ");
                int choice = Convert.ToInt32(Console.ReadLine()!);

                switch(choice)
                {
                    case 1:
                        GetAllBooks();
                        break;

                    case 2:
                        Console.Write("Title: ");
                        string title = Console.ReadLine()!;

                        Console.Write("AuthorId: ");
                        int aid = Convert.ToInt32(Console.ReadLine()!);

                        Console.Write("Year: ");
                        int year = Convert.ToInt32(Console.ReadLine()!);

                        InsertBook(title, aid, year);
                        break;

                    case 3:
                        Console.Write("BookId: ");
                        int id = Convert.ToInt32(Console.ReadLine()!);

                        Console.Write("New Title: ");
                        title = Console.ReadLine();

                        Console.Write("AuthorId: ");
                        aid = Convert.ToInt32(Console.ReadLine()!);

                        Console.Write("Year: ");
                        year = Convert.ToInt32(Console.ReadLine()!);

                        UpdateBook(id, title, aid, year);
                        break;

                    case 4:
                        Console.Write("BookId to delete: ");
                        id = Convert.ToInt32(Console.ReadLine()!);
                        DeleteBook(id);
                        break;

                    case 5:
                        return;
                }
            }
        }

        static void GetAllBooks()
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter adapter =
                new SqlDataAdapter("GetAllBooks", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine($"{row["Title"]} - {row["AuthorName"]}");
            }
        }

        static void InsertBook(string title,int authorId,int year)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand("InsertBook", conn);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            adapter.InsertCommand.Parameters.AddWithValue("@Title", title);
            adapter.InsertCommand.Parameters.AddWithValue("@AuthorId", authorId);
            adapter.InsertCommand.Parameters.AddWithValue("@PublishedYear", year);

            conn.Open();
            adapter.InsertCommand.ExecuteNonQuery();
        }

        static void UpdateBook(int id,string title,int authorId,int year)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand("UpdateBook", conn);
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            adapter.UpdateCommand.Parameters.AddWithValue("@BookId", id);
            adapter.UpdateCommand.Parameters.AddWithValue("@Title", title);
            adapter.UpdateCommand.Parameters.AddWithValue("@AuthorId", authorId);
            adapter.UpdateCommand.Parameters.AddWithValue("@PublishedYear", year);

            conn.Open();
            adapter.UpdateCommand.ExecuteNonQuery();
        }

        static void DeleteBook(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = new SqlCommand("DeleteBook", conn);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

            adapter.DeleteCommand.Parameters.AddWithValue("@BookId", id);

            conn.Open();
            adapter.DeleteCommand.ExecuteNonQuery();
        }
    }
}