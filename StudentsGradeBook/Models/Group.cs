using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradeBook.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
