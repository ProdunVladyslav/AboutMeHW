using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RazorEx.Models
{
    public class Skill
    {
        [ValidateNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100, ErrorMessage = "The title can't be longer than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Proficiency must be between 1 and 100.")]
        public int Proficiency { get; set; }
    }
}
