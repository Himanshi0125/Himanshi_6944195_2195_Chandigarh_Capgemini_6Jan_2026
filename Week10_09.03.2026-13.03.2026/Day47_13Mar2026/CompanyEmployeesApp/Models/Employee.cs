namespace CompanyEmployeesApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        // Foreign Key
        public int CompanyId { get; set; }

        // Navigation property
        public Company Company { get; set; }
    }
}