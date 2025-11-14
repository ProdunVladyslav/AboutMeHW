using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RazorEx.Models
{
    public class Person
    {
        [ValidateNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Profession is required.")]
        [StringLength(100, ErrorMessage = "Profession cannot exceed 100 characters.")]
        public string Profession { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateOnly BirthDate { get; set; }

        [ValidateNever]
        public List<int> SkillIds { get; set; } = new();
    }
}
