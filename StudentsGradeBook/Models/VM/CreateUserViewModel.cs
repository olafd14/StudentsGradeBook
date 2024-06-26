﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradeBook.Models.VM
{
    public class CreateUserViewModel
    {
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ValidateNever]
        public string Password { get; set; } 

        [Required]
        public string Role { get; set; }
        [ValidateNever]
        public int GroupId { get; set; }

        [ValidateNever]
        public IEnumerable<Group> Groups { get; set; }
    }
}
