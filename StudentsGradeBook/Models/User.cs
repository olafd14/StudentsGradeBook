using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradeBook.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string GroupId { get; set; }
        [ForeignKey("GroupId")]
        [ValidateNever]
        [NotMapped]
        public Group Group { get; set; }

    }
}
