using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudentsGradeBook.Models.VM
{
    public class AddNewUserViewModel
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
        [Required]
        public int GroupId { get; set; }


    }
}
