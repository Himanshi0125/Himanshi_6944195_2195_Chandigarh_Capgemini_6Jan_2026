using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        public string Course { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
    }
}