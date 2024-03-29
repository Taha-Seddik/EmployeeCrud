﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
    }
}