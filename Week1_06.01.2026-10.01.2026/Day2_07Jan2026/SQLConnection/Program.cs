using System;
class cap1
{
    static void Main()
    {
        string connectionString =
            "Server=localhost;" +
            "Database=master;" +
            "User Id=sa;" +
            "Password=StrongPassword@123;" +
            "TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("✅ Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Connection failed:");
                Console.WriteLine(ex.Message);
            }
        }

        Console.ReadLine();
    }
}
