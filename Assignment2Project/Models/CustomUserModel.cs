using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Project.Models
{
    public class CustomUserModel : IdentityUser
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Sname { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }
    }
}