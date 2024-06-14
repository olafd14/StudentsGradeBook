using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradeBook.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [Display(Name = "Data płatności")]
        public DateTime PaymentDate { get; set; }
        [Required]
        [Display(Name = "Data wymaganej płatności")]
        public int PaymentAmount { get; set; }
        [Required]
        [Display(Name = "Za co")]
        public string ForWhat { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public User User { get; set; }
    }
}
