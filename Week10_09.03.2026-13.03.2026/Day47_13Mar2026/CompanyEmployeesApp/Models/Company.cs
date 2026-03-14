using System.Collections.Generic;

namespace CompanyEmployeesApp.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        // One company → many employees
        public List<Employee> Employees { get; set; }
    }
}