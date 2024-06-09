using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace StudentsGradeBook.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        // Oznaczenie pola jako wymagane
        [Required]
        // Ustawienie nazwy do wyświetlania jako Nazwisko (nie trzeba ręcznie zmieniać z LastName)
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
    }
}
