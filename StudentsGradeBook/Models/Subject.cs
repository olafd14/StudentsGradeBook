using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradeBook.Models
{
    public class Subject
    {
        public int SubjectId { get; set; } 

        public string SubjectName { get; set; }

        public string Teacher { get; set; }

        public string PassType { get; set; }
        public string GroupId { get; set; }
        [ForeignKey("GroupId")]
        [ValidateNever]
        [NotMapped]
        public Group Group { get; set; }
    }
}
