using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradeBook.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }

        public string Teacher { get; set; }

        public string PassType { get; set; }
        
    }
}
